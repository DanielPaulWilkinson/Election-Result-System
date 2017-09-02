namespace Election
{
    partial class FormBasedUI
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
            this.btnCon = new System.Windows.Forms.Button();
            this.btnCandidates = new System.Windows.Forms.Button();
            this.btnParty = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubText = new System.Windows.Forms.Label();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblTalk = new System.Windows.Forms.Label();
            this.BtnInstructions = new System.Windows.Forms.Button();
            this.btnElectedNmae = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstCans = new System.Windows.Forms.ListBox();
            this.lstResults1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCon
            // 
            this.btnCon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCon.Location = new System.Drawing.Point(12, 925);
            this.btnCon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(134, 119);
            this.btnCon.TabIndex = 0;
            this.btnCon.Text = "View Constituency and\r\nCandidate details";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnConstituencySelectable_Click);
            // 
            // btnCandidates
            // 
            this.btnCandidates.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCandidates.Location = new System.Drawing.Point(152, 925);
            this.btnCandidates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCandidates.Name = "btnCandidates";
            this.btnCandidates.Size = new System.Drawing.Size(134, 119);
            this.btnCandidates.TabIndex = 0;
            this.btnCandidates.Text = "Elected Candidates\r\nin each party";
            this.btnCandidates.UseVisualStyleBackColor = true;
            this.btnCandidates.Click += new System.EventHandler(this.btnCandidatesHighestVote_Click);
            // 
            // btnParty
            // 
            this.btnParty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnParty.Location = new System.Drawing.Point(430, 925);
            this.btnParty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnParty.Name = "btnParty";
            this.btnParty.Size = new System.Drawing.Size(134, 119);
            this.btnParty.TabIndex = 0;
            this.btnParty.Text = "All Parties and total votes";
            this.btnParty.UseVisualStyleBackColor = true;
            this.btnParty.Click += new System.EventHandler(this.btnAllPartyAndVotes_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(571, 925);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 119);
            this.button4.TabIndex = 0;
            this.button4.Text = "Election Winner";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnElectionWinner_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuit.Location = new System.Drawing.Point(711, 925);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(134, 119);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWelcome.Location = new System.Drawing.Point(588, 19);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(368, 58);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Election | Menu";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // lblSubText
            // 
            this.lblSubText.AutoSize = true;
            this.lblSubText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSubText.Location = new System.Drawing.Point(555, 88);
            this.lblSubText.Name = "lblSubText";
            this.lblSubText.Size = new System.Drawing.Size(453, 92);
            this.lblSubText.TabIndex = 1;
            this.lblSubText.Text = "Select the results would \r\nyou like to see see?";
            this.lblSubText.Click += new System.EventHandler(this.label1_Click);
            // 
            // lstResult
            // 
            this.lstResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 36;
            this.lstResult.Location = new System.Drawing.Point(12, 310);
            this.lstResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(977, 256);
            this.lstResult.TabIndex = 4;
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_SelectedIndexChanged);
            // 
            // lblProgress
            // 
            this.lblProgress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProgress.Location = new System.Drawing.Point(9, 26);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(375, 38);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "lblProgress";
            this.lblProgress.Click += new System.EventHandler(this.lblProgress_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReport.Location = new System.Drawing.Point(10, 64);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(0, 29);
            this.lblReport.TabIndex = 5;
            // 
            // lblTalk
            // 
            this.lblTalk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTalk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTalk.Location = new System.Drawing.Point(10, 24);
            this.lblTalk.Name = "lblTalk";
            this.lblTalk.Size = new System.Drawing.Size(504, 110);
            this.lblTalk.TabIndex = 7;
            this.lblTalk.Text = "Currently Viewing Candidates Within The constituency of:";
            this.lblTalk.Click += new System.EventHandler(this.lblTalk_Click);
            // 
            // BtnInstructions
            // 
            this.BtnInstructions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnInstructions.Location = new System.Drawing.Point(852, 925);
            this.BtnInstructions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnInstructions.Name = "BtnInstructions";
            this.BtnInstructions.Size = new System.Drawing.Size(137, 119);
            this.BtnInstructions.TabIndex = 9;
            this.BtnInstructions.Text = "Instructions";
            this.BtnInstructions.UseVisualStyleBackColor = true;
            this.BtnInstructions.Click += new System.EventHandler(this.BtnInstructions_Click);
            // 
            // btnElectedNmae
            // 
            this.btnElectedNmae.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnElectedNmae.Location = new System.Drawing.Point(290, 925);
            this.btnElectedNmae.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnElectedNmae.Name = "btnElectedNmae";
            this.btnElectedNmae.Size = new System.Drawing.Size(134, 119);
            this.btnElectedNmae.TabIndex = 10;
            this.btnElectedNmae.Text = "Elected Candidates in each Constituency";
            this.btnElectedNmae.UseVisualStyleBackColor = true;
            this.btnElectedNmae.Click += new System.EventHandler(this.btnElectedCandidateInConstituency_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTalk);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(521, 180);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort";
            this.groupBox1.Enter += new System.EventHandler(this.GroupSort_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblReport);
            this.groupBox2.Controls.Add(this.lblProgress);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(521, 109);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information:";
            this.groupBox2.Enter += new System.EventHandler(this.GroupInformation_Enter);
            // 
            // lstCans
            // 
            this.lstCans.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCans.FormattingEnabled = true;
            this.lstCans.ItemHeight = 36;
            this.lstCans.Location = new System.Drawing.Point(12, 585);
            this.lstCans.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstCans.Name = "lstCans";
            this.lstCans.Size = new System.Drawing.Size(977, 292);
            this.lstCans.TabIndex = 15;
            this.lstCans.SelectedIndexChanged += new System.EventHandler(this.lstCans_SelectedIndexChanged);
            // 
            // lstResults1
            // 
            this.lstResults1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults1.FormattingEnabled = true;
            this.lstResults1.ItemHeight = 36;
            this.lstResults1.Location = new System.Drawing.Point(12, 310);
            this.lstResults1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstResults1.Name = "lstResults1";
            this.lstResults1.Size = new System.Drawing.Size(977, 256);
            this.lstResults1.TabIndex = 16;
            this.lstResults1.SelectedIndexChanged += new System.EventHandler(this.lstResults1_SelectedIndexChanged);
            // 
            // FormBasedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1012, 1057);
            this.Controls.Add(this.lstResults1);
            this.Controls.Add(this.lstCans);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnElectedNmae);
            this.Controls.Add(this.BtnInstructions);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lblSubText);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnParty);
            this.Controls.Add(this.btnCandidates);
            this.Controls.Add(this.btnCon);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormBasedUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Election | Menu";
            this.Load += new System.EventHandler(this.FormBasedUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Button btnCandidates;
        private System.Windows.Forms.Button btnParty;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubText;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label lblTalk;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button BtnInstructions;
        private System.Windows.Forms.Button btnElectedNmae;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstCans;
        private System.Windows.Forms.ListBox lstResults1;
    }
}

