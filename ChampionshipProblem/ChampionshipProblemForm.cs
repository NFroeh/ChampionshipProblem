
namespace ChampionshipProblem
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.ResultClasses;
    using ChampionshipProblem.Services;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;

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
        /// Das aktuelle Land.
        /// </summary>
        private Country CurrentSelectedCountry;

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
        /// Der aktuell ausgewählte verbleibende Spieltag, welcher berechnet wurde.
        /// </summary>
        private int CurrentSelectedComputedRemainingMatchStage;

        /// <summary>
        /// Aktuell ausgewählter Spieltag zur berechneten Tabelle.
        /// </summary>
        private int CurrentSelectedComputedStanding;

        /// <summary>
        /// Die aktuelle Tabelle.
        /// </summary>
        private IEnumerable<CompleteLeagueStandingEntry> LeagueStandingEntries;

        /// <summary>
        /// Die Anzahl der aktuellen Spieltage.
        /// </summary>
        private int NumberOfStages;

        /// <summary>
        /// Das aktuell ausgerechnete Ergebnis.
        /// </summary>
        private ChampionComputationalResult CurrentChampionComputationalResult;
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
            ComputedRemainingMatchesView.AutoGenerateColumns = false;

            // Die Selektorspalte ausblenden
            StandingsView.RowHeadersVisible = false;
            RemainingMatchesView.RowHeadersVisible = false;
            ComputationStandingView.RowHeadersVisible = false;
            ComputedRemainingMatchesView.RowHeadersVisible = false;

            // Deaktivieren von Sachen im ResultGrid
            ResultGrid.ToolbarVisible = false;

            // Checkboxen checked setzen
            ComputeResultCheckbox.Checked = true;

            // Die Länder als Datengrundlage setzen
            CountryComboBox.DataSource = Enum.GetNames(typeof(Country));

            // Die Ligen als Datengrundlage setzen
            List<League> leagues = championshipViewModel
                .LeagueService
                .GetLeagues()
                .Where((league) => league.Country == Classes.Country.Belgium)
                .ToList();
            LeagueComboBox.DataSource = leagues;
            LeagueComboBox.DisplayMember = "name";

            // Spalten des standingView generieren
            this.GenerateStandingsViewColumns();

            // Spalten des remainingMatchesView generieren
            this.GenerateRemainingMatchesViewColumns();

            // Spalten des computedRemainingMatchesView generieren
            this.GenerateComputedRemainingMatchesViewColumns();

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
            string[] seasons = this.ChampionshipViewModel.MatchService.GetSeasonsByLeagueId(this.CurrentSelectedLeague.Id).ToArray();
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
            this.NumberOfStages = (int)this.ChampionshipViewModel.MatchService.GetNumberOfStages(this.CurrentSelectedLeague.Id, this.CurrentSelectedSeason);
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
                IEnumerable<int> range = Enumerable.Range(this.CurrentSelectedStage + 1, this.NumberOfStages - this.CurrentSelectedStage);
                RemainingMatchComboBox.DataSource = range.ToArray();
                ComputedRemainingMatchComboBox.DataSource = range.ToArray();
                ComputedStandingComboBox.DataSource = range.ToArray();
            }
            else
            {
                RemainingMatchComboBox.DataSource = new int[]{ this.NumberOfStages };
                ComputedRemainingMatchComboBox.DataSource = new int[] { this.NumberOfStages };
                ComputedStandingComboBox.DataSource = new int[] { this.NumberOfStages };
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
                int remainingMatchesCount = this.ChampionshipViewModel.LeagueStandingService.CalculateNumberOfRemainingMatchesForBestPossiblePosition(this.CurrentSelectedStage, entry.TeamId);
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
                        PositionComputationalResult positionComputationalResult = this.ChampionshipViewModel.LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamId, true);
                        entry.BestPossiblePosition = positionComputationalResult.Position;
                        ComputationStandingView.DataSource = (positionComputationalResult.ComputationalStanding != null)? positionComputationalResult.ComputationalStanding.ToArray() : null;
                        stopwatch.Stop();
                    }
                    else
                    {
                        entry.BestPossiblePosition = this.ChampionshipViewModel.LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamId, false).Position;
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
                int remainingMatchesCount = this.ChampionshipViewModel.LeagueStandingService.CalculateNumberOfRemainingMatchesForWorstPossiblePosition(this.CurrentSelectedStage, entry.TeamId);
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
                        PositionComputationalResult positionComputationalResult = this.ChampionshipViewModel.LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamId, true);
                        entry.WorstPossiblePosition = positionComputationalResult.Position;
                        ComputationStandingView.DataSource = (positionComputationalResult.ComputationalStanding != null) ? positionComputationalResult.ComputationalStanding.ToArray() : null;
                        stopwatch.Stop();
                    }
                    else
                    {
                        entry.WorstPossiblePosition = this.ChampionshipViewModel.LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(this.CurrentSelectedStage, entry.TeamId, false).Position;
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

                // Ausrechnen
                Stopwatch stopwatch = Stopwatch.StartNew();

                if (ComputeResultCheckbox.Checked)
                {
                    ChampionComputationalResult championComputationalResult = this.ChampionshipViewModel.LeagueStandingService.CalculateIfTeamCanWinChampionship(this.CurrentSelectedStage, entry.TeamId, true);
                    stopwatch.Stop();
                    entry.CanWinChampionship = championComputationalResult.CanWinChampionship;
                    if (championComputationalResult.CanWinChampionship.HasValue && championComputationalResult.CanWinChampionship == true)
                    {
                        // Das Result abspeichern
                        CurrentChampionComputationalResult = championComputationalResult;

                        // Die Datengrundlagen setzen
                        ComputationStandingView.DataSource = (championComputationalResult.ComputationalStanding != null)? championComputationalResult.ComputationalStanding.ToArray() : null;
                        ComputedRemainingMatchesView.DataSource = (championComputationalResult.MissingRemainingMatches != null)? championComputationalResult.MissingRemainingMatches.ToArray() : null;
                        ResultGrid.SelectedObject = championComputationalResult;

                        // Die Änderung signalisieren
                        this.ComputedStandingComboBox.SelectedItem = this.NumberOfStages;
                        this.ComputedStandingComboBox_SelectedIndexChanged(null, null);
                        this.ComputedRemainingMatchComboxBox_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        ComputationStandingView.DataSource = new string[0];
                    }
                }
                else
                {
                    entry.CanWinChampionship = this.ChampionshipViewModel.LeagueStandingService.CalculateIfTeamCanWinChampionship(this.CurrentSelectedStage, entry.TeamId, false).CanWinChampionship;
                    stopwatch.Stop();
                }

                entry.LastElapsedTime = (double)stopwatch.ElapsedMilliseconds / 1000;
                this.StandingsView.Refresh();
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
            IEnumerable<RemainingMatch> remainingMatchesForSingleStage = this.ChampionshipViewModel.MatchService.GetRemainingMatchesForSingleStage(this.CurrentSelectedLeague.Id, this.CurrentSelectedSeason, this.CurrentSelectedRemainingMatchStage);

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
            this.ChampionshipViewModel.SetLeagueCountryAndSeason(this.CurrentSelectedCountry, this.CurrentSelectedLeague.Name, this.CurrentSelectedSeason);

            // Tabelle ermitteln
            this.LeagueStandingEntries = this.ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage);

            // Die Tabelle binden
            this.StandingsView.DataSource = this.LeagueStandingEntries.ToArray();
            this.ComputationStandingView.DataSource = Enumerable.Empty<int>();
            this.ComputedRemainingMatchesView.DataSource = Enumerable.Empty<int>();
            this.CurrentChampionComputationalResult = null;
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

        #region GenerateComputedRemainingMatchesViewColumns
        /// <summary>
        /// Methode zum Generieren der Spalten für die berechneten fehlenden Spiele.
        /// </summary>
        private void GenerateComputedRemainingMatchesViewColumns()
        {
            // Die Spalten der DataGridView hinzufügen
            DataGridViewColumn homeColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "HomeTeamName",
                Name = "Home",
                ReadOnly = true,
                Width = 150
            };
            homeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            homeColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputedRemainingMatchesView.Columns.Add(homeColumn);

            DataGridViewColumn awayColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "AwayTeamName",
                Name = "Away",
                ReadOnly = true,
                Width = 150
            };
            awayColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            awayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ComputedRemainingMatchesView.Columns.Add(awayColumn);

            DataGridViewColumn resultColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "MatchResult",
                Name = "Result",
                ReadOnly = true,
                Width = 80
            };
            resultColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            resultColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ComputedRemainingMatchesView.Columns.Add(resultColumn);
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
                DataPropertyName = "Name",
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
                DataPropertyName = "Name",
                Name = "Team",
                ReadOnly = true,
                Width = 200
            };
            teamColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            teamColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputationStandingView.Columns.Add(teamColumn);

            DataGridViewColumn gamesColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Games",
                Name = "Games",
                ReadOnly = true,
                Width = 50
            };
            gamesColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gamesColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ComputationStandingView.Columns.Add(gamesColumn);

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

        #region ComputedRemainingMatchComboxBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn die ComputedRemainingMatchComboxBox geändert wird.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void ComputedRemainingMatchComboxBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Neuer Parameter holen
            this.CurrentSelectedComputedRemainingMatchStage = (int)ComputedRemainingMatchComboBox.SelectedValue;

            if (CurrentChampionComputationalResult != null && CurrentChampionComputationalResult.MissingRemainingMatches != null)
            {
                // Fehlende Spiele ermitteln
                IEnumerable<RemainingMatch> remainingMatchesForSingleStage = CurrentChampionComputationalResult
                    .MissingRemainingMatches
                    .Where((match) => match.Stage == this.CurrentSelectedComputedRemainingMatchStage);
                
                // Remaining-Matches setzen
                this.ComputedRemainingMatchesView.DataSource = remainingMatchesForSingleStage.ToArray();
            }
        }
        #endregion

        #region ComputedStandingComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn die ComputedStandingComboBox geändert wird.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Argumente.</param>
        private void ComputedStandingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedComputedStanding = (int)ComputedStandingComboBox.SelectedValue;
            this.ComputedRemainingMatchComboBox.SelectedIndex = this.ComputedStandingComboBox.SelectedIndex;
            ComputedRemainingMatchComboxBox_SelectedIndexChanged(null, null);

            if (CurrentChampionComputationalResult != null && CurrentChampionComputationalResult.ComputationalStanding != null && CurrentChampionComputationalResult.ComputationalStanding.Count != 0 && CurrentChampionComputationalResult.CanWinChampionship == true)
            {
                // Fehlende Spiele ermitteln
                IEnumerable<RemainingMatch> remainingMatchesForSingleStage = CurrentChampionComputationalResult
                    .MissingRemainingMatches
                    .Where((match) => match.Stage <= this.CurrentSelectedComputedStanding);
                this.ComputationStandingView.DataSource = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(LeagueStandingEntries, remainingMatchesForSingleStage).ToArray();
            }
        }
        #endregion

        #region CountryComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn sich das Land geändert hat.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Das Event.</param>
        private void CountryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedCountry = (Country) Enum.Parse(typeof(Country), CountryComboBox.SelectedValue.ToString());
            this.LeagueComboBox.DataSource = this.ChampionshipViewModel
                .LeagueService
                .GetLeagues()
                .Where((league) => league.Country == this.CurrentSelectedCountry)
                .ToList();
            this.RefreshStandings();
        }
        #endregion

        #region ChangeToWorldClubButton_Click
        /// <summary>
        /// Wird ausgeführt, wenn auf das andere Form gewechselt werden soll.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Das Event.</param>
        private void ChangeToWorldClubButton_Click(object sender, EventArgs e)
        {
            this.Close();
            WorldCupForm worldCupForm = new WorldCupForm(this.ChampionshipViewModel);
            worldCupForm.Show();
        }
        #endregion
    }
}
