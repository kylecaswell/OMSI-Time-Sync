﻿namespace OMSI_Time_Sync
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tmrOMSI = new System.Windows.Forms.Timer(this.components);
            this.lblOmsiTime = new System.Windows.Forms.Label();
            this.lblSystemTime = new System.Windows.Forms.Label();
            this.lblHeaderOmsiTime = new System.Windows.Forms.Label();
            this.lblHeaderSystemTime = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnManualSyncOmsiTime = new System.Windows.Forms.Button();
            this.chkAutoSyncOmsiTime = new System.Windows.Forms.CheckBox();
            this.chkOnlyResyncOmsiTimeIfBehindActualTime = new System.Windows.Forms.CheckBox();
            this.lblHeaderOmsiOffsetHours = new System.Windows.Forms.Label();
            this.cmbOffsetHours = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbManualSyncHotkey = new System.Windows.Forms.ComboBox();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkDonate = new System.Windows.Forms.LinkLabel();
            this.lnkGithub = new System.Windows.Forms.LinkLabel();
            this.cmbAutoSyncMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOmsiTelemetryPluginStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrOMSI
            // 
            this.tmrOMSI.Interval = 1000;
            this.tmrOMSI.Tick += new System.EventHandler(this.tmrOMSI_Tick);
            // 
            // lblOmsiTime
            // 
            this.lblOmsiTime.AutoSize = true;
            this.lblOmsiTime.Location = new System.Drawing.Point(123, 9);
            this.lblOmsiTime.Name = "lblOmsiTime";
            this.lblOmsiTime.Size = new System.Drawing.Size(10, 13);
            this.lblOmsiTime.TabIndex = 0;
            this.lblOmsiTime.Text = "-";
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.AutoSize = true;
            this.lblSystemTime.Location = new System.Drawing.Point(123, 22);
            this.lblSystemTime.Name = "lblSystemTime";
            this.lblSystemTime.Size = new System.Drawing.Size(10, 13);
            this.lblSystemTime.TabIndex = 1;
            this.lblSystemTime.Text = "-";
            // 
            // lblHeaderOmsiTime
            // 
            this.lblHeaderOmsiTime.AutoSize = true;
            this.lblHeaderOmsiTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderOmsiTime.Location = new System.Drawing.Point(12, 9);
            this.lblHeaderOmsiTime.Name = "lblHeaderOmsiTime";
            this.lblHeaderOmsiTime.Size = new System.Drawing.Size(73, 13);
            this.lblHeaderOmsiTime.TabIndex = 2;
            this.lblHeaderOmsiTime.Text = "OMSI Time:";
            // 
            // lblHeaderSystemTime
            // 
            this.lblHeaderSystemTime.AutoSize = true;
            this.lblHeaderSystemTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSystemTime.Location = new System.Drawing.Point(12, 22);
            this.lblHeaderSystemTime.Name = "lblHeaderSystemTime";
            this.lblHeaderSystemTime.Size = new System.Drawing.Size(78, 13);
            this.lblHeaderSystemTime.TabIndex = 3;
            this.lblHeaderSystemTime.Text = "Actual Time:";
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::OMSI_Time_Sync.Properties.Resources.school_bus_1759;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(342, 9);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(143, 138);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // btnManualSyncOmsiTime
            // 
            this.btnManualSyncOmsiTime.Enabled = false;
            this.btnManualSyncOmsiTime.Location = new System.Drawing.Point(365, 125);
            this.btnManualSyncOmsiTime.Name = "btnManualSyncOmsiTime";
            this.btnManualSyncOmsiTime.Size = new System.Drawing.Size(97, 23);
            this.btnManualSyncOmsiTime.TabIndex = 5;
            this.btnManualSyncOmsiTime.Text = "Sync OMSI Time";
            this.btnManualSyncOmsiTime.UseVisualStyleBackColor = true;
            this.btnManualSyncOmsiTime.Click += new System.EventHandler(this.btnManualSyncOmsiTime_Click);
            // 
            // chkAutoSyncOmsiTime
            // 
            this.chkAutoSyncOmsiTime.AutoSize = true;
            this.chkAutoSyncOmsiTime.Checked = true;
            this.chkAutoSyncOmsiTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoSyncOmsiTime.Location = new System.Drawing.Point(12, 76);
            this.chkAutoSyncOmsiTime.Name = "chkAutoSyncOmsiTime";
            this.chkAutoSyncOmsiTime.Size = new System.Drawing.Size(261, 17);
            this.chkAutoSyncOmsiTime.TabIndex = 6;
            this.chkAutoSyncOmsiTime.Text = "Automatically keep the time in OMSI synchronised";
            this.chkAutoSyncOmsiTime.UseVisualStyleBackColor = true;
            this.chkAutoSyncOmsiTime.CheckedChanged += new System.EventHandler(this.chkAutoSyncOmsiTime_CheckedChanged);
            // 
            // chkOnlyResyncOmsiTimeIfBehindActualTime
            // 
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.AutoSize = true;
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.Checked = true;
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.Location = new System.Drawing.Point(12, 44);
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.Name = "chkOnlyResyncOmsiTimeIfBehindActualTime";
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.Size = new System.Drawing.Size(280, 17);
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.TabIndex = 7;
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.Text = "Only re-sync OMSI time if it falls behind the actual time";
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.UseVisualStyleBackColor = true;
            this.chkOnlyResyncOmsiTimeIfBehindActualTime.CheckedChanged += new System.EventHandler(this.chkOnlyResyncOmsiTimeIfBehindActualTime_CheckedChanged);
            // 
            // lblHeaderOmsiOffsetHours
            // 
            this.lblHeaderOmsiOffsetHours.AutoSize = true;
            this.lblHeaderOmsiOffsetHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderOmsiOffsetHours.Location = new System.Drawing.Point(12, 162);
            this.lblHeaderOmsiOffsetHours.Name = "lblHeaderOmsiOffsetHours";
            this.lblHeaderOmsiOffsetHours.Size = new System.Drawing.Size(167, 13);
            this.lblHeaderOmsiOffsetHours.TabIndex = 8;
            this.lblHeaderOmsiOffsetHours.Text = "Offset OMSI time by (hours):";
            // 
            // cmbOffsetHours
            // 
            this.cmbOffsetHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffsetHours.FormattingEnabled = true;
            this.cmbOffsetHours.Items.AddRange(new object[] {
            "-23",
            "-22",
            "-21",
            "-20",
            "-19",
            "-18",
            "-17",
            "-16",
            "-15",
            "-14",
            "-13",
            "-12",
            "-11",
            "-10",
            "-9",
            "-8",
            "-7",
            "-6",
            "-5",
            "-4",
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbOffsetHours.Location = new System.Drawing.Point(185, 159);
            this.cmbOffsetHours.Name = "cmbOffsetHours";
            this.cmbOffsetHours.Size = new System.Drawing.Size(151, 21);
            this.cmbOffsetHours.TabIndex = 9;
            this.cmbOffsetHours.SelectedIndexChanged += new System.EventHandler(this.cmbOffsetHours_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Manual Sync Hotkey:";
            // 
            // cmbManualSyncHotkey
            // 
            this.cmbManualSyncHotkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManualSyncHotkey.FormattingEnabled = true;
            this.cmbManualSyncHotkey.Location = new System.Drawing.Point(185, 186);
            this.cmbManualSyncHotkey.Name = "cmbManualSyncHotkey";
            this.cmbManualSyncHotkey.Size = new System.Drawing.Size(151, 21);
            this.cmbManualSyncHotkey.TabIndex = 11;
            this.cmbManualSyncHotkey.Visible = false;
            this.cmbManualSyncHotkey.SelectedIndexChanged += new System.EventHandler(this.cmbManualSyncHotkey_SelectedIndexChanged);
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(402, 190);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(92, 17);
            this.chkAlwaysOnTop.TabIndex = 12;
            this.chkAlwaysOnTop.Text = "Always on top";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "* If running BCS then it\'s advised to keep this enabled";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(363, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 39);
            this.label3.TabIndex = 14;
            this.label3.Text = "Version 1.00\r\nCreated by Ixel";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkDonate
            // 
            this.lnkDonate.AutoSize = true;
            this.lnkDonate.Location = new System.Drawing.Point(241, 214);
            this.lnkDonate.Name = "lnkDonate";
            this.lnkDonate.Size = new System.Drawing.Size(253, 13);
            this.lnkDonate.TabIndex = 15;
            this.lnkDonate.TabStop = true;
            this.lnkDonate.Text = "Like this program? Consider making a small donation";
            this.lnkDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDonate_LinkClicked);
            // 
            // lnkGithub
            // 
            this.lnkGithub.AutoSize = true;
            this.lnkGithub.Location = new System.Drawing.Point(12, 214);
            this.lnkGithub.Name = "lnkGithub";
            this.lnkGithub.Size = new System.Drawing.Size(38, 13);
            this.lnkGithub.TabIndex = 16;
            this.lnkGithub.TabStop = true;
            this.lnkGithub.Text = "Github";
            this.lnkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGithub_LinkClicked);
            // 
            // cmbAutoSyncMode
            // 
            this.cmbAutoSyncMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoSyncMode.FormattingEnabled = true;
            this.cmbAutoSyncMode.Items.AddRange(new object[] {
            "Always, every second",
            "(Plugin) When bus is moving",
            "(Plugin) When bus is not moving",
            "(Plugin) When bus has a timetable",
            "(Plugin) When bus has no timetable"});
            this.cmbAutoSyncMode.Location = new System.Drawing.Point(126, 132);
            this.cmbAutoSyncMode.Name = "cmbAutoSyncMode";
            this.cmbAutoSyncMode.Size = new System.Drawing.Size(210, 21);
            this.cmbAutoSyncMode.TabIndex = 17;
            this.cmbAutoSyncMode.SelectedIndexChanged += new System.EventHandler(this.cmbAutoSyncMode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Auto Sync Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "OMSI Telemetry Plugin:";
            // 
            // lblOmsiTelemetryPluginStatus
            // 
            this.lblOmsiTelemetryPluginStatus.AutoSize = true;
            this.lblOmsiTelemetryPluginStatus.Location = new System.Drawing.Point(185, 106);
            this.lblOmsiTelemetryPluginStatus.Name = "lblOmsiTelemetryPluginStatus";
            this.lblOmsiTelemetryPluginStatus.Size = new System.Drawing.Size(71, 13);
            this.lblOmsiTelemetryPluginStatus.TabIndex = 19;
            this.lblOmsiTelemetryPluginStatus.Text = "Not Detected";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 236);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblOmsiTelemetryPluginStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAutoSyncMode);
            this.Controls.Add(this.lnkGithub);
            this.Controls.Add(this.lnkDonate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkAlwaysOnTop);
            this.Controls.Add(this.cmbManualSyncHotkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOffsetHours);
            this.Controls.Add(this.lblHeaderOmsiOffsetHours);
            this.Controls.Add(this.chkOnlyResyncOmsiTimeIfBehindActualTime);
            this.Controls.Add(this.chkAutoSyncOmsiTime);
            this.Controls.Add(this.btnManualSyncOmsiTime);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblHeaderSystemTime);
            this.Controls.Add(this.lblHeaderOmsiTime);
            this.Controls.Add(this.lblSystemTime);
            this.Controls.Add(this.lblOmsiTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OMSI Time Sync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrOMSI;
        private System.Windows.Forms.Label lblOmsiTime;
        private System.Windows.Forms.Label lblSystemTime;
        private System.Windows.Forms.Label lblHeaderOmsiTime;
        private System.Windows.Forms.Label lblHeaderSystemTime;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnManualSyncOmsiTime;
        private System.Windows.Forms.CheckBox chkAutoSyncOmsiTime;
        private System.Windows.Forms.CheckBox chkOnlyResyncOmsiTimeIfBehindActualTime;
        private System.Windows.Forms.Label lblHeaderOmsiOffsetHours;
        private System.Windows.Forms.ComboBox cmbOffsetHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbManualSyncHotkey;
        private System.Windows.Forms.CheckBox chkAlwaysOnTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkDonate;
        private System.Windows.Forms.LinkLabel lnkGithub;
        private System.Windows.Forms.ComboBox cmbAutoSyncMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOmsiTelemetryPluginStatus;
    }
}

