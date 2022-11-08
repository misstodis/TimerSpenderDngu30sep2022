using System.Windows.Forms;

namespace TimerSpenderDngu30sep2022
{
    partial class TimeSpenderDngu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSpenderDngu));
            this.cmbListTaskDngu = new System.Windows.Forms.ComboBox();
            this.rtbDoDngu = new System.Windows.Forms.RichTextBox();
            this.lblTitleDngu = new System.Windows.Forms.Label();
            this.btnSaveWorkDngu = new System.Windows.Forms.Button();
            this.btnShowDngu = new System.Windows.Forms.Button();
            this.ntfiDngu = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblTypingDoDngu = new System.Windows.Forms.Label();
            this.tmrToSpendDngu = new System.Windows.Forms.Timer(this.components);
            this.btnSettingDngu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbListTaskDngu
            // 
            this.cmbListTaskDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cmbListTaskDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbListTaskDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.cmbListTaskDngu.Location = new System.Drawing.Point(12, 154);
            this.cmbListTaskDngu.Name = "cmbListTaskDngu";
            this.cmbListTaskDngu.Size = new System.Drawing.Size(401, 24);
            this.cmbListTaskDngu.TabIndex = 1;
            this.cmbListTaskDngu.SelectedIndexChanged += new System.EventHandler(this.cmbListDoDngu_SelectedIndexChanged);
            // 
            // rtbDoDngu
            // 
            this.rtbDoDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rtbDoDngu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDoDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rtbDoDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.rtbDoDngu.Location = new System.Drawing.Point(12, 203);
            this.rtbDoDngu.Name = "rtbDoDngu";
            this.rtbDoDngu.Size = new System.Drawing.Size(401, 225);
            this.rtbDoDngu.TabIndex = 2;
            this.rtbDoDngu.Text = "";
            this.rtbDoDngu.TextChanged += new System.EventHandler(this.rtbDoDngu_TextChanged);
            // 
            // lblTitleDngu
            // 
            this.lblTitleDngu.AutoSize = true;
            this.lblTitleDngu.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitleDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTitleDngu.Location = new System.Drawing.Point(12, 70);
            this.lblTitleDngu.Name = "lblTitleDngu";
            this.lblTitleDngu.Size = new System.Drawing.Size(221, 30);
            this.lblTitleDngu.TabIndex = 3;
            this.lblTitleDngu.Text = "What\'re you doing ?";
            // 
            // btnSaveWorkDngu
            // 
            this.btnSaveWorkDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveWorkDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnSaveWorkDngu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSaveWorkDngu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnSaveWorkDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveWorkDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveWorkDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnSaveWorkDngu.Location = new System.Drawing.Point(12, 103);
            this.btnSaveWorkDngu.Name = "btnSaveWorkDngu";
            this.btnSaveWorkDngu.Size = new System.Drawing.Size(84, 45);
            this.btnSaveWorkDngu.TabIndex = 5;
            this.btnSaveWorkDngu.Text = "Save";
            this.btnSaveWorkDngu.UseVisualStyleBackColor = false;
            this.btnSaveWorkDngu.Click += new System.EventHandler(this.btnSaveWorkDngu_Click);
            // 
            // btnShowDngu
            // 
            this.btnShowDngu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnShowDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnShowDngu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnShowDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 12F, System.Drawing.FontStyle.Bold);
            this.btnShowDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnShowDngu.Location = new System.Drawing.Point(102, 103);
            this.btnShowDngu.Name = "btnShowDngu";
            this.btnShowDngu.Size = new System.Drawing.Size(84, 45);
            this.btnShowDngu.TabIndex = 6;
            this.btnShowDngu.Text = "Show";
            this.btnShowDngu.UseVisualStyleBackColor = false;
            this.btnShowDngu.Click += new System.EventHandler(this.btnShowDngu_Click);
            // 
            // ntfiDngu
            // 
            this.ntfiDngu.Text = "notifyIcon1";
            this.ntfiDngu.DoubleClick += new System.EventHandler(this.ntfiDngu_MouseDoubleClick);
            // 
            // lblTypingDoDngu
            // 
            this.lblTypingDoDngu.AutoSize = true;
            this.lblTypingDoDngu.BackColor = System.Drawing.Color.Transparent;
            this.lblTypingDoDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTypingDoDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTypingDoDngu.Location = new System.Drawing.Point(12, 181);
            this.lblTypingDoDngu.Name = "lblTypingDoDngu";
            this.lblTypingDoDngu.Size = new System.Drawing.Size(203, 19);
            this.lblTypingDoDngu.TabIndex = 8;
            this.lblTypingDoDngu.Text = "typing hier what you gonna do";
            // 
            // tmrToSpendDngu
            // 
            this.tmrToSpendDngu.Interval = 1000;
            this.tmrToSpendDngu.Tick += new System.EventHandler(this.timeToSpendDngu_Tick);
            // 
            // btnSettingDngu
            // 
            this.btnSettingDngu.BackColor = System.Drawing.Color.Transparent;
            this.btnSettingDngu.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnSettingDngu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSettingDngu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnSettingDngu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingDngu.Font = new System.Drawing.Font("BeaufortforLOL-Bold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSettingDngu.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnSettingDngu.Location = new System.Drawing.Point(0, 0);
            this.btnSettingDngu.Name = "btnSettingDngu";
            this.btnSettingDngu.Size = new System.Drawing.Size(74, 31);
            this.btnSettingDngu.TabIndex = 9;
            this.btnSettingDngu.Text = "Settings";
            this.btnSettingDngu.UseVisualStyleBackColor = false;
            this.btnSettingDngu.Click += new System.EventHandler(this.btnSettingDngu_Click);
            // 
            // TimeSpenderDngu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TimerSpenderDngu30sep2022.Properties.Resources.brackets_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(425, 440);
            this.Controls.Add(this.btnSettingDngu);
            this.Controls.Add(this.lblTypingDoDngu);
            this.Controls.Add(this.btnShowDngu);
            this.Controls.Add(this.btnSaveWorkDngu);
            this.Controls.Add(this.lblTitleDngu);
            this.Controls.Add(this.rtbDoDngu);
            this.Controls.Add(this.cmbListTaskDngu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeSpenderDngu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TimeSpenderDngu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbListTaskDngu;
        private RichTextBox rtbDoDngu;
        private Label lblTitleDngu;
        private Button btnSaveWorkDngu;
        private Button btnShowDngu;
        private NotifyIcon ntfiDngu;
        private Label lblTypingDoDngu;
        private System.Windows.Forms.Timer tmrToSpendDngu;
        private Button btnSettingDngu;
    }
}
