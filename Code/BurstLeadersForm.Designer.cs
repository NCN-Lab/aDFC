
namespace OnlineSpikeDetection
{
    partial class BurstLeadersForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nLeaders = new System.Windows.Forms.TextBox();
            this.txt_onsetWindow_s = new System.Windows.Forms.TextBox();
            this.btn_set_nLeaders = new System.Windows.Forms.Button();
            this.btn_set_onsetWindow = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_plot_leaders = new System.Windows.Forms.Button();
            this.check_auto_plot = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_update_interval_s = new System.Windows.Forms.TextBox();
            this.set_interval = new System.Windows.Forms.Button();
            this.panel_lastLeaders = new System.Windows.Forms.Panel();
            this.panel_history = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_colorbar_nLeader = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_nOnsets = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.check_plotLastBurst = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Burst Leaders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "N Leaders per Burst";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Onset Window [s]";
            // 
            // txt_nLeaders
            // 
            this.txt_nLeaders.Location = new System.Drawing.Point(274, 27);
            this.txt_nLeaders.Name = "txt_nLeaders";
            this.txt_nLeaders.Size = new System.Drawing.Size(50, 20);
            this.txt_nLeaders.TabIndex = 3;
            // 
            // txt_onsetWindow_s
            // 
            this.txt_onsetWindow_s.Location = new System.Drawing.Point(274, 51);
            this.txt_onsetWindow_s.Name = "txt_onsetWindow_s";
            this.txt_onsetWindow_s.Size = new System.Drawing.Size(50, 20);
            this.txt_onsetWindow_s.TabIndex = 4;
            // 
            // btn_set_nLeaders
            // 
            this.btn_set_nLeaders.Location = new System.Drawing.Point(326, 26);
            this.btn_set_nLeaders.Name = "btn_set_nLeaders";
            this.btn_set_nLeaders.Size = new System.Drawing.Size(32, 23);
            this.btn_set_nLeaders.TabIndex = 5;
            this.btn_set_nLeaders.Text = "set";
            this.btn_set_nLeaders.UseVisualStyleBackColor = true;
            this.btn_set_nLeaders.Click += new System.EventHandler(this.btn_set_nLeaders_Click);
            // 
            // btn_set_onsetWindow
            // 
            this.btn_set_onsetWindow.Location = new System.Drawing.Point(326, 50);
            this.btn_set_onsetWindow.Name = "btn_set_onsetWindow";
            this.btn_set_onsetWindow.Size = new System.Drawing.Size(32, 23);
            this.btn_set_onsetWindow.TabIndex = 6;
            this.btn_set_onsetWindow.Text = "set";
            this.btn_set_onsetWindow.UseVisualStyleBackColor = true;
            this.btn_set_onsetWindow.Click += new System.EventHandler(this.btn_set_onsetWindow_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(667, 52);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(67, 25);
            this.btn_reset.TabIndex = 7;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_plot_leaders
            // 
            this.btn_plot_leaders.Location = new System.Drawing.Point(374, 49);
            this.btn_plot_leaders.Name = "btn_plot_leaders";
            this.btn_plot_leaders.Size = new System.Drawing.Size(103, 24);
            this.btn_plot_leaders.TabIndex = 8;
            this.btn_plot_leaders.Text = "Plot Now";
            this.btn_plot_leaders.UseVisualStyleBackColor = true;
            this.btn_plot_leaders.Click += new System.EventHandler(this.btn_plot_leaders_Click);
            // 
            // check_auto_plot
            // 
            this.check_auto_plot.AutoSize = true;
            this.check_auto_plot.Location = new System.Drawing.Point(495, 12);
            this.check_auto_plot.Name = "check_auto_plot";
            this.check_auto_plot.Size = new System.Drawing.Size(86, 17);
            this.check_auto_plot.TabIndex = 9;
            this.check_auto_plot.Text = "Auto Update";
            this.check_auto_plot.UseVisualStyleBackColor = true;
            this.check_auto_plot.CheckedChanged += new System.EventHandler(this.check_auto_plot_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "interval [s]";
            // 
            // txt_update_interval_s
            // 
            this.txt_update_interval_s.Location = new System.Drawing.Point(495, 52);
            this.txt_update_interval_s.Name = "txt_update_interval_s";
            this.txt_update_interval_s.Size = new System.Drawing.Size(23, 20);
            this.txt_update_interval_s.TabIndex = 11;
            // 
            // set_interval
            // 
            this.set_interval.Location = new System.Drawing.Point(519, 51);
            this.set_interval.Name = "set_interval";
            this.set_interval.Size = new System.Drawing.Size(39, 23);
            this.set_interval.TabIndex = 12;
            this.set_interval.Text = "set";
            this.set_interval.UseVisualStyleBackColor = true;
            this.set_interval.Click += new System.EventHandler(this.set_interval_Click);
            // 
            // panel_lastLeaders
            // 
            this.panel_lastLeaders.Location = new System.Drawing.Point(27, 129);
            this.panel_lastLeaders.Name = "panel_lastLeaders";
            this.panel_lastLeaders.Size = new System.Drawing.Size(35, 497);
            this.panel_lastLeaders.TabIndex = 14;
            // 
            // panel_history
            // 
            this.panel_history.Location = new System.Drawing.Point(695, 129);
            this.panel_history.Name = "panel_history";
            this.panel_history.Size = new System.Drawing.Size(35, 497);
            this.panel_history.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "#1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Last Burst";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Rank";
            // 
            // txt_colorbar_nLeader
            // 
            this.txt_colorbar_nLeader.AutoSize = true;
            this.txt_colorbar_nLeader.Location = new System.Drawing.Point(33, 629);
            this.txt_colorbar_nLeader.Name = "txt_colorbar_nLeader";
            this.txt_colorbar_nLeader.Size = new System.Drawing.Size(61, 13);
            this.txt_colorbar_nLeader.TabIndex = 20;
            this.txt_colorbar_nLeader.Text = "# nLeaders";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(679, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Nº Onsets";
            // 
            // txt_nOnsets
            // 
            this.txt_nOnsets.AutoSize = true;
            this.txt_nOnsets.Location = new System.Drawing.Point(704, 113);
            this.txt_nOnsets.Name = "txt_nOnsets";
            this.txt_nOnsets.Size = new System.Drawing.Size(16, 13);
            this.txt_nOnsets.TabIndex = 22;
            this.txt_nOnsets.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(708, 629);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "0";
            // 
            // check_plotLastBurst
            // 
            this.check_plotLastBurst.AutoSize = true;
            this.check_plotLastBurst.Checked = true;
            this.check_plotLastBurst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_plotLastBurst.Location = new System.Drawing.Point(374, 30);
            this.check_plotLastBurst.Name = "check_plotLastBurst";
            this.check_plotLastBurst.Size = new System.Drawing.Size(103, 17);
            this.check_plotLastBurst.TabIndex = 24;
            this.check_plotLastBurst.Text = "Show Last Burst";
            this.check_plotLastBurst.UseVisualStyleBackColor = true;
            this.check_plotLastBurst.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BurstLeadersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 690);
            this.Controls.Add(this.check_plotLastBurst);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_nOnsets);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_colorbar_nLeader);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel_history);
            this.Controls.Add(this.panel_lastLeaders);
            this.Controls.Add(this.set_interval);
            this.Controls.Add(this.txt_update_interval_s);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.check_auto_plot);
            this.Controls.Add(this.btn_plot_leaders);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_set_onsetWindow);
            this.Controls.Add(this.btn_set_nLeaders);
            this.Controls.Add(this.txt_onsetWindow_s);
            this.Controls.Add(this.txt_nLeaders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BurstLeadersForm";
            this.Text = "BurstLeadersForm";
            this.Load += new System.EventHandler(this.BurstLeadersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nLeaders;
        private System.Windows.Forms.TextBox txt_onsetWindow_s;
        private System.Windows.Forms.Button btn_set_nLeaders;
        private System.Windows.Forms.Button btn_set_onsetWindow;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_plot_leaders;
        private System.Windows.Forms.CheckBox check_auto_plot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_update_interval_s;
        private System.Windows.Forms.Button set_interval;
        private System.Windows.Forms.Panel panel_lastLeaders;
        private System.Windows.Forms.Panel panel_history;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txt_colorbar_nLeader;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label txt_nOnsets;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox check_plotLastBurst;
    }
}