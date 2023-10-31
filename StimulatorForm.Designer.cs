
namespace OnlineSpikeDetection
{
    partial class StimulatorForm
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
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.txt_mean_rate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radio_STG1 = new System.Windows.Forms.RadioButton();
            this.radio_STG2 = new System.Windows.Forms.RadioButton();
            this.btn_set = new System.Windows.Forms.Button();
            this.txt_minInterStim_s = new System.Windows.Forms.TextBox();
            this.btn_set_minInterStim = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radio_poisson = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radio_regular = new System.Windows.Forms.RadioButton();
            this.btn_randStimElecs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_N_stim_elecs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_set_stim_dur = new System.Windows.Forms.Button();
            this.txt_stim_dur_min = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_set_stimElecs = new System.Windows.Forms.Button();
            this.radio_control = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(511, 63);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(592, 63);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // txt_mean_rate
            // 
            this.txt_mean_rate.Location = new System.Drawing.Point(151, 29);
            this.txt_mean_rate.Name = "txt_mean_rate";
            this.txt_mean_rate.Size = new System.Drawing.Size(43, 20);
            this.txt_mean_rate.TabIndex = 3;
            this.txt_mean_rate.TextChanged += new System.EventHandler(this.txt_mean_rate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mean Rate [Hz]";
            // 
            // radio_STG1
            // 
            this.radio_STG1.AutoSize = true;
            this.radio_STG1.Checked = true;
            this.radio_STG1.Location = new System.Drawing.Point(15, 19);
            this.radio_STG1.Name = "radio_STG1";
            this.radio_STG1.Size = new System.Drawing.Size(56, 17);
            this.radio_STG1.TabIndex = 7;
            this.radio_STG1.TabStop = true;
            this.radio_STG1.Text = "STG 1";
            this.radio_STG1.UseVisualStyleBackColor = true;
            this.radio_STG1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radio_STG2
            // 
            this.radio_STG2.AutoSize = true;
            this.radio_STG2.Location = new System.Drawing.Point(15, 40);
            this.radio_STG2.Name = "radio_STG2";
            this.radio_STG2.Size = new System.Drawing.Size(56, 17);
            this.radio_STG2.TabIndex = 8;
            this.radio_STG2.Text = "STG 2";
            this.radio_STG2.UseVisualStyleBackColor = true;
            this.radio_STG2.CheckedChanged += new System.EventHandler(this.radio_STG2_CheckedChanged);
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(199, 28);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(29, 23);
            this.btn_set.TabIndex = 9;
            this.btn_set.Text = "set";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // txt_minInterStim_s
            // 
            this.txt_minInterStim_s.Location = new System.Drawing.Point(152, 84);
            this.txt_minInterStim_s.Name = "txt_minInterStim_s";
            this.txt_minInterStim_s.Size = new System.Drawing.Size(46, 20);
            this.txt_minInterStim_s.TabIndex = 10;
            this.txt_minInterStim_s.TextChanged += new System.EventHandler(this.txt_minInterStim_s_TextChanged);
            // 
            // btn_set_minInterStim
            // 
            this.btn_set_minInterStim.Enabled = false;
            this.btn_set_minInterStim.Location = new System.Drawing.Point(203, 84);
            this.btn_set_minInterStim.Name = "btn_set_minInterStim";
            this.btn_set_minInterStim.Size = new System.Drawing.Size(30, 23);
            this.btn_set_minInterStim.TabIndex = 11;
            this.btn_set_minInterStim.Text = "set";
            this.btn_set_minInterStim.UseVisualStyleBackColor = true;
            this.btn_set_minInterStim.Click += new System.EventHandler(this.btn_set_minInterStim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min Inter-Stim interval [s]";
            // 
            // radio_poisson
            // 
            this.radio_poisson.AutoSize = true;
            this.radio_poisson.Location = new System.Drawing.Point(10, 40);
            this.radio_poisson.Name = "radio_poisson";
            this.radio_poisson.Size = new System.Drawing.Size(62, 17);
            this.radio_poisson.TabIndex = 13;
            this.radio_poisson.Text = "Poisson";
            this.radio_poisson.UseVisualStyleBackColor = true;
            this.radio_poisson.CheckedChanged += new System.EventHandler(this.radio_poisson_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(16, 61);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(67, 17);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.Text = "Alternate";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radio_regular
            // 
            this.radio_regular.AutoSize = true;
            this.radio_regular.Location = new System.Drawing.Point(10, 61);
            this.radio_regular.Name = "radio_regular";
            this.radio_regular.Size = new System.Drawing.Size(62, 17);
            this.radio_regular.TabIndex = 15;
            this.radio_regular.Text = "Regular";
            this.radio_regular.UseVisualStyleBackColor = true;
            this.radio_regular.CheckedChanged += new System.EventHandler(this.radio_regular_CheckedChanged);
            // 
            // btn_randStimElecs
            // 
            this.btn_randStimElecs.Enabled = false;
            this.btn_randStimElecs.Location = new System.Drawing.Point(24, 29);
            this.btn_randStimElecs.Name = "btn_randStimElecs";
            this.btn_randStimElecs.Size = new System.Drawing.Size(90, 22);
            this.btn_randStimElecs.TabIndex = 16;
            this.btn_randStimElecs.Text = "Random Elecs";
            this.btn_randStimElecs.UseVisualStyleBackColor = true;
            this.btn_randStimElecs.Click += new System.EventHandler(this.btn_randStimElecs_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "N elecs:";
            // 
            // txt_N_stim_elecs
            // 
            this.txt_N_stim_elecs.Location = new System.Drawing.Point(77, 54);
            this.txt_N_stim_elecs.Name = "txt_N_stim_elecs";
            this.txt_N_stim_elecs.Size = new System.Drawing.Size(36, 20);
            this.txt_N_stim_elecs.TabIndex = 18;
            this.txt_N_stim_elecs.TextChanged += new System.EventHandler(this.txt_N_stim_elecs_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Duration [mins]";
            // 
            // btn_set_stim_dur
            // 
            this.btn_set_stim_dur.Location = new System.Drawing.Point(638, 89);
            this.btn_set_stim_dur.Name = "btn_set_stim_dur";
            this.btn_set_stim_dur.Size = new System.Drawing.Size(29, 20);
            this.btn_set_stim_dur.TabIndex = 20;
            this.btn_set_stim_dur.Text = "set";
            this.btn_set_stim_dur.UseVisualStyleBackColor = true;
            // 
            // txt_stim_dur_min
            // 
            this.txt_stim_dur_min.Location = new System.Drawing.Point(593, 89);
            this.txt_stim_dur_min.Name = "txt_stim_dur_min";
            this.txt_stim_dur_min.Size = new System.Drawing.Size(40, 20);
            this.txt_stim_dur_min.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_control);
            this.groupBox1.Controls.Add(this.radio_poisson);
            this.groupBox1.Controls.Add(this.radio_regular);
            this.groupBox1.Location = new System.Drawing.Point(300, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 92);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stimulation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_STG1);
            this.groupBox2.Controls.Add(this.radio_STG2);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Location = new System.Drawing.Point(388, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 92);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stimulator";
            // 
            // btn_set_stimElecs
            // 
            this.btn_set_stimElecs.Location = new System.Drawing.Point(511, 28);
            this.btn_set_stimElecs.Name = "btn_set_stimElecs";
            this.btn_set_stimElecs.Size = new System.Drawing.Size(156, 28);
            this.btn_set_stimElecs.TabIndex = 24;
            this.btn_set_stimElecs.Text = "Set Stimulation Elecs";
            this.btn_set_stimElecs.UseVisualStyleBackColor = true;
            this.btn_set_stimElecs.Click += new System.EventHandler(this.set_stimElecs_Click);
            // 
            // radio_control
            // 
            this.radio_control.AutoSize = true;
            this.radio_control.Checked = true;
            this.radio_control.Location = new System.Drawing.Point(10, 20);
            this.radio_control.Name = "radio_control";
            this.radio_control.Size = new System.Drawing.Size(58, 17);
            this.radio_control.TabIndex = 16;
            this.radio_control.Text = "Control";
            this.radio_control.UseVisualStyleBackColor = true;
            this.radio_control.CheckedChanged += new System.EventHandler(this.radio_control_CheckedChanged);
            // 
            // StimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 743);
            this.Controls.Add(this.btn_set_stimElecs);
            this.Controls.Add(this.btn_set_minInterStim);
            this.Controls.Add(this.txt_minInterStim_s);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_stim_dur_min);
            this.Controls.Add(this.btn_set_stim_dur);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_N_stim_elecs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_randStimElecs);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_mean_rate);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Name = "StimulatorForm";
            this.Text = "StimulatorForm";
            this.Load += new System.EventHandler(this.StimulatorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.TextBox txt_mean_rate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_STG1;
        private System.Windows.Forms.RadioButton radio_STG2;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.TextBox txt_minInterStim_s;
        private System.Windows.Forms.Button btn_set_minInterStim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radio_poisson;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radio_regular;
        private System.Windows.Forms.Button btn_randStimElecs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_N_stim_elecs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_set_stim_dur;
        private System.Windows.Forms.TextBox txt_stim_dur_min;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_set_stimElecs;
        private System.Windows.Forms.RadioButton radio_control;
    }
}