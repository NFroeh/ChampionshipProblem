using ChampionshipProblem.Classes;
using ChampionshipProblem.Classes.ResultClasses;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ChampionshipProblem
{
    /// <summary>
    /// Klasse repräsentiert das Form.
    /// </summary>
    public partial class ChampionshipProblemForm : Form
    {
        #region fields
        /// <summary>
        /// Die Daten.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel;

        /// <summary>
        /// Die aktuell ausgewählte Liga.
        /// </summary>
        private League CurrentSelectedLeague;

        /// <summary>
        /// Die aktuell ausgewählte Saison.
        /// </summary>
        private string CurrentSelectedSeason;

        /// <summary>
        /// Der aktuell ausgewählte Spieltag.
        /// </summary>
        private int CurrentSelectedStage;

        /// <summary>
        /// Der aktuell ausgewählte verbleibende Spieltag.
        /// </summary>
        private int CurrentSelectedRemainingMatchStage;

        /// <summary>
        /// Die aktuelle Tabelle
        /// </summary>
        private IEnumerable<CompleteLeagueStandingEntry> LeagueStandingEntries;

        /// <summary>
        /// Die Anzahl der aktuellen Spieltage.
        /// </summary>
        private int NumberOfStages;
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Intialisieren der Instanzvariablen.
        /// </summary>
        /// <param name="soccerDB">Die Datenbank-Verbindung</param>
        public ChampionshipProblemForm(ChampionshipViewModel championshipViewModel)
        {
            // Komponenten initialisieren
            InitializeComponent();

            // Parameter merken oder erzeugen
            this.ChampionshipViewModel = championshipViewModel;
            this.LeagueStandingEntries = new List<CompleteLeagueStandingEntry>();
            this.CurrentSelectedLeague = null;
            this.CurrentSelectedSeason = null;
            this.CurrentSelectedStage = 1;
            this.CurrentSelectedRemainingMatchStage = 2;
            this.NumberOfStages = 0;

            // Keine automatische Generierung der Spalten in der DataGridView
            StandingsView.AutoGenerateColumns = false;
            RemainingMatchesView.AutoGenerateColumns = false;
            ComputationStandingView.AutoGenerateColumns = false;

            // Die Selektorspalte ausblenden
            StandingsView.RowHeadersVisible = false;
            RemainingMatchesView.RowHeadersVisible = false;
            ComputationStandingView.RowHeadersVisible = false;

            // Die Ligen als Datengrundlage setzen
            List<League> leagues = championshipViewModel.LeagueService.GetLeagues().ToList();
            LeagueComboBox.DataSource = leagues;
            LeagueComboBox.DisplayMember = "name";

            // Spalten des standingView generieren
            this.GenerateStandingsViewColumns();

            // Spalten des remainingMatchesView generieren
            this.GenerateRemainingMatchesViewColumns();

            // Spalten der computationstandingView generieren
            this.GenerateComputationStandingView();
        }
        #endregion

        #region LeagueComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn die LeagueComboBox geändert wird.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void LeagueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Die Liga ermitteln
            this.CurrentSelectedLeague = (League)LeagueComboBox.SelectedValue;

            // Die Saisons ermitteln und setzen
            string[] seasons = this.ChampionshipViewModel.MatchService.GetSeasonsByLeagueId(this.CurrentSelectedLeague.id).ToArray();
            this.SeasonComboBox.DataSource = seasons;
        }
        #endregion

        #region SeasonComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn ein neuer Wert in der SeasonComboBox ausgewählt wurde.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void SeasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedSeason = (string)SeasonComboBox.SelectedValue;

            // Die Anzahl der Spieltage ermitteln und setzen (Bei Saisonänderung kann auch die Anzahl der Mannschaften verändert worden sein)
            this.NumberOfStages = (int)this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.CurrentSelectedLeague.id, this.CurrentSelectedSeason);
            StageComboBox.DataSource = Enumerable.Range(1, this.NumberOfStages).ToArray();

            this.RefreshStandings();
        }
        #endregion

        #region StageComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn ein neuer Wert in der StageComboBox ausgewählt wurde.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void StageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Die aktuelle Stage ermitteln
            this.CurrentSelectedStage = (int) StageComboBox.SelectedValue;

            if (this.CurrentSelectedStage != this.NumberOfStages)
            {
                // Die neue RemainingStage-Range setzen
                RemainingMatchComboBox.DataSource = Enumerable.Range(this.CurrentSelectedStage + 1, this.NumberOfStages - this.CurrentSelectedStage).ToArray();
            }
            else
            {
                RemainingMatchComboBox.DataSource = new int[]{ this.NumberOfStages };
            }

            // Den Index neu setzen für die RemainingMatchStage
            this.CurrentSelectedRemainingMatchStage = (this.CurrentSelectedStage + 1);

            // Die View aktualisieren
            this.RefreshStandings();
        }
        #endregion

        #region StandingsView_CellClick
        /// <summary>
        /// Methode wird ausgeführt, wenn auf eine Zelle der Tabelle geklickt wird.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente</param>
        private void StandingsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.StandingsView.Columns["Compute best position"].Index)
            {
                DataGridViewRow selectedRow = this.StandingsView.Rows[e.RowIndex];
                CompleteLeagueStandingEntry entry = (CompleteLeagueStandingEntry)selectedRow.DataBoundItem;

                // Zuerst prüfen, wie viele Matches berücksichtigt werden
                int remainingMatchesCount = this.ChampionshipViewModel.LeagueStandingService.CalculateNumberOfRemainingMatchesForBestPossiblePosition(this.CurrentSelectedStage, entry.TeamApiId.Value);
                long numberOfIterations = (long) Math.Pow(3, remainingMatchesCount);
                DialogResult result = DialogResult.Yes;

                if (numberOfIterations > Double.MaxValue || numberOfIterations <= 0)
                {
                    result = MessageBox.Show($"Because of the missing '{remainingMatchesCount}' matches, too many iterations are needed. Therefore only one iteration will be made. Do you want to continue?",
                        "Continue computation?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if (remainingMatchesCount > 9)
                {
                    result = MessageBox.Show($"The computation will need '3^{remainingMatchesCount}'('{numberOfIterations}') iterations. Do you want to continue?", 
                        "Continue computation?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    if (ComputeResultCheckbox.Checked)
                    {
                        PositionComputationalResult positionComputationalResult = this.ChampionshipViewModel.LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamApiId.Value, true);
                        entry.BestPossiblePosition = positionComputationalResult.Position;
                        ComputationStandingView.DataSource = positionComputationalResult.ComputationalStanding.ToArray();
                        stopwatch.Stop();
                    }
                    else
                    {
                        entry.BestPossiblePosition = this.ChampionshipViewModel.LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamApiId.Value, false).Position;
                        stopwatch.Stop();
                    }

                    entry.LastElapsedTime = (double)stopwatch.ElapsedMilliseconds / 1000;
                    this.StandingsView.Refresh();
                }
            }

            if (e.ColumnIndex == this.StandingsView.Columns["Compute worst position"].Index)
            {
                DataGridViewRow selectedRow = this.StandingsView.Rows[e.RowIndex];
                CompleteLeagueStandingEntry entry = (CompleteLeagueStandingEntry)selectedRow.DataBoundItem;

                // Zuerst prüfen, wie viele Matches berücksichtigt werden
                int remainingMatchesCount = this.ChampionshipViewModel.LeagueStandingService.CalculateNumberOfRemainingMatchesForWorstPossiblePosition(this.CurrentSelectedStage, entry.TeamApiId.Value);
                long numberOfIterations = (long)Math.Pow(3, remainingMatchesCount);
                DialogResult result = DialogResult.Yes;

                if (numberOfIterations > Double.MaxValue || numberOfIterations <= 0)
                {
                    result = MessageBox.Show($"Because of the missing '{remainingMatchesCount}' matches, , too many iterations are needed. Therefore only one iteration will be made. Do you want to continue?",
                        "Continue computation?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if (remainingMatchesCount > 9)
                {
                    result = MessageBox.Show($"The computation will need '3^{remainingMatchesCount}'('{numberOfIterations}') iterations. Do you want to continue?",
                        "Continue computation?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    if (ComputeResultCheckbox.Checked)
                    {
                        PositionComputationalResult positionComputationalResult = this.ChampionshipViewModel.LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamApiId.Value, true);
                        entry.WorstPossiblePosition = positionComputationalResult.Position;
                        ComputationStandingView.DataSource = positionComputationalResult.ComputationalStanding.ToArray();
                        stopwatch.Stop();
                    }
                    else
                    {
                        entry.WorstPossiblePosition = this.ChampionshipViewModel.LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamApiId.Value, false).Position;
                        stopwatch.Stop();
                    }

                    entry.LastElapsedTime = (double)stopwatch.ElapsedMilliseconds / 1000;
                    this.StandingsView.Refresh();
                }
            }

            if (e.ColumnIndex == this.StandingsView.Columns["Compute possible championship"].Index)
            {
                DataGridViewRow selectedRow = this.StandingsView.Rows[e.RowIndex];
                CompleteLeagueStandingEntry entry = (CompleteLeagueStandingEntry)selectedRow.DataBoundItem;

                // Zuerst prüfen, wie viele Matches berücksichtigt werden
                int remainingMatchesCount = this.ChampionshipViewModel.LeagueStandingService.CalculateNumberOfRemainingMatchesForChampion(this.CurrentSelectedStage, entry.TeamApiId.Value);
                long numberOfIterations = (long)Math.Pow(3, remainingMatchesCount);
                DialogResult result = DialogResult.Yes;

                if (numberOfIterations > Double.MaxValue || numberOfIterations <= 0)
                {
                    result = MessageBox.Show($"Because of the missing '{remainingMatchesCount}' matches, too many iterations could be needed. Therefore only one iteration will be made. Do you want to continue?",
                        "Continue computation?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if (remainingMatchesCount > 9)
                {
                    result = MessageBox.Show($"The computation could need '3^{remainingMatchesCount}'('{numberOfIterations}') iterations. Do you want to continue?",
                        "Continue computation?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    // Ausrechnen
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    if (ComputeResultCheckbox.Checked)
                    {
                        ChampionComputationalResult championComputationalResult = this.ChampionshipViewModel.LeagueStandingService.CalculateIfTeamCanWinChampionship(this.CurrentSelectedStage, entry.TeamApiId.Value, true);
                        stopwatch.Stop();
                        entry.CanWinChampionship = championComputationalResult.CanWinChampionship;
                        if (championComputationalResult.CanWinChampionship)
                        {
                            ComputationStandingView.DataSource = championComputationalResult.ComputationalStanding.ToArray();
                        }
                        else
                        {
                            ComputationStandingView.DataSource = new string[0];
                        }

                    }
                    else
                    {
                        entry.CanWinChampionship = this.ChampionshipViewModel.LeagueStandingService.CalculateIfTeamCanWinChampionship(this.CurrentSelectedStage, entry.TeamApiId.Value, false).CanWinChampionship;
                        stopwatch.Stop();
                    }

                    entry.LastElapsedTime = (double)stopwatch.ElapsedMilliseconds / 1000;
                    this.StandingsView.Refresh();
                }
            }
        }
        #endregion

        #region RemainingMatchComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn die RemainingMatchComboBox geändert wird.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void RemainingMatchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Neuer Parameter holen
            this.CurrentSelectedRemainingMatchStage = (int)RemainingMatchComboBox.SelectedValue;

            // Fehlende Spiele ermitteln
            IEnumerable<RemainingMatch> remainingMatchesForSingleStage = this.ChampionshipViewModel.MatchService.GetRemainingMatchesForSingleStage(this.CurrentSelectedLeague.id, this.CurrentSelectedSeason, this.CurrentSelectedRemainingMatchStage);

            // Remaining-Matches setzen
            this.RemainingMatchesView.DataSource = remainingMatchesForSingleStage.ToArray();
        }
        #endregion

        #region RefreshStandings
        /// <summary>
        /// Methode zum Aktualisieren der Tabelle.
        /// </summary>
        private void RefreshStandings()
        {
            // Service im ViewModel erzeugen lassen
            this.ChampionshipViewModel.SetLeagueAndSeason(this.CurrentSelectedLeague.name, this.CurrentSelectedSeason);

            // Tabelle ermitteln
            this.LeagueStandingEntries = this.ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage);

            // Die Tabelle binden
            this.StandingsView.DataSource = this.LeagueStandingEntries.ToArray();
        }
        #endregion

        #region GenerateRemainingMatchesViewColumns
        /// <summary>
        /// Methode zum Generieren der Spalten für das Grid mit den fehlenden Spielen.
        /// </summary>
        private void GenerateRemainingMatchesViewColumns()
        {
            // Die Spalten der DataGridView hinzufügen
            DataGridViewColumn homeColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "HomeTeamName",
                Name = "Home",
                ReadOnly = true,
                Width = 200
            };
            homeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            homeColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RemainingMatchesView.Columns.Add(homeColumn);

            DataGridViewColumn awayColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "AwayTeamName",
                Name = "Away",
                ReadOnly = true,
                Width = 200
            };
            awayColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            awayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RemainingMatchesView.Columns.Add(awayColumn);
        }
        #endregion

        #region GenerateStandingsViewColumns
        /// <summary>
        /// Methode zum Erstellen der Spalten der Tabelle.
        /// </summary>
        private void GenerateStandingsViewColumns()
        {
            // Die Spalten der DataGridView hinzufügen
            DataGridViewColumn positionColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Position",
                Name = "P",
                ReadOnly = true,
                Width = 20
            };
            positionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            positionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(positionColumn);

            DataGridViewColumn teamColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "TeamLongName",
                Name = "Team",
                ReadOnly = true,
                Width = 200
            };
            teamColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            teamColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(teamColumn);

            DataGridViewColumn gamesColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Games",
                Name = "G",
                Width = 20,
                ReadOnly = true
            };
            gamesColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gamesColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(gamesColumn);

            DataGridViewColumn winsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Wins",
                Name = "W",
                Width = 20,
                ReadOnly = true
            };
            winsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            winsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(winsColumn);

            DataGridViewColumn tiescolumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Ties",
                Name = "T",
                Width = 20,
                ReadOnly = true
            };
            tiescolumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tiescolumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(tiescolumn);

            DataGridViewColumn lossesColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Losses",
                Name = "L",
                Width = 20,
                ReadOnly = true
            };
            lossesColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            lossesColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(lossesColumn);

            DataGridViewColumn goalsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Goals",
                Name = "Goals",
                Width = 50,
                ReadOnly = true
            };
            goalsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(goalsColumn);

            DataGridViewColumn goalsConcededColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "GoalsConceded",
                Name = "Goals Conceded",
                Width = 70,
                ReadOnly = true
            };
            goalsConcededColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalsConcededColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(goalsConcededColumn);

            DataGridViewColumn goalDifferenceColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "GoalDifference",
                Name = "Goal Difference",
                Width = 70,
                ReadOnly = true
            };
            goalDifferenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalDifferenceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(goalDifferenceColumn);

            DataGridViewColumn pointsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Points",
                Name = "Points",
                Width = 50
            };
            pointsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pointsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(pointsColumn);

            DataGridViewColumn bestPossiblePositionColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "BestPossiblePosition",
                Name = "Best possible position",
                Width = 50
            };
            bestPossiblePositionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bestPossiblePositionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(bestPossiblePositionColumn);

            DataGridViewColumn worstPossiblePositionColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "WorstPossiblePosition",
                Name = "Worst possible position",
                Width = 50
            };
            worstPossiblePositionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            worstPossiblePositionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(worstPossiblePositionColumn);

            DataGridViewColumn canWinChampionshipColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "CanWinChampionship",
                Name = "Possible Champion",
                Width = 70
            };
            canWinChampionshipColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            canWinChampionshipColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(canWinChampionshipColumn);

            DataGridViewColumn computeBestColumn = new DataGridViewButtonColumn()
            {
                Name = "Compute best position",
                Text = "=>!",
                UseColumnTextForButtonValue = true,
                Width = 75
            };
            computeBestColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            computeBestColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(computeBestColumn);

            DataGridViewColumn computerWorstColumn = new DataGridViewButtonColumn()
            {
                Name = "Compute worst position",
                Text = "=>!",
                UseColumnTextForButtonValue = true,
                Width = 75
            };
            computerWorstColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            computerWorstColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(computerWorstColumn);

            DataGridViewColumn computeCanWinColumn = new DataGridViewButtonColumn()
            {
                Name = "Compute possible championship",
                Text = "=>!",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            computeCanWinColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            computeCanWinColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.StandingsView.Columns.Add(computeCanWinColumn);

            DataGridViewColumn lastElapsedTimeColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "LastElapsedTime",
                Name = "Last elapsed time in ms",
                Width = 60
            };
            lastElapsedTimeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            lastElapsedTimeColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            lastElapsedTimeColumn.DefaultCellStyle.Format = "0.000##";
            lastElapsedTimeColumn.ValueType = typeof(double);
            this.StandingsView.Columns.Add(lastElapsedTimeColumn);
        }
        #endregion

        #region GenerateComputationStandingView
        /// <summary>
        /// Methode zum Generieren der Spalten für das DataGrid mit dem Ergebnis der ausrechnung.
        /// </summary>
        private void GenerateComputationStandingView()
        {
            // Die Spalten der DataGridView hinzufügen
            DataGridViewColumn positionColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Position",
                Name = "P",
                ReadOnly = true,
                Width = 20
            };
            positionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            positionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputationStandingView.Columns.Add(positionColumn);

            DataGridViewColumn teamColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "TeamLongName",
                Name = "Team",
                ReadOnly = true,
                Width = 200
            };
            teamColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            teamColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputationStandingView.Columns.Add(teamColumn);

            DataGridViewColumn goalDifferenceColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "GoalDifference",
                Name = "Goal Difference",
                Width = 70,
                ReadOnly = true
            };
            goalDifferenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalDifferenceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputationStandingView.Columns.Add(goalDifferenceColumn);

            DataGridViewColumn pointsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Points",
                Name = "Points",
                Width = 50
            };
            pointsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pointsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputationStandingView.Columns.Add(pointsColumn);
        }
        #endregion

        #region StandingsView_CellFormatting
        /// <summary>
        /// Methode wird aufgerufen, wenn eine Zelle der StandingsView formatiert werden soll.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void StandingsView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Wenn es die Spalte ist, ob der Verein noch Meister werden kann, dann den bool-Value umrechnen
            if (e.ColumnIndex == this.StandingsView.Columns["Possible Champion"].Index)
            {
                if (e.Value is bool value)
                {
                    e.Value = (value) ? "Yes" : "No";
                    e.FormattingApplied = true;
                }
            }
        }
        #endregion
    }
}
