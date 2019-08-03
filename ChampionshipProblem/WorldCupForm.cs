

namespace ChampionshipProblem
{
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
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Forms.
        /// </summary>
        /// <param name="championshipViewModel">Die Daten.</param>
        public WorldCupForm(ChampionshipViewModel championshipViewModel)
        {
            this.ChampionshipViewModel = championshipViewModel;
            InitializeComponent();
            this.WorldCupsComboBox.DisplayMember = "Name";
            this.WorldCupsComboBox.DataSource = championshipViewModel.WorldCups.ToArray();
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
            this.CurrentWorldCup = (WorldCup) this.WorldCupsComboBox.SelectedValue;
        }
        #endregion
    }
}
