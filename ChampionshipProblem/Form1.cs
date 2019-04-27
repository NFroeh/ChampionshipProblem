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
        private DataGridView StandingsView;
        private League CurrentSelectedLeague;
        private string CurrentSelectedSeason;
        private int CurrentSelectedStage;

        public Form1(EuropeanSoccerEntities soccerDB)
        {
            // Komponenten initialisieren
            InitializeComponent();

            LeagueService leagueService = new LeagueService(soccerDB);
            this.SoccerDb = soccerDB;
            this.StagesComboBox = (ComboBox)this.Controls.Find("stageComboBox", false).First();
            this.SeasonComboBox = (ComboBox)this.Controls.Find("seasonComboBox", false).First();
            this.StandingsView = (DataGridView)this.Controls.Find("standingView", false).First();

            // Keine automatische Gernerierung der Spalten in der DataGridView
            StandingsView.AutoGenerateColumns = false;

            this.CurrentSelectedLeague = null;
            this.CurrentSelectedSeason = null;
            this.CurrentSelectedStage = 1;
            ComboBox leagueComboBox = (ComboBox)this.Controls.Find("leagueComboBox", false).First();

            // Die Ligen als Datengrundlage setzen
            List<League> leagues = leagueService.GetLeagues().ToList();
            leagueComboBox.DataSource = leagues;
            leagueComboBox.DisplayMember = "name";

            // Spalten des Grids generieren
            this.GenerateStandingsViewColumns();
        }

        private void leagueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox leagueCombox = (ComboBox)sender;
            this.CurrentSelectedLeague = (League)leagueComboBox.SelectedValue;

            MatchService matchService = new MatchService(this.SoccerDb);
            long stages = matchService.GetNumberOfMatches(this.CurrentSelectedLeague.id);

            StagesComboBox.DataSource = Enumerable.Range(1, (int)stages).ToArray();

            string[] seasons = matchService.GetSeasonsByLeagueId(this.CurrentSelectedLeague.id).ToArray();

            this.SeasonComboBox.DataSource = seasons;
        }

        private void stageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedStage = (int) StagesComboBox.SelectedValue;
            this.RefreshStandingsView();
        }

        private void seasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedSeason = (string)this.SeasonComboBox.SelectedValue;
            this.RefreshStandingsView();
        }

        private void RefreshStandingsView()
        {
            // Service erzeugen
            LeagueStandingService leagueStandingService = new LeagueStandingService(this.SoccerDb, this.CurrentSelectedLeague.name, this.CurrentSelectedSeason);

            //tabelle ermitteln
            IEnumerable<LeagueStandingEntry> leagueStandingEntries = leagueStandingService.CalculateStandingForLeague(this.CurrentSelectedStage);

            // Ergebnis setzen
            this.standingView.DataSource = leagueStandingEntries.ToArray();
        }

        /// <summary>
        /// Methode zum Erstellen der Spalten der Tabelle.
        /// </summary>
        private void GenerateStandingsViewColumns()
        {
            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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

            // Die Spalten der DataGridView hinzufügen
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
        }
    }
}
