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

        public Form1(EuropeanSoccerEntities soccerDB)
        {
            // Komponenten initialisieren
            InitializeComponent();

            LeagueService leagueService = new LeagueService(soccerDB);
            this.SoccerDb = soccerDB;
            this.StagesComboBox = (ComboBox)this.Controls.Find("stageComboBox", false).First();
            this.SeasonComboBox = (ComboBox)this.Controls.Find("seasonComboBox", false).First();
            this.StandingsView = (DataGridView)this.Controls.Find("standingView", false).First();
            this.CurrentSelectedLeague = null;
            this.CurrentSelectedSeason = null;
            ComboBox leagueComboBox = (ComboBox)this.Controls.Find("leagueComboBox", false).First();

            List<League> leagues = leagueService.GetLeagues().ToList();
            leagueComboBox.DataSource = leagues;
            leagueComboBox.DisplayMember = "name";
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
            int stage = (int) StagesComboBox.SelectedValue;

            LeagueStandingService leagueStandingService = new LeagueStandingService(this.SoccerDb, this.CurrentSelectedLeague.name, this.CurrentSelectedSeason);

            IEnumerable<LeagueStandingEntry> leagueStandingEntries = leagueStandingService.CalculateStandingForLeague(stage);
        }

        private void seasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedSeason = (string)this.SeasonComboBox.SelectedValue;
        }
    }
}
