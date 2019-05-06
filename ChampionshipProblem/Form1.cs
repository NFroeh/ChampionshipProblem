using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ChampionshipProblem
{
    public partial class Form1 : Form
    {
        public EuropeanSoccerEntities SoccerDb;
        private ComboBox StagesComboBox;
        private ComboBox SeasonComboBox;
        private ComboBox RemainingMatchesComboBox;
        private DataGridView StandingsView;
        private DataGridView RemainingMatchesView;
        private League CurrentSelectedLeague;
        private string CurrentSelectedSeason;
        private int CurrentSelectedStage;
        private int CurrentSelectedRemainingMatchStage;
        private IEnumerable<LeagueStandingEntry> LeagueStandingEntries;
        private MatchService MatchService;
        private LeagueStandingService LeagueStandingService;
        private long NumberOfStages; 

        public Form1(EuropeanSoccerEntities soccerDB)
        {
            // Komponenten initialisieren
            InitializeComponent();

            LeagueService leagueService = new LeagueService(soccerDB);
            this.SoccerDb = soccerDB;
            this.StagesComboBox = (ComboBox)this.Controls.Find("stageComboBox", false).First();
            this.SeasonComboBox = (ComboBox)this.Controls.Find("seasonComboBox", false).First();
            this.RemainingMatchesComboBox = (ComboBox)this.Controls.Find("remainingMatchComboBox", false).First();
            this.StandingsView = (DataGridView)this.Controls.Find("standingView", false).First();
            this.RemainingMatchesView = (DataGridView)this.Controls.Find("remainingMatchesView", false).First();
            this.LeagueStandingEntries = new List<LeagueStandingEntry>();
            this.MatchService = new MatchService(soccerDB);
            this.LeagueStandingService = null;

            // Keine automatische Generierung der Spalten in der DataGridView
            this.StandingsView.AutoGenerateColumns = false;
            this.RemainingMatchesView.AutoGenerateColumns = false;

            // Die Selektorspalte ausblenden
            this.StandingsView.RowHeadersVisible = false;
            this.RemainingMatchesView.RowHeadersVisible = false;

            this.CurrentSelectedLeague = null;
            this.CurrentSelectedSeason = null;
            this.CurrentSelectedStage = 1;
            this.CurrentSelectedRemainingMatchStage = 2;
            this.NumberOfStages = 0;
            ComboBox leagueComboBox = (ComboBox)this.Controls.Find("leagueComboBox", false).First();

            // Die Ligen als Datengrundlage setzen
            List<League> leagues = leagueService.GetLeagues().ToList();
            leagueComboBox.DataSource = leagues;
            leagueComboBox.DisplayMember = "name";

            // Spalten des standingView generieren
            this.GenerateStandingsViewColumns();

            // Spalten des remainingMatchesView generieren
            this.GenerateRemainingMatchesViewColumns();
        }

        private void leagueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox leagueCombox = (ComboBox)sender;
            this.CurrentSelectedLeague = (League)leagueComboBox.SelectedValue;

            long stages = this.MatchService.GetNumberOfMatches(this.CurrentSelectedLeague.id);
            this.NumberOfStages = this.MatchService.GetNumberOfMatches(this.CurrentSelectedLeague.id);
            StagesComboBox.DataSource = Enumerable.Range(1, (int)stages).ToArray();
            RemainingMatchesComboBox.DataSource = Enumerable.Range(((int)this.CurrentSelectedStage + 1), (int)this.NumberOfStages).ToArray();
            
            string[] seasons = this.MatchService.GetSeasonsByLeagueId(this.CurrentSelectedLeague.id).ToArray();

            this.SeasonComboBox.DataSource = seasons;
        }

        private void stageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedStage = (int) StagesComboBox.SelectedValue;
            RemainingMatchesComboBox.DataSource = Enumerable.Range(((int)this.CurrentSelectedStage + 1), (int)this.NumberOfStages).ToArray();
            this.CurrentSelectedRemainingMatchStage = (this.CurrentSelectedStage + 1);
            this.RefreshView();
        }

        private void seasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedSeason = (string)this.SeasonComboBox.SelectedValue;
            this.RefreshView();
        }

        private void RefreshView()
        {
            // Service erzeugen
            this.LeagueStandingService = new LeagueStandingService(this.SoccerDb, this.CurrentSelectedLeague.name, this.CurrentSelectedSeason);

            // Tabelle ermitteln
            this.LeagueStandingEntries = this.LeagueStandingService.CalculateStanding(this.CurrentSelectedStage);

            // Fehlende Spiele ermitteln
            IEnumerable<RemainingMatch> remainingMatches = new MatchService(this.SoccerDb).GetRemainingMatches(this.CurrentSelectedLeague.id, this.CurrentSelectedSeason, this.CurrentSelectedStage);

            // Remaining-Matches setzen
            this.remainingMatchesView.DataSource = remainingMatches.Where((match) => match.Stage == this.CurrentSelectedRemainingMatchStage).ToArray();

            // Ergebnis LeagueStandingEntries
            this.standingView.DataSource = this.LeagueStandingEntries.ToArray();
        }

        #region GenerateRemainingMatchesViewColumns
        /// <summary>
        /// Methode zum Generieren der Spalten f�r das Grid mit den fehlenden Spielen.
        /// </summary>
        private void GenerateRemainingMatchesViewColumns()
        {
            // Die Spalten der DataGridView hinzuf�gen
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
            this.remainingMatchesView.Columns.Add(homeColumn);

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
            this.remainingMatchesView.Columns.Add(awayColumn);
        }
        #endregion

        #region GenerateStandingsViewColumns
        /// <summary>
        /// Methode zum Erstellen der Spalten der Tabelle.
        /// </summary>
        private void GenerateStandingsViewColumns()
        {
            // Die Spalten der DataGridView hinzuf�gen
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
            this.standingView.Columns.Add(positionColumn);

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
            this.standingView.Columns.Add(teamColumn);

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
            this.standingView.Columns.Add(gamesColumn);

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
            this.standingView.Columns.Add(winsColumn);

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
            this.standingView.Columns.Add(tiescolumn);

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
            this.standingView.Columns.Add(lossesColumn);

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
            this.standingView.Columns.Add(goalsColumn);

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
            this.standingView.Columns.Add(goalsConcededColumn);

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
            this.standingView.Columns.Add(goalDifferenceColumn);

            DataGridViewColumn pointsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Points",
                Name = "Points",
                Width = 50
            };
            pointsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pointsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(pointsColumn);

            DataGridViewColumn bestPossiblePositionColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "BestPossiblePosition",
                Name = "Best possible position",
                Width = 50
            };
            bestPossiblePositionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bestPossiblePositionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(bestPossiblePositionColumn);

            DataGridViewColumn worstPossiblePositionColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "WorstPossiblePosition",
                Name = "Worst possible position",
                Width = 50
            };
            worstPossiblePositionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            worstPossiblePositionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(worstPossiblePositionColumn);

            DataGridViewColumn canWinChampionshipColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "CanWinChampionship",
                Name = "Possible Champion",
                Width = 70
            };
            canWinChampionshipColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            canWinChampionshipColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(canWinChampionshipColumn);

            DataGridViewColumn computeBestColumn = new DataGridViewButtonColumn()
            {
                Name = "Compute best position",
                Text = "Compute best position",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            computeBestColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            computeBestColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(computeBestColumn);

            DataGridViewColumn computerWorstColumn = new DataGridViewButtonColumn()
            {
                Name = "Compute worst position",
                Text = "Compute worst position",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            computerWorstColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            computerWorstColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(computerWorstColumn);

            DataGridViewColumn computeCanWinColumn = new DataGridViewButtonColumn()
            {
                Name = "Compute possible championship",
                Text = "Compute possible championship",
                UseColumnTextForButtonValue = true,
                Width = 185
            };
            computeCanWinColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            computeCanWinColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.standingView.Columns.Add(computeCanWinColumn);
        }
        #endregion

        private void standingView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.StandingsView.Columns["Compute best position"].Index)
            {
                DataGridViewRow selectedRow = this.StandingsView.Rows[e.RowIndex];
                LeagueStandingEntry entry = (LeagueStandingEntry)selectedRow.DataBoundItem;

                entry.BestPossiblePosition = this.LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(this.CurrentSelectedStage, this.LeagueStandingEntries, entry.TeamApiId.Value);
                this.StandingsView.Refresh();
            }

            if (e.ColumnIndex == this.StandingsView.Columns["Compute worst position"].Index)
            {
                DataGridViewRow selectedRow = this.StandingsView.Rows[e.RowIndex];
                LeagueStandingEntry entry = (LeagueStandingEntry)selectedRow.DataBoundItem;

                entry.WorstPossiblePosition = this.LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(this.CurrentSelectedStage, this.LeagueStandingEntries, entry.TeamApiId.Value);
                this.StandingsView.Refresh();
            }

            if (e.ColumnIndex == this.StandingsView.Columns["Compute possible championship"].Index)
            {
                DataGridViewRow selectedRow = this.StandingsView.Rows[e.RowIndex];
                LeagueStandingEntry entry = (LeagueStandingEntry)selectedRow.DataBoundItem;

                // Ausrechnen
                entry.CanWinChampionship = this.LeagueStandingService.CalculateIfTeamCanWinChampionship(this.CurrentSelectedStage, this.LeagueStandingEntries, entry.TeamApiId.Value);
                this.StandingsView.Refresh();
            }
        }

        private void remainingMatchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedRemainingMatchStage = (int)this.RemainingMatchesComboBox.SelectedValue;
            this.RefreshView();
        }
    }
}
