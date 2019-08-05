

namespace ChampionshipProblem
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.WorldCup;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Klasse repräsentiert das Form zum Anzeigen der WorldCubs.
    /// </summary>
    public partial class WorldCupForm : Form
    {
        #region fields
        /// <summary>
        /// Die Daten.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel;

        /// <summary>
        /// Der aktuelle WorldCup.
        /// </summary>
        public WorldCup CurrentWorldCup;

        /// <summary>
        /// Der gerade ausgewählte Spieltag.
        /// </summary>
        public int CurrentSelectedStage;

        /// <summary>
        /// Der gerade ausgewählte fehlende Spieltag.
        /// </summary>
        public int CurrentSelectedRemainingMatchStage;

        /// <summary>
        /// Die Anzahl der Spiele.
        /// </summary>
        public int NumberOfStages;
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Forms.
        /// </summary>
        /// <param name="championshipViewModel">Die Daten.</param>
        public WorldCupForm(ChampionshipViewModel championshipViewModel)
        {
            InitializeComponent();

            this.ChampionshipViewModel = championshipViewModel;
            this.NumberOfStages = 0;
            this.CurrentSelectedStage = 0;
            this.CurrentSelectedRemainingMatchStage = 0;

            // Keine automatische Generierung der Spalten in der DataGridView
            GroupAView.AutoGenerateColumns = false;
            GroupBView.AutoGenerateColumns = false;
            GroupCView.AutoGenerateColumns = false;
            GroupDView.AutoGenerateColumns = false;
            GroupEView.AutoGenerateColumns = false;
            GroupFView.AutoGenerateColumns = false;
            GroupGView.AutoGenerateColumns = false;
            GroupHView.AutoGenerateColumns = false;
            RoundOf16View.AutoGenerateColumns = false;
            QuarterfinalView.AutoGenerateColumns = false;
            SemifinalView.AutoGenerateColumns = false;
            FinalView.AutoGenerateColumns = false;
            RemainingMatchesView.AutoGenerateColumns = false;

            // Die Selektorspalte ausblenden
            GroupAView.RowHeadersVisible = false;
            GroupBView.RowHeadersVisible = false;
            GroupCView.RowHeadersVisible = false;
            GroupDView.RowHeadersVisible = false;
            GroupEView.RowHeadersVisible = false;
            GroupFView.RowHeadersVisible = false;
            GroupGView.RowHeadersVisible = false;
            GroupHView.RowHeadersVisible = false;
            RoundOf16View.RowHeadersVisible = false;
            QuarterfinalView.RowHeadersVisible = false;
            SemifinalView.RowHeadersVisible = false;
            FinalView.RowHeadersVisible = false;
            RemainingMatchesView.RowHeadersVisible = false;

            this.WorldCupsComboBox.DisplayMember = "Name";
            this.WorldCupsComboBox.DataSource = championshipViewModel.WorldCups.ToArray();
            CurrentSelectedStage = 1;

            this.AddGroupsColumns();
            this.AddStageColumns();
            this.AddKOColumns();
        }
        #endregion

        #region ChangeToLeagueButton_Click
        /// <summary>
        /// Wird ausgeführt, wenn auf das andere Form gewechselt werden soll.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Das Event.</param>
        private void ChangeToLeagueButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ChampionshipProblemForm championshipProblemForm = new ChampionshipProblemForm(this.ChampionshipViewModel);
            championshipProblemForm.Show();
        }
        #endregion

        #region WorldCupsComboBox_SelectedValueChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn sich der Wert der ComboBox ändert.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Die Event-Argumente.</param>
        private void WorldCupsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CurrentWorldCup = (WorldCup)this.WorldCupsComboBox.SelectedValue;
            this.NumberOfStages = (int)this.ChampionshipViewModel.MatchService.GetNumberOfStages(this.CurrentWorldCup.Id);
            StageComboBox.DataSource = Enumerable.Range(1, this.NumberOfStages)
                .ToArray();
        }
        #endregion

        #region AddGroupsColumns
        /// <summary>
        /// Methode zum Hinzufügen der Gruppenspalten.
        /// </summary>
        public void AddGroupsColumns()
        {
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
            this.GroupAView.Columns.Add(positionColumn);
            this.GroupBView.Columns.Add((DataGridViewColumn)positionColumn.Clone());
            this.GroupCView.Columns.Add((DataGridViewColumn)positionColumn.Clone());
            this.GroupDView.Columns.Add((DataGridViewColumn)positionColumn.Clone());
            this.GroupEView.Columns.Add((DataGridViewColumn)positionColumn.Clone());
            this.GroupFView.Columns.Add((DataGridViewColumn)positionColumn.Clone());
            this.GroupGView.Columns.Add((DataGridViewColumn)positionColumn.Clone());
            this.GroupHView.Columns.Add((DataGridViewColumn)positionColumn.Clone());

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Name",
                Name = "Name",
                ReadOnly = true,
                Width = 120
            };
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GroupAView.Columns.Add(nameColumn);
            this.GroupBView.Columns.Add((DataGridViewColumn)nameColumn.Clone());
            this.GroupCView.Columns.Add((DataGridViewColumn)nameColumn.Clone());
            this.GroupDView.Columns.Add((DataGridViewColumn)nameColumn.Clone());
            this.GroupEView.Columns.Add((DataGridViewColumn)nameColumn.Clone());
            this.GroupFView.Columns.Add((DataGridViewColumn)nameColumn.Clone());
            this.GroupGView.Columns.Add((DataGridViewColumn)nameColumn.Clone());
            this.GroupHView.Columns.Add((DataGridViewColumn)nameColumn.Clone());

            DataGridViewColumn goalsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Goals",
                Name = "G",
                ReadOnly = true,
                Width = 50
            };
            goalsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GroupAView.Columns.Add(goalsColumn);
            this.GroupBView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());
            this.GroupCView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());
            this.GroupDView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());
            this.GroupEView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());
            this.GroupFView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());
            this.GroupGView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());
            this.GroupHView.Columns.Add((DataGridViewColumn)goalsColumn.Clone());

            DataGridViewColumn goalsConcededColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "GoalsConceded",
                Name = "GC",
                ReadOnly = true,
                Width = 50
            };
            goalsConcededColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalsConcededColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GroupAView.Columns.Add(goalsConcededColumn);
            this.GroupBView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());
            this.GroupCView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());
            this.GroupDView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());
            this.GroupEView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());
            this.GroupFView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());
            this.GroupGView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());
            this.GroupHView.Columns.Add((DataGridViewColumn)goalsConcededColumn.Clone());

            DataGridViewColumn goalDifferenceColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "GoalDifference",
                Name = "GD",
                ReadOnly = true,
                Width = 50
            };
            goalDifferenceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            goalDifferenceColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GroupAView.Columns.Add(goalDifferenceColumn);
            this.GroupBView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());
            this.GroupCView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());
            this.GroupDView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());
            this.GroupEView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());
            this.GroupFView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());
            this.GroupGView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());
            this.GroupHView.Columns.Add((DataGridViewColumn)goalDifferenceColumn.Clone());

            DataGridViewColumn pointsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "Points",
                Name = "Points",
                ReadOnly = true,
                Width = 50
            };
            pointsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pointsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.GroupAView.Columns.Add(pointsColumn);
            this.GroupBView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
            this.GroupCView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
            this.GroupDView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
            this.GroupEView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
            this.GroupFView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
            this.GroupGView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
            this.GroupHView.Columns.Add((DataGridViewColumn)pointsColumn.Clone());
        }
        #endregion

        #region AddStageColumns
        /// <summary>
        /// Methode zum Hinzufügen der Gruppenspalten.
        /// </summary>
        public void AddStageColumns()
        {
            // Die Spalten der DataGridView hinzufügen
            DataGridViewColumn homeColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "HomeTeamName",
                Name = "Home",
                ReadOnly = true,
                Width = 195
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
                Width = 195
            };
            awayColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            awayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RemainingMatchesView.Columns.Add(awayColumn);
        }
        #endregion

        #region AddKOColumns
        /// <summary>
        /// Führt die Spalten der K.O-Views hinzu.
        /// </summary>
        public void AddKOColumns()
        {
            // Die Spalten der DataGridView hinzufügen
            DataGridViewColumn homeColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "HomeTeamName",
                Name = "Home",
                ReadOnly = true,
                Width = 100
            };
            homeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            homeColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RoundOf16View.Columns.Add(homeColumn);
            this.QuarterfinalView.Columns.Add((DataGridViewColumn)homeColumn.Clone());
            this.SemifinalView.Columns.Add((DataGridViewColumn)homeColumn.Clone());
            this.FinalView.Columns.Add((DataGridViewColumn)homeColumn.Clone());

            DataGridViewColumn awayColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "AwayTeamName",
                Name = "Away",
                ReadOnly = true,
                Width = 100
            };
            awayColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            awayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RoundOf16View.Columns.Add(awayColumn);
            this.QuarterfinalView.Columns.Add((DataGridViewColumn)awayColumn.Clone());
            this.SemifinalView.Columns.Add((DataGridViewColumn)awayColumn.Clone());
            this.FinalView.Columns.Add((DataGridViewColumn)awayColumn.Clone());

            DataGridViewColumn homeGoalsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "HomeGoals",
                Name = "Home Goals",
                ReadOnly = true,
                Width = 50
            };
            homeGoalsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            homeGoalsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RoundOf16View.Columns.Add(homeGoalsColumn);
            this.QuarterfinalView.Columns.Add((DataGridViewColumn)homeGoalsColumn.Clone());
            this.SemifinalView.Columns.Add((DataGridViewColumn)homeGoalsColumn.Clone());
            this.FinalView.Columns.Add((DataGridViewColumn)homeGoalsColumn.Clone());

            DataGridViewColumn awayGoalsColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "AwayGoals",
                Name = "Away Goals",
                ReadOnly = true,
                Width = 50
            };
            awayGoalsColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            awayGoalsColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RoundOf16View.Columns.Add(awayGoalsColumn);
            this.QuarterfinalView.Columns.Add((DataGridViewColumn)awayGoalsColumn.Clone());
            this.SemifinalView.Columns.Add((DataGridViewColumn)awayGoalsColumn.Clone());
            this.FinalView.Columns.Add((DataGridViewColumn)awayGoalsColumn.Clone());

            DataGridViewColumn endOfGameStringColumn = new DataGridViewTextBoxColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = "MatchEndingString",
                Name = "Match Ending",
                ReadOnly = true,
                Width = 225
            };
            this.RoundOf16View.Columns.Add(endOfGameStringColumn);
            this.QuarterfinalView.Columns.Add((DataGridViewColumn)endOfGameStringColumn.Clone());
            this.SemifinalView.Columns.Add((DataGridViewColumn)endOfGameStringColumn.Clone());
            this.FinalView.Columns.Add((DataGridViewColumn)endOfGameStringColumn.Clone());
        }
        #endregion

        #region StageComboBox_SelectedValueChanged
        /// <summary>
        /// Wird ausgeführt, wenn die Stage geändert wird.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Das Event.</param>
        private void StageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedStage = (int)StageComboBox.SelectedValue;
            this.CurrentSelectedRemainingMatchStage = this.CurrentSelectedStage + 1;

            if (this.CurrentSelectedStage != this.NumberOfStages)
            {
                // Die neue RemainingStage-Range setzen
                IEnumerable<int> range = Enumerable.Range(CurrentSelectedRemainingMatchStage, this.NumberOfStages - this.CurrentSelectedStage);
                RemainingMatchComboBox.DataSource = range.ToArray();
            }
            else
            {
                RemainingMatchComboBox.DataSource = new int[] { this.NumberOfStages };
            }

            this.RefreshData();
        }
        #endregion

        #region RefreshData
        /// <summary>
        /// Methode aktualisiert die Daten.
        /// </summary>
        public void RefreshData()
        {
            ChampionshipViewModel.SetLeague(this.CurrentWorldCup.Id);

            // Ermittle die Zwischenstände
            this.GroupAView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupA);
            this.GroupBView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupB);
            this.GroupCView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupC);
            this.GroupDView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupD);
            this.GroupEView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupE);
            this.GroupFView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupF);
            this.GroupGView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupG);
            this.GroupHView.DataSource = ChampionshipViewModel.LeagueStandingService.CalculateCompleteStanding(this.CurrentSelectedStage, Classes.GroupStage.GroupH);
            this.RoundOf16View.DataSource = ChampionshipViewModel.MatchService.GetMatchesByWorldCupIdAndGroupStage(this.CurrentWorldCup.Id, Classes.GroupStage.RoundOf16).ToArray();
            this.QuarterfinalView.DataSource = ChampionshipViewModel.MatchService.GetMatchesByWorldCupIdAndGroupStage(this.CurrentWorldCup.Id, Classes.GroupStage.Quarterfinal).ToArray();
            this.SemifinalView.DataSource = ChampionshipViewModel.MatchService.GetMatchesByWorldCupIdAndGroupStage(this.CurrentWorldCup.Id, Classes.GroupStage.Semifinal).ToArray();
            this.FinalView.DataSource = ChampionshipViewModel.MatchService.GetMatchesByWorldCupIdAndGroupStage(this.CurrentWorldCup.Id, Classes.GroupStage.Final).ToArray();
        }
        #endregion

        #region RemainingMatchComboBox_SelectedIndexChanged
        /// <summary>
        /// Methode wird ausgeführt, wenn der Index der RemainingMatchComboBox geändert wurde.
        /// </summary>
        /// <param name="sender">Der Sender.</param>
        /// <param name="e">Das Event.</param>
        private void RemainingMatchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentSelectedRemainingMatchStage = (int)RemainingMatchComboBox.SelectedValue;
            IEnumerable<RemainingMatch> remainingMatchesForSingleStage = this.ChampionshipViewModel.MatchService.GetRemainingMatchesForSingleStage(this.CurrentWorldCup.Id, this.CurrentSelectedRemainingMatchStage);
            this.RemainingMatchesView.DataSource = remainingMatchesForSingleStage.ToArray();
        }
        #endregion
    }
}
