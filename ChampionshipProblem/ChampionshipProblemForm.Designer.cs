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
            this.ComputeResultCheckbox = new System.Windows.Forms.CheckBox();
            this.ComputedRemainingMatchComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComputedRemainingMatchesView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ComputedStandingComboBox = new System.Windows.Forms.ComboBox();
            this.Country = new System.Windows.Forms.Label();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.ResultGrid = new System.Windows.Forms.PropertyGrid();
            this.changeToWorldCubButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StandingsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemainingMatchesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComputationStandingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComputedRemainingMatchesView)).BeginInit();
            this.SuspendLayout();
            // 
            // LeagueComboBox
            // 
            this.LeagueComboBox.DropDownWidth = 250;
            this.LeagueComboBox.FormattingEnabled = true;
            this.LeagueComboBox.Location = new System.Drawing.Point(248, 13);
            this.LeagueComboBox.Name = "LeagueComboBox";
            this.LeagueComboBox.Size = new System.Drawing.Size(156, 21);
            this.LeagueComboBox.TabIndex = 0;
            this.LeagueComboBox.SelectedIndexChanged += new System.EventHandler(this.LeagueComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "League";
            // 
            // Spieltag
            // 
            this.Spieltag.AutoSize = true;
            this.Spieltag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Spieltag.Location = new System.Drawing.Point(592, 14);
            this.Spieltag.Name = "Spieltag";
            this.Spieltag.Size = new System.Drawing.Size(60, 15);
            this.Spieltag.TabIndex = 2;
            this.Spieltag.Text = "Matchday";
            // 
            // StageComboBox
            // 
            this.StageComboBox.FormattingEnabled = true;
            this.StageComboBox.Location = new System.Drawing.Point(658, 13);
            this.StageComboBox.Name = "StageComboBox";
            this.StageComboBox.Size = new System.Drawing.Size(42, 21);
            this.StageComboBox.TabIndex = 3;
            this.StageComboBox.SelectedIndexChanged += new System.EventHandler(this.StageComboBox_SelectedIndexChanged);
            // 
            // StandingsView
            // 
            this.StandingsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StandingsView.Location = new System.Drawing.Point(15, 39);
            this.StandingsView.Name = "StandingsView";
            this.StandingsView.Size = new System.Drawing.Size(1118, 487);
            this.StandingsView.TabIndex = 4;
            this.StandingsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StandingsView_CellClick);
            this.StandingsView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.StandingsView_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(410, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Season";
            // 
            // SeasonComboBox
            // 
            this.SeasonComboBox.FormattingEnabled = true;
            this.SeasonComboBox.Location = new System.Drawing.Point(465, 13);
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
            this.ComputationStandingView.Location = new System.Drawing.Point(14, 561);
            this.ComputationStandingView.Name = "ComputationStandingView";
            this.ComputationStandingView.Size = new System.Drawing.Size(503, 458);
            this.ComputationStandingView.TabIndex = 11;
            // 
            // ComputeResultCheckbox
            // 
            this.ComputeResultCheckbox.AutoSize = true;
            this.ComputeResultCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ComputeResultCheckbox.Location = new System.Drawing.Point(988, 12);
            this.ComputeResultCheckbox.Name = "ComputeResultCheckbox";
            this.ComputeResultCheckbox.Size = new System.Drawing.Size(139, 19);
            this.ComputeResultCheckbox.TabIndex = 12;
            this.ComputeResultCheckbox.Text = "Compute result table";
            this.ComputeResultCheckbox.UseVisualStyleBackColor = true;
            // 
            // ComputedRemainingMatchComboBox
            // 
            this.ComputedRemainingMatchComboBox.FormattingEnabled = true;
            this.ComputedRemainingMatchComboBox.Location = new System.Drawing.Point(756, 537);
            this.ComputedRemainingMatchComboBox.Name = "ComputedRemainingMatchComboBox";
            this.ComputedRemainingMatchComboBox.Size = new System.Drawing.Size(42, 21);
            this.ComputedRemainingMatchComboBox.TabIndex = 14;
            this.ComputedRemainingMatchComboBox.SelectedIndexChanged += new System.EventHandler(this.ComputedRemainingMatchComboxBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(544, 538);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Stage of computed remaining match";
            // 
            // ComputedRemainingMatchesView
            // 
            this.ComputedRemainingMatchesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComputedRemainingMatchesView.Location = new System.Drawing.Point(547, 561);
            this.ComputedRemainingMatchesView.Name = "ComputedRemainingMatchesView";
            this.ComputedRemainingMatchesView.Size = new System.Drawing.Size(435, 458);
            this.ComputedRemainingMatchesView.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(12, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Stage of computed standing";
            // 
            // ComputedStandingComboBox
            // 
            this.ComputedStandingComboBox.FormattingEnabled = true;
            this.ComputedStandingComboBox.Location = new System.Drawing.Point(178, 537);
            this.ComputedStandingComboBox.Name = "ComputedStandingComboBox";
            this.ComputedStandingComboBox.Size = new System.Drawing.Size(42, 21);
            this.ComputedStandingComboBox.TabIndex = 18;
            this.ComputedStandingComboBox.SelectedIndexChanged += new System.EventHandler(this.ComputedStandingComboBox_SelectedIndexChanged);
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Country.Location = new System.Drawing.Point(12, 14);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(48, 15);
            this.Country.TabIndex = 19;
            this.Country.Text = "Country";
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(66, 12);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CountryComboBox.TabIndex = 20;
            this.CountryComboBox.SelectedIndexChanged += new System.EventHandler(this.CountryComboBox_SelectedIndexChanged);
            // 
            // ResultGrid
            // 
            this.ResultGrid.Location = new System.Drawing.Point(1013, 561);
            this.ResultGrid.Name = "ResultGrid";
            this.ResultGrid.Size = new System.Drawing.Size(360, 458);
            this.ResultGrid.TabIndex = 21;
            // 
            // changeToWorldCubButton
            // 
            this.changeToWorldCubButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.changeToWorldCubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.changeToWorldCubButton.ForeColor = System.Drawing.SystemColors.Control;
            this.changeToWorldCubButton.Location = new System.Drawing.Point(1348, 10);
            this.changeToWorldCubButton.Name = "changeToWorldCubButton";
            this.changeToWorldCubButton.Size = new System.Drawing.Size(188, 23);
            this.changeToWorldCubButton.TabIndex = 22;
            this.changeToWorldCubButton.Text = "Change to World Cubs";
            this.changeToWorldCubButton.UseVisualStyleBackColor = false;
            this.changeToWorldCubButton.Click += new System.EventHandler(this.ChangeToWorldClubButton_Click);
            // 
            // ChampionshipProblemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1548, 1022);
            this.Controls.Add(this.changeToWorldCubButton);
            this.Controls.Add(this.ResultGrid);
            this.Controls.Add(this.CountryComboBox);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.ComputedStandingComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComputedRemainingMatchesView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComputedRemainingMatchComboBox);
            this.Controls.Add(this.ComputeResultCheckbox);
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
            ((System.ComponentModel.ISupportInitialize)(this.ComputedRemainingMatchesView)).EndInit();
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
        private System.Windows.Forms.CheckBox ComputeResultCheckbox;
        private System.Windows.Forms.ComboBox ComputedRemainingMatchComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ComputedRemainingMatchesView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComputedStandingComboBox;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.PropertyGrid ResultGrid;
        private System.Windows.Forms.Button changeToWorldCubButton;
    }
}

