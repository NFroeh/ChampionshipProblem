namespace ChampionshipProblem
{
    partial class Form1
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
            this.leagueComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Spieltag = new System.Windows.Forms.Label();
            this.stageComboBox = new System.Windows.Forms.ComboBox();
            this.standingView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.seasonComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.standingView)).BeginInit();
            this.SuspendLayout();
            // 
            // leagueComboBox
            // 
            this.leagueComboBox.DropDownWidth = 250;
            this.leagueComboBox.FormattingEnabled = true;
            this.leagueComboBox.Location = new System.Drawing.Point(63, 12);
            this.leagueComboBox.Name = "leagueComboBox";
            this.leagueComboBox.Size = new System.Drawing.Size(156, 21);
            this.leagueComboBox.TabIndex = 0;
            this.leagueComboBox.SelectedIndexChanged += new System.EventHandler(this.leagueComboBox_SelectedIndexChanged);
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
            // stageComboBox
            // 
            this.stageComboBox.FormattingEnabled = true;
            this.stageComboBox.Location = new System.Drawing.Point(473, 12);
            this.stageComboBox.Name = "stageComboBox";
            this.stageComboBox.Size = new System.Drawing.Size(42, 21);
            this.stageComboBox.TabIndex = 3;
            this.stageComboBox.SelectedIndexChanged += new System.EventHandler(this.stageComboBox_SelectedIndexChanged);
            // 
            // standingView
            // 
            this.standingView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.standingView.Location = new System.Drawing.Point(12, 67);
            this.standingView.Name = "standingView";
            this.standingView.Size = new System.Drawing.Size(644, 365);
            this.standingView.TabIndex = 4;
            this.standingView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.standingView_CellClick);
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
            // seasonComboBox
            // 
            this.seasonComboBox.FormattingEnabled = true;
            this.seasonComboBox.Location = new System.Drawing.Point(280, 12);
            this.seasonComboBox.Name = "seasonComboBox";
            this.seasonComboBox.Size = new System.Drawing.Size(121, 21);
            this.seasonComboBox.TabIndex = 6;
            this.seasonComboBox.SelectedIndexChanged += new System.EventHandler(this.seasonComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 489);
            this.Controls.Add(this.seasonComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.standingView);
            this.Controls.Add(this.stageComboBox);
            this.Controls.Add(this.Spieltag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leagueComboBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.standingView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox leagueComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Spieltag;
        private System.Windows.Forms.ComboBox stageComboBox;
        private System.Windows.Forms.DataGridView standingView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox seasonComboBox;
    }
}

