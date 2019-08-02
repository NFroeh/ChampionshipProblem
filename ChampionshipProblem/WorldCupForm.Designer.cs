namespace ChampionshipProblem
{
    partial class WorldCupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeToLeagueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ChangeToLeagueButton
            // 
            this.ChangeToLeagueButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ChangeToLeagueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ChangeToLeagueButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ChangeToLeagueButton.Location = new System.Drawing.Point(1338, 12);
            this.ChangeToLeagueButton.Name = "ChangeToLeagueButton";
            this.ChangeToLeagueButton.Size = new System.Drawing.Size(188, 23);
            this.ChangeToLeagueButton.TabIndex = 23;
            this.ChangeToLeagueButton.Text = "Change to Championships";
            this.ChangeToLeagueButton.UseVisualStyleBackColor = false;
            this.ChangeToLeagueButton.Click += new System.EventHandler(this.ChangeToLeagueButton_Click);
            // 
            // WorldCupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 1022);
            this.Controls.Add(this.ChangeToLeagueButton);
            this.Controls.Add(this.label1);
            this.Name = "WorldCupForm";
            this.Text = "WorldCupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChangeToLeagueButton;
    }
}