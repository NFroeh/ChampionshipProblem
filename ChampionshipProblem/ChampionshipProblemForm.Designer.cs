namespace ChampionshipProblem
{
    partial class ChampionshipProblemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeagueComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Spieltag = new System.Windows.Forms.Label();
            this.StageComboBox = new System.Windows.Forms.ComboBox();
            this.StandingsView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.SeasonComboBox = new System.Windows.Forms.ComboBox();
            this.RemainingMatchesView = new System.Windows.Forms.DataGridView();
            this.remainingMatchesLabel = new System.Windows.Forms.Label();
            this.RemainingMatchComboBox = new System.Windows.Forms.ComboBox();
            this.ComputationStandingView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StandingsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainingMatchesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComputationStandingView)).BeginInit();
            this.SuspendLayout();
            // 
            // LeagueComboBox
            // 
            this.LeagueComboBox.DropDownWidth = 250;
            this.LeagueComboBox.FormattingEnabled = true;
            this.LeagueComboBox.Location = new System.Drawing.Point(63, 12);
            this.LeagueComboBox.Name = "LeagueComboBox";
            this.LeagueComboBox.Size = new System.Drawing.Size(156, 21);
            this.LeagueComboBox.TabIndex = 0;
            this.LeagueComboBox.SelectedIndexChanged += new System.EventHandler(this.LeagueComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "League";
            // 
            // Spieltag
            // 
            this.Spieltag.AutoSize = true;
            this.Spieltag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Spieltag.Location = new System.Drawing.Point(407, 13);
            this.Spieltag.Name = "Spieltag";
            this.Spieltag.Size = new System.Drawing.Size(60, 15);
            this.Spieltag.TabIndex = 2;
            this.Spieltag.Text = "Matchday";
            // 
            // StageComboBox
            // 
            this.StageComboBox.FormattingEnabled = true;
            this.StageComboBox.Location = new System.Drawing.Point(473, 12);
            this.StageComboBox.Name = "StageComboBox";
            this.StageComboBox.Size = new System.Drawing.Size(42, 21);
            this.StageComboBox.TabIndex = 3;
            this.StageComboBox.SelectedIndexChanged += new System.EventHandler(this.StageComboBox_SelectedIndexChanged);
            // 
            // StandingsView
            // 
            this.StandingsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StandingsView.Location = new System.Drawing.Point(12, 39);
            this.StandingsView.Name = "StandingsView";
            this.StandingsView.Size = new System.Drawing.Size(1118, 514);
            this.StandingsView.TabIndex = 4;
            this.StandingsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StandingsView_CellClick);
            this.StandingsView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.StandingsView_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Season";
            // 
            // SeasonComboBox
            // 
            this.SeasonComboBox.FormattingEnabled = true;
            this.SeasonComboBox.Location = new System.Drawing.Point(280, 12);
            this.SeasonComboBox.Name = "SeasonComboBox";
            this.SeasonComboBox.Size = new System.Drawing.Size(121, 21);
            this.SeasonComboBox.TabIndex = 6;
            this.SeasonComboBox.SelectedIndexChanged += new System.EventHandler(this.SeasonComboBox_SelectedIndexChanged);
            // 
            // RemainingMatchesView
            // 
            this.RemainingMatchesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RemainingMatchesView.Location = new System.Drawing.Point(1136, 39);
            this.RemainingMatchesView.Name = "RemainingMatchesView";
            this.RemainingMatchesView.Size = new System.Drawing.Size(400, 448);
            this.RemainingMatchesView.TabIndex = 7;
            // 
            // remainingMatchesLabel
            // 
            this.remainingMatchesLabel.AutoSize = true;
            this.remainingMatchesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.remainingMatchesLabel.Location = new System.Drawing.Point(1133, 13);
            this.remainingMatchesLabel.Name = "remainingMatchesLabel";
            this.remainingMatchesLabel.Size = new System.Drawing.Size(161, 15);
            this.remainingMatchesLabel.TabIndex = 8;
            this.remainingMatchesLabel.Text = "Stage of remaining matches";
            // 
            // RemainingMatchComboBox
            // 
            this.RemainingMatchComboBox.FormattingEnabled = true;
            this.RemainingMatchComboBox.Location = new System.Drawing.Point(1300, 13);
            this.RemainingMatchComboBox.Name = "RemainingMatchComboBox";
            this.RemainingMatchComboBox.Size = new System.Drawing.Size(42, 21);
            this.RemainingMatchComboBox.TabIndex = 10;
            this.RemainingMatchComboBox.SelectedIndexChanged += new System.EventHandler(this.RemainingMatchComboBox_SelectedIndexChanged);
            // 
            // ComputationStandingView
            // 
            this.ComputationStandingView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComputationStandingView.Location = new System.Drawing.Point(13, 592);
            this.ComputationStandingView.Name = "ComputationStandingView";
            this.ComputationStandingView.Size = new System.Drawing.Size(1116, 458);
            this.ComputationStandingView.TabIndex = 11;
            // 
            // ChampionshipProblemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 1061);
            this.Controls.Add(this.ComputationStandingView);
            this.Controls.Add(this.RemainingMatchComboBox);
            this.Controls.Add(this.remainingMatchesLabel);
            this.Controls.Add(this.RemainingMatchesView);
            this.Controls.Add(this.SeasonComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StandingsView);
            this.Controls.Add(this.StageComboBox);
            this.Controls.Add(this.Spieltag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LeagueComboBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChampionshipProblemForm";
            this.Text = "ChampionshipProblemForm";
            ((System.ComponentModel.ISupportInitialize)(this.StandingsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainingMatchesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComputationStandingView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox LeagueComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Spieltag;
        private System.Windows.Forms.ComboBox StageComboBox;
        private System.Windows.Forms.DataGridView StandingsView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SeasonComboBox;
        private System.Windows.Forms.DataGridView RemainingMatchesView;
        private System.Windows.Forms.Label remainingMatchesLabel;
        private System.Windows.Forms.ComboBox RemainingMatchComboBox;
        private System.Windows.Forms.DataGridView ComputationStandingView;
    }
}

