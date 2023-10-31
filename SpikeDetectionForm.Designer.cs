
namespace OnlineSpikeDetection
{
    partial class SpikeDetectionForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_StartDacq = new System.Windows.Forms.Button();
            this.btn_StopDacq = new System.Windows.Forms.Button();
            this.spikeCount_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.check_FR = new System.Windows.Forms.CheckBox();
            this.check_spikeCount = new System.Windows.Forms.CheckBox();
            this.check_oscillator = new System.Windows.Forms.CheckBox();
            this.check_controller = new System.Windows.Forms.CheckBox();
            this.check_stimFreq = new System.Windows.Forms.CheckBox();
            this.check_stimulus = new System.Windows.Forms.CheckBox();
            this.txt_period = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_fix_mode = new System.Windows.Forms.Button();
            this.btn_stimulate = new System.Windows.Forms.Button();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.check_OnControl = new System.Windows.Forms.CheckBox();
            this.btn_set_spk_thresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_thresh_uV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_burstThresh = new System.Windows.Forms.TextBox();
            this.txt_minIBI = new System.Windows.Forms.TextBox();
            this.btn_set_BurstThresh = new System.Windows.Forms.Button();
            this.btn_set_minIBI = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_set_stimGain = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_stimGain = new System.Windows.Forms.TextBox();
            this.btn_set_filter = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_filter = new System.Windows.Forms.TextBox();
            this.btn_set_delay_frac = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_delay_frac = new System.Windows.Forms.TextBox();
            this.btn_set_future_window = new System.Windows.Forms.Button();
            this.btn_set_past_window = new System.Windows.Forms.Button();
            this.txt_future_window = new System.Windows.Forms.TextBox();
            this.txt_past_window = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_set_FR_window = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_FR_window = new System.Windows.Forms.TextBox();
            this.btn_updateElecs = new System.Windows.Forms.Button();
            this.btn_set_max_y = new System.Windows.Forms.Button();
            this.txt_max_y = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.check_dualMode = new System.Windows.Forms.CheckBox();
            this.btn_BurstLeadersForm = new System.Windows.Forms.Button();
            this.check_burstLeaders = new System.Windows.Forms.CheckBox();
            this.check_savaData = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_avg_stim_freq = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_setFolder = new System.Windows.Forms.Button();
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.btn_chooseFolder = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radio_activate_rec_STG2 = new System.Windows.Forms.RadioButton();
            this.radio_activate_rec_STG1 = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_set_min_stimFreq_thresh = new System.Windows.Forms.Button();
            this.txt_min_stimFreq_thresh = new System.Windows.Forms.TextBox();
            this.check_remove_stim_artifact = new System.Windows.Forms.CheckBox();
            this.btn_adaptive_mode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spikeCount_chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_StartDacq
            // 
            this.btn_StartDacq.Location = new System.Drawing.Point(32, 50);
            this.btn_StartDacq.Name = "btn_StartDacq";
            this.btn_StartDacq.Size = new System.Drawing.Size(159, 31);
            this.btn_StartDacq.TabIndex = 0;
            this.btn_StartDacq.Text = "Start Spike Detection";
            this.btn_StartDacq.UseVisualStyleBackColor = true;
            this.btn_StartDacq.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_StopDacq
            // 
            this.btn_StopDacq.Enabled = false;
            this.btn_StopDacq.Location = new System.Drawing.Point(197, 50);
            this.btn_StopDacq.Name = "btn_StopDacq";
            this.btn_StopDacq.Size = new System.Drawing.Size(159, 31);
            this.btn_StopDacq.TabIndex = 1;
            this.btn_StopDacq.Text = "Stop Spike Detection";
            this.btn_StopDacq.UseVisualStyleBackColor = true;
            this.btn_StopDacq.Click += new System.EventHandler(this.btn_StopDacq_Click);
            // 
            // spikeCount_chart
            // 
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 97F;
            chartArea3.Position.Width = 97F;
            chartArea3.Position.X = 1F;
            chartArea3.Position.Y = 1F;
            this.spikeCount_chart.ChartAreas.Add(chartArea3);
            legend3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomRight;
            legend3.Name = "Legend1";
            this.spikeCount_chart.Legends.Add(legend3);
            this.spikeCount_chart.Location = new System.Drawing.Point(34, 172);
            this.spikeCount_chart.Name = "spikeCount_chart";
            series15.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series15.Color = System.Drawing.Color.Aqua;
            series15.Legend = "Legend1";
            series15.Name = "Spike Count";
            series16.BorderWidth = 2;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series16.Color = System.Drawing.Color.LimeGreen;
            series16.Legend = "Legend1";
            series16.Name = "Firing Rate (Hz)";
            series17.BorderWidth = 2;
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series17.Color = System.Drawing.Color.Red;
            series17.Legend = "Legend1";
            series17.Name = "Oscillator";
            series18.BorderWidth = 2;
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series18.Color = System.Drawing.Color.Fuchsia;
            series18.Legend = "Legend1";
            series18.Name = "Controller";
            series19.BorderWidth = 2;
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series19.Color = System.Drawing.Color.Blue;
            series19.Legend = "Legend1";
            series19.Name = "Stim Freq (Hz)";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series20.Color = System.Drawing.Color.Blue;
            series20.Legend = "Legend1";
            series20.Name = "Stimulus";
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series21.Color = System.Drawing.Color.Black;
            series21.Legend = "Legend1";
            series21.MarkerSize = 15;
            series21.Name = "Bursts";
            this.spikeCount_chart.Series.Add(series15);
            this.spikeCount_chart.Series.Add(series16);
            this.spikeCount_chart.Series.Add(series17);
            this.spikeCount_chart.Series.Add(series18);
            this.spikeCount_chart.Series.Add(series19);
            this.spikeCount_chart.Series.Add(series20);
            this.spikeCount_chart.Series.Add(series21);
            this.spikeCount_chart.Size = new System.Drawing.Size(1152, 600);
            this.spikeCount_chart.TabIndex = 2;
            this.spikeCount_chart.Text = "chart1";
            this.spikeCount_chart.Click += new System.EventHandler(this.spikeCount_chart_Click);
            // 
            // check_FR
            // 
            this.check_FR.AutoSize = true;
            this.check_FR.Checked = true;
            this.check_FR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_FR.Location = new System.Drawing.Point(292, 129);
            this.check_FR.Name = "check_FR";
            this.check_FR.Size = new System.Drawing.Size(77, 17);
            this.check_FR.TabIndex = 3;
            this.check_FR.Text = "Firing Rate";
            this.check_FR.UseVisualStyleBackColor = true;
            // 
            // check_spikeCount
            // 
            this.check_spikeCount.AutoSize = true;
            this.check_spikeCount.Location = new System.Drawing.Point(292, 109);
            this.check_spikeCount.Name = "check_spikeCount";
            this.check_spikeCount.Size = new System.Drawing.Size(84, 17);
            this.check_spikeCount.TabIndex = 4;
            this.check_spikeCount.Text = "Spike Count";
            this.check_spikeCount.UseVisualStyleBackColor = true;
            // 
            // check_oscillator
            // 
            this.check_oscillator.AutoSize = true;
            this.check_oscillator.Location = new System.Drawing.Point(385, 109);
            this.check_oscillator.Name = "check_oscillator";
            this.check_oscillator.Size = new System.Drawing.Size(69, 17);
            this.check_oscillator.TabIndex = 5;
            this.check_oscillator.Text = "Oscillator";
            this.check_oscillator.UseVisualStyleBackColor = true;
            // 
            // check_controller
            // 
            this.check_controller.AutoSize = true;
            this.check_controller.Location = new System.Drawing.Point(385, 129);
            this.check_controller.Name = "check_controller";
            this.check_controller.Size = new System.Drawing.Size(70, 17);
            this.check_controller.TabIndex = 6;
            this.check_controller.Text = "Controller";
            this.check_controller.UseVisualStyleBackColor = true;
            // 
            // check_stimFreq
            // 
            this.check_stimFreq.AutoSize = true;
            this.check_stimFreq.Location = new System.Drawing.Point(465, 109);
            this.check_stimFreq.Name = "check_stimFreq";
            this.check_stimFreq.Size = new System.Drawing.Size(101, 17);
            this.check_stimFreq.TabIndex = 7;
            this.check_stimFreq.Text = "Stimulation Freq";
            this.check_stimFreq.UseVisualStyleBackColor = true;
            // 
            // check_stimulus
            // 
            this.check_stimulus.AutoSize = true;
            this.check_stimulus.Location = new System.Drawing.Point(465, 129);
            this.check_stimulus.Name = "check_stimulus";
            this.check_stimulus.Size = new System.Drawing.Size(65, 17);
            this.check_stimulus.TabIndex = 8;
            this.check_stimulus.Text = "Stimulus";
            this.check_stimulus.UseVisualStyleBackColor = true;
            // 
            // txt_period
            // 
            this.txt_period.Location = new System.Drawing.Point(932, 34);
            this.txt_period.Name = "txt_period";
            this.txt_period.Size = new System.Drawing.Size(40, 20);
            this.txt_period.TabIndex = 9;
            this.txt_period.TextChanged += new System.EventHandler(this.txt_period_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(798, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Oscillator Period [s]";
            // 
            // btn_fix_mode
            // 
            this.btn_fix_mode.Location = new System.Drawing.Point(976, 33);
            this.btn_fix_mode.Name = "btn_fix_mode";
            this.btn_fix_mode.Size = new System.Drawing.Size(32, 23);
            this.btn_fix_mode.TabIndex = 11;
            this.btn_fix_mode.Text = "fix";
            this.btn_fix_mode.UseVisualStyleBackColor = true;
            this.btn_fix_mode.Click += new System.EventHandler(this.btn_set_T_Click);
            // 
            // btn_stimulate
            // 
            this.btn_stimulate.Location = new System.Drawing.Point(292, 15);
            this.btn_stimulate.Name = "btn_stimulate";
            this.btn_stimulate.Size = new System.Drawing.Size(63, 29);
            this.btn_stimulate.TabIndex = 12;
            this.btn_stimulate.Text = "Stimulate";
            this.btn_stimulate.UseVisualStyleBackColor = true;
            this.btn_stimulate.Click += new System.EventHandler(this.btn_stimulate_Click);
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(32, 15);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(159, 21);
            this.cbDeviceList.TabIndex = 13;
            this.cbDeviceList.SelectedIndexChanged += new System.EventHandler(this.cbDeviceList_SelectedIndexChanged);
            // 
            // check_OnControl
            // 
            this.check_OnControl.AutoSize = true;
            this.check_OnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_OnControl.Location = new System.Drawing.Point(1023, 64);
            this.check_OnControl.Name = "check_OnControl";
            this.check_OnControl.Size = new System.Drawing.Size(72, 19);
            this.check_OnControl.TabIndex = 14;
            this.check_OnControl.Text = "Control";
            this.check_OnControl.UseVisualStyleBackColor = true;
            this.check_OnControl.CheckedChanged += new System.EventHandler(this.check_OnControl_CheckedChanged);
            // 
            // btn_set_spk_thresh
            // 
            this.btn_set_spk_thresh.Enabled = false;
            this.btn_set_spk_thresh.Location = new System.Drawing.Point(534, 33);
            this.btn_set_spk_thresh.Name = "btn_set_spk_thresh";
            this.btn_set_spk_thresh.Size = new System.Drawing.Size(32, 23);
            this.btn_set_spk_thresh.TabIndex = 17;
            this.btn_set_spk_thresh.Text = "set";
            this.btn_set_spk_thresh.UseVisualStyleBackColor = true;
            this.btn_set_spk_thresh.Click += new System.EventHandler(this.btn_set_thresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Spike Thresh [uV]";
            // 
            // txt_thresh_uV
            // 
            this.txt_thresh_uV.Location = new System.Drawing.Point(488, 34);
            this.txt_thresh_uV.Name = "txt_thresh_uV";
            this.txt_thresh_uV.Size = new System.Drawing.Size(40, 20);
            this.txt_thresh_uV.TabIndex = 15;
            this.txt_thresh_uV.TextChanged += new System.EventHandler(this.txt_thresh_uV_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Burst Thresh [Hz]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Min IBI [s]";
            // 
            // txt_burstThresh
            // 
            this.txt_burstThresh.Location = new System.Drawing.Point(695, 35);
            this.txt_burstThresh.Name = "txt_burstThresh";
            this.txt_burstThresh.Size = new System.Drawing.Size(44, 20);
            this.txt_burstThresh.TabIndex = 20;
            this.txt_burstThresh.TextChanged += new System.EventHandler(this.txt_burstThresh_TextChanged);
            // 
            // txt_minIBI
            // 
            this.txt_minIBI.Location = new System.Drawing.Point(695, 62);
            this.txt_minIBI.Name = "txt_minIBI";
            this.txt_minIBI.Size = new System.Drawing.Size(44, 20);
            this.txt_minIBI.TabIndex = 21;
            this.txt_minIBI.TextChanged += new System.EventHandler(this.txt_minIBI_TextChanged);
            // 
            // btn_set_BurstThresh
            // 
            this.btn_set_BurstThresh.Enabled = false;
            this.btn_set_BurstThresh.Location = new System.Drawing.Point(747, 34);
            this.btn_set_BurstThresh.Name = "btn_set_BurstThresh";
            this.btn_set_BurstThresh.Size = new System.Drawing.Size(33, 23);
            this.btn_set_BurstThresh.TabIndex = 22;
            this.btn_set_BurstThresh.Text = "set";
            this.btn_set_BurstThresh.UseVisualStyleBackColor = true;
            this.btn_set_BurstThresh.Click += new System.EventHandler(this.btn_set_BurstThresh_Click);
            // 
            // btn_set_minIBI
            // 
            this.btn_set_minIBI.Enabled = false;
            this.btn_set_minIBI.Location = new System.Drawing.Point(747, 61);
            this.btn_set_minIBI.Name = "btn_set_minIBI";
            this.btn_set_minIBI.Size = new System.Drawing.Size(33, 23);
            this.btn_set_minIBI.TabIndex = 23;
            this.btn_set_minIBI.Text = "set";
            this.btn_set_minIBI.UseVisualStyleBackColor = true;
            this.btn_set_minIBI.Click += new System.EventHandler(this.btn_set_minIBI_Click);
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(425, 8);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Spike Detection";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(638, 8);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Burst Detection";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(974, 8);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Controller";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btn_set_stimGain
            // 
            this.btn_set_stimGain.Enabled = false;
            this.btn_set_stimGain.Location = new System.Drawing.Point(976, 61);
            this.btn_set_stimGain.Name = "btn_set_stimGain";
            this.btn_set_stimGain.Size = new System.Drawing.Size(32, 23);
            this.btn_set_stimGain.TabIndex = 29;
            this.btn_set_stimGain.Text = "set";
            this.btn_set_stimGain.UseVisualStyleBackColor = true;
            this.btn_set_stimGain.Click += new System.EventHandler(this.btn_set_stimGain_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(846, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Stimulation Gain";
            // 
            // txt_stimGain
            // 
            this.txt_stimGain.Location = new System.Drawing.Point(932, 62);
            this.txt_stimGain.Name = "txt_stimGain";
            this.txt_stimGain.Size = new System.Drawing.Size(40, 20);
            this.txt_stimGain.TabIndex = 27;
            this.txt_stimGain.TextChanged += new System.EventHandler(this.txt_stimGain_TextChanged);
            // 
            // btn_set_filter
            // 
            this.btn_set_filter.Enabled = false;
            this.btn_set_filter.Location = new System.Drawing.Point(534, 61);
            this.btn_set_filter.Name = "btn_set_filter";
            this.btn_set_filter.Size = new System.Drawing.Size(32, 23);
            this.btn_set_filter.TabIndex = 32;
            this.btn_set_filter.Text = "set";
            this.btn_set_filter.UseVisualStyleBackColor = true;
            this.btn_set_filter.Click += new System.EventHandler(this.btn_set_filter_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(380, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "High Pass Filter [Hz]";
            // 
            // txt_filter
            // 
            this.txt_filter.Location = new System.Drawing.Point(488, 62);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(40, 20);
            this.txt_filter.TabIndex = 30;
            this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // btn_set_delay_frac
            // 
            this.btn_set_delay_frac.Enabled = false;
            this.btn_set_delay_frac.Location = new System.Drawing.Point(1141, 33);
            this.btn_set_delay_frac.Name = "btn_set_delay_frac";
            this.btn_set_delay_frac.Size = new System.Drawing.Size(32, 23);
            this.btn_set_delay_frac.TabIndex = 35;
            this.btn_set_delay_frac.Text = "set";
            this.btn_set_delay_frac.UseVisualStyleBackColor = true;
            this.btn_set_delay_frac.Click += new System.EventHandler(this.btn_set_delay_frac_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1020, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Delay Fraction";
            // 
            // txt_delay_frac
            // 
            this.txt_delay_frac.Location = new System.Drawing.Point(1097, 34);
            this.txt_delay_frac.Name = "txt_delay_frac";
            this.txt_delay_frac.Size = new System.Drawing.Size(40, 20);
            this.txt_delay_frac.TabIndex = 33;
            this.txt_delay_frac.TextChanged += new System.EventHandler(this.txt_delay_frac_TextChanged);
            // 
            // btn_set_future_window
            // 
            this.btn_set_future_window.Enabled = false;
            this.btn_set_future_window.Location = new System.Drawing.Point(323, 777);
            this.btn_set_future_window.Name = "btn_set_future_window";
            this.btn_set_future_window.Size = new System.Drawing.Size(33, 23);
            this.btn_set_future_window.TabIndex = 41;
            this.btn_set_future_window.Text = "set";
            this.btn_set_future_window.UseVisualStyleBackColor = true;
            this.btn_set_future_window.Click += new System.EventHandler(this.btn_set_future_window_Click);
            // 
            // btn_set_past_window
            // 
            this.btn_set_past_window.Enabled = false;
            this.btn_set_past_window.Location = new System.Drawing.Point(174, 778);
            this.btn_set_past_window.Name = "btn_set_past_window";
            this.btn_set_past_window.Size = new System.Drawing.Size(33, 23);
            this.btn_set_past_window.TabIndex = 40;
            this.btn_set_past_window.Text = "set";
            this.btn_set_past_window.UseVisualStyleBackColor = true;
            this.btn_set_past_window.Click += new System.EventHandler(this.btn_set_past_window_Click);
            // 
            // txt_future_window
            // 
            this.txt_future_window.Location = new System.Drawing.Point(275, 778);
            this.txt_future_window.Name = "txt_future_window";
            this.txt_future_window.Size = new System.Drawing.Size(44, 20);
            this.txt_future_window.TabIndex = 39;
            this.txt_future_window.TextChanged += new System.EventHandler(this.txt_future_window_TextChanged);
            // 
            // txt_past_window
            // 
            this.txt_past_window.Location = new System.Drawing.Point(125, 779);
            this.txt_past_window.Name = "txt_past_window";
            this.txt_past_window.Size = new System.Drawing.Size(44, 20);
            this.txt_past_window.TabIndex = 38;
            this.txt_past_window.TextChanged += new System.EventHandler(this.txt_past_window_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(80, 781);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Past [s]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(221, 781);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Future [s]";
            // 
            // btn_set_FR_window
            // 
            this.btn_set_FR_window.Enabled = false;
            this.btn_set_FR_window.Location = new System.Drawing.Point(747, 88);
            this.btn_set_FR_window.Name = "btn_set_FR_window";
            this.btn_set_FR_window.Size = new System.Drawing.Size(33, 23);
            this.btn_set_FR_window.TabIndex = 44;
            this.btn_set_FR_window.Text = "set";
            this.btn_set_FR_window.UseVisualStyleBackColor = true;
            this.btn_set_FR_window.Click += new System.EventHandler(this.btn_set_FR_window_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(605, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "FR Windows  [s]";
            // 
            // txt_FR_window
            // 
            this.txt_FR_window.Location = new System.Drawing.Point(695, 89);
            this.txt_FR_window.Name = "txt_FR_window";
            this.txt_FR_window.Size = new System.Drawing.Size(45, 20);
            this.txt_FR_window.TabIndex = 42;
            this.txt_FR_window.TextChanged += new System.EventHandler(this.txt_FR_window_TextChanged);
            // 
            // btn_updateElecs
            // 
            this.btn_updateElecs.Location = new System.Drawing.Point(198, 15);
            this.btn_updateElecs.Name = "btn_updateElecs";
            this.btn_updateElecs.Size = new System.Drawing.Size(87, 29);
            this.btn_updateElecs.TabIndex = 45;
            this.btn_updateElecs.Text = "Update Elecs";
            this.btn_updateElecs.UseVisualStyleBackColor = true;
            this.btn_updateElecs.Click += new System.EventHandler(this.btn_updateElecs_Click);
            // 
            // btn_set_max_y
            // 
            this.btn_set_max_y.Enabled = false;
            this.btn_set_max_y.Location = new System.Drawing.Point(508, 778);
            this.btn_set_max_y.Name = "btn_set_max_y";
            this.btn_set_max_y.Size = new System.Drawing.Size(33, 23);
            this.btn_set_max_y.TabIndex = 50;
            this.btn_set_max_y.Text = "set";
            this.btn_set_max_y.UseVisualStyleBackColor = true;
            this.btn_set_max_y.Click += new System.EventHandler(this.btn_set_max_y_Click);
            // 
            // txt_max_y
            // 
            this.txt_max_y.Location = new System.Drawing.Point(459, 779);
            this.txt_max_y.Name = "txt_max_y";
            this.txt_max_y.Size = new System.Drawing.Size(44, 20);
            this.txt_max_y.TabIndex = 48;
            this.txt_max_y.TextChanged += new System.EventHandler(this.txt_max_y_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(402, 781);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Y Lim [Hz]";
            // 
            // check_dualMode
            // 
            this.check_dualMode.AutoSize = true;
            this.check_dualMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_dualMode.Location = new System.Drawing.Point(1097, 66);
            this.check_dualMode.Name = "check_dualMode";
            this.check_dualMode.Size = new System.Drawing.Size(80, 17);
            this.check_dualMode.TabIndex = 51;
            this.check_dualMode.Text = "Dual Stim";
            this.check_dualMode.UseVisualStyleBackColor = true;
            this.check_dualMode.CheckedChanged += new System.EventHandler(this.check_dualMode_CheckedChanged);
            // 
            // btn_BurstLeadersForm
            // 
            this.btn_BurstLeadersForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_BurstLeadersForm.Enabled = false;
            this.btn_BurstLeadersForm.Location = new System.Drawing.Point(603, 120);
            this.btn_BurstLeadersForm.Name = "btn_BurstLeadersForm";
            this.btn_BurstLeadersForm.Size = new System.Drawing.Size(139, 29);
            this.btn_BurstLeadersForm.TabIndex = 52;
            this.btn_BurstLeadersForm.Text = "Burst Leaders";
            this.btn_BurstLeadersForm.UseVisualStyleBackColor = false;
            this.btn_BurstLeadersForm.Click += new System.EventHandler(this.btn_BurstLeadersForm_Click);
            // 
            // check_burstLeaders
            // 
            this.check_burstLeaders.AutoSize = true;
            this.check_burstLeaders.Location = new System.Drawing.Point(749, 121);
            this.check_burstLeaders.Name = "check_burstLeaders";
            this.check_burstLeaders.Size = new System.Drawing.Size(15, 14);
            this.check_burstLeaders.TabIndex = 53;
            this.check_burstLeaders.UseVisualStyleBackColor = true;
            this.check_burstLeaders.CheckedChanged += new System.EventHandler(this.check_burstLeaders_CheckedChanged);
            // 
            // check_savaData
            // 
            this.check_savaData.AutoSize = true;
            this.check_savaData.Checked = true;
            this.check_savaData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_savaData.Location = new System.Drawing.Point(12, 17);
            this.check_savaData.Name = "check_savaData";
            this.check_savaData.Size = new System.Drawing.Size(51, 17);
            this.check_savaData.TabIndex = 55;
            this.check_savaData.Text = "Save";
            this.check_savaData.UseVisualStyleBackColor = true;
            this.check_savaData.CheckedChanged += new System.EventHandler(this.check_savaData_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label15.Location = new System.Drawing.Point(33, 153);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 13);
            this.label15.TabIndex = 56;
            this.label15.Text = "Avg Stim Freq in last trial [Hz]:";
            // 
            // txt_avg_stim_freq
            // 
            this.txt_avg_stim_freq.AutoSize = true;
            this.txt_avg_stim_freq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_avg_stim_freq.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_avg_stim_freq.Location = new System.Drawing.Point(177, 154);
            this.txt_avg_stim_freq.Name = "txt_avg_stim_freq";
            this.txt_avg_stim_freq.Size = new System.Drawing.Size(14, 13);
            this.txt_avg_stim_freq.TabIndex = 57;
            this.txt_avg_stim_freq.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_setFolder);
            this.groupBox1.Controls.Add(this.txt_folder);
            this.groupBox1.Controls.Add(this.btn_chooseFolder);
            this.groupBox1.Controls.Add(this.check_savaData);
            this.groupBox1.Location = new System.Drawing.Point(799, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 46);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // btn_setFolder
            // 
            this.btn_setFolder.Enabled = false;
            this.btn_setFolder.Location = new System.Drawing.Point(352, 14);
            this.btn_setFolder.Name = "btn_setFolder";
            this.btn_setFolder.Size = new System.Drawing.Size(29, 23);
            this.btn_setFolder.TabIndex = 60;
            this.btn_setFolder.Text = "set";
            this.btn_setFolder.UseVisualStyleBackColor = true;
            this.btn_setFolder.Click += new System.EventHandler(this.btn_setFolder_Click);
            // 
            // txt_folder
            // 
            this.txt_folder.Location = new System.Drawing.Point(112, 15);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(235, 20);
            this.txt_folder.TabIndex = 57;
            this.txt_folder.TextChanged += new System.EventHandler(this.txt_folder_TextChanged);
            // 
            // btn_chooseFolder
            // 
            this.btn_chooseFolder.Location = new System.Drawing.Point(62, 13);
            this.btn_chooseFolder.Name = "btn_chooseFolder";
            this.btn_chooseFolder.Size = new System.Drawing.Size(44, 23);
            this.btn_chooseFolder.TabIndex = 56;
            this.btn_chooseFolder.Text = "Folder";
            this.btn_chooseFolder.UseVisualStyleBackColor = true;
            this.btn_chooseFolder.Click += new System.EventHandler(this.btn_chooseFolder_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radio_activate_rec_STG2);
            this.groupBox2.Controls.Add(this.radio_activate_rec_STG1);
            this.groupBox2.Location = new System.Drawing.Point(34, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 44);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Rec";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(10, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(51, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "None";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radio_activate_rec_STG2
            // 
            this.radio_activate_rec_STG2.AutoSize = true;
            this.radio_activate_rec_STG2.Location = new System.Drawing.Point(126, 19);
            this.radio_activate_rec_STG2.Name = "radio_activate_rec_STG2";
            this.radio_activate_rec_STG2.Size = new System.Drawing.Size(53, 17);
            this.radio_activate_rec_STG2.TabIndex = 1;
            this.radio_activate_rec_STG2.Text = "STG2";
            this.radio_activate_rec_STG2.UseVisualStyleBackColor = true;
            // 
            // radio_activate_rec_STG1
            // 
            this.radio_activate_rec_STG1.AutoSize = true;
            this.radio_activate_rec_STG1.Location = new System.Drawing.Point(68, 19);
            this.radio_activate_rec_STG1.Name = "radio_activate_rec_STG1";
            this.radio_activate_rec_STG1.Size = new System.Drawing.Size(53, 17);
            this.radio_activate_rec_STG1.TabIndex = 0;
            this.radio_activate_rec_STG1.Text = "STG1";
            this.radio_activate_rec_STG1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(801, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "Min Stim Freq Thresh [Hz]";
            // 
            // btn_set_min_stimFreq_thresh
            // 
            this.btn_set_min_stimFreq_thresh.Enabled = false;
            this.btn_set_min_stimFreq_thresh.Location = new System.Drawing.Point(976, 90);
            this.btn_set_min_stimFreq_thresh.Name = "btn_set_min_stimFreq_thresh";
            this.btn_set_min_stimFreq_thresh.Size = new System.Drawing.Size(32, 23);
            this.btn_set_min_stimFreq_thresh.TabIndex = 63;
            this.btn_set_min_stimFreq_thresh.Text = "set";
            this.btn_set_min_stimFreq_thresh.UseVisualStyleBackColor = true;
            this.btn_set_min_stimFreq_thresh.Click += new System.EventHandler(this.btn_set_min_stimFreq_Click);
            // 
            // txt_min_stimFreq_thresh
            // 
            this.txt_min_stimFreq_thresh.Location = new System.Drawing.Point(932, 91);
            this.txt_min_stimFreq_thresh.Name = "txt_min_stimFreq_thresh";
            this.txt_min_stimFreq_thresh.Size = new System.Drawing.Size(40, 20);
            this.txt_min_stimFreq_thresh.TabIndex = 62;
            this.txt_min_stimFreq_thresh.TextChanged += new System.EventHandler(this.txt_min_stimFreq_TextChanged);
            // 
            // check_remove_stim_artifact
            // 
            this.check_remove_stim_artifact.AutoSize = true;
            this.check_remove_stim_artifact.Checked = true;
            this.check_remove_stim_artifact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_remove_stim_artifact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_remove_stim_artifact.Location = new System.Drawing.Point(1023, 89);
            this.check_remove_stim_artifact.Name = "check_remove_stim_artifact";
            this.check_remove_stim_artifact.Size = new System.Drawing.Size(145, 17);
            this.check_remove_stim_artifact.TabIndex = 64;
            this.check_remove_stim_artifact.Text = "Remove Stim Artifact";
            this.check_remove_stim_artifact.UseVisualStyleBackColor = true;
            this.check_remove_stim_artifact.CheckedChanged += new System.EventHandler(this.check_remove_stim_artifact_CheckedChanged);
            // 
            // btn_adaptive_mode
            // 
            this.btn_adaptive_mode.Enabled = false;
            this.btn_adaptive_mode.Location = new System.Drawing.Point(894, 33);
            this.btn_adaptive_mode.Name = "btn_adaptive_mode";
            this.btn_adaptive_mode.Size = new System.Drawing.Size(35, 22);
            this.btn_adaptive_mode.TabIndex = 65;
            this.btn_adaptive_mode.Text = "adp";
            this.btn_adaptive_mode.UseVisualStyleBackColor = true;
            this.btn_adaptive_mode.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SpikeDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 816);
            this.Controls.Add(this.btn_adaptive_mode);
            this.Controls.Add(this.check_remove_stim_artifact);
            this.Controls.Add(this.btn_set_min_stimFreq_thresh);
            this.Controls.Add(this.txt_min_stimFreq_thresh);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_avg_stim_freq);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.check_burstLeaders);
            this.Controls.Add(this.btn_BurstLeadersForm);
            this.Controls.Add(this.check_dualMode);
            this.Controls.Add(this.btn_set_max_y);
            this.Controls.Add(this.txt_max_y);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_updateElecs);
            this.Controls.Add(this.btn_set_FR_window);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_FR_window);
            this.Controls.Add(this.btn_set_future_window);
            this.Controls.Add(this.btn_set_past_window);
            this.Controls.Add(this.txt_future_window);
            this.Controls.Add(this.txt_past_window);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_set_delay_frac);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_delay_frac);
            this.Controls.Add(this.btn_set_filter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_filter);
            this.Controls.Add(this.btn_set_stimGain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_stimGain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_set_minIBI);
            this.Controls.Add(this.btn_set_BurstThresh);
            this.Controls.Add(this.txt_minIBI);
            this.Controls.Add(this.txt_burstThresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_set_spk_thresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_thresh_uV);
            this.Controls.Add(this.check_OnControl);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.btn_stimulate);
            this.Controls.Add(this.btn_fix_mode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_period);
            this.Controls.Add(this.check_stimulus);
            this.Controls.Add(this.check_stimFreq);
            this.Controls.Add(this.check_controller);
            this.Controls.Add(this.check_oscillator);
            this.Controls.Add(this.check_spikeCount);
            this.Controls.Add(this.check_FR);
            this.Controls.Add(this.spikeCount_chart);
            this.Controls.Add(this.btn_StopDacq);
            this.Controls.Add(this.btn_StartDacq);
            this.Name = "SpikeDetectionForm";
            this.Text = "SpikeDetectionForm";
            this.Load += new System.EventHandler(this.SpikeDetectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spikeCount_chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartDacq;
        private System.Windows.Forms.Button btn_StopDacq;
        private System.Windows.Forms.DataVisualization.Charting.Chart spikeCount_chart;
        private System.Windows.Forms.CheckBox check_FR;
        private System.Windows.Forms.CheckBox check_spikeCount;
        private System.Windows.Forms.CheckBox check_oscillator;
        private System.Windows.Forms.CheckBox check_controller;
        private System.Windows.Forms.CheckBox check_stimFreq;
        private System.Windows.Forms.CheckBox check_stimulus;
        private System.Windows.Forms.TextBox txt_period;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_fix_mode;
        private System.Windows.Forms.Button btn_stimulate;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.CheckBox check_OnControl;
        private System.Windows.Forms.Button btn_set_spk_thresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_thresh_uV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_burstThresh;
        private System.Windows.Forms.TextBox txt_minIBI;
        private System.Windows.Forms.Button btn_set_BurstThresh;
        private System.Windows.Forms.Button btn_set_minIBI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_set_stimGain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_stimGain;
        private System.Windows.Forms.Button btn_set_filter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_filter;
        private System.Windows.Forms.Button btn_set_delay_frac;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_delay_frac;
        private System.Windows.Forms.Button btn_set_future_window;
        private System.Windows.Forms.Button btn_set_past_window;
        private System.Windows.Forms.TextBox txt_future_window;
        private System.Windows.Forms.TextBox txt_past_window;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_set_FR_window;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_FR_window;
        private System.Windows.Forms.Button btn_updateElecs;
        private System.Windows.Forms.Button btn_set_max_y;
        private System.Windows.Forms.TextBox txt_max_y;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox check_dualMode;
        private System.Windows.Forms.Button btn_BurstLeadersForm;
        private System.Windows.Forms.CheckBox check_burstLeaders;
        private System.Windows.Forms.CheckBox check_savaData;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label txt_avg_stim_freq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_chooseFolder;
        private System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Button btn_setFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radio_activate_rec_STG2;
        private System.Windows.Forms.RadioButton radio_activate_rec_STG1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_set_min_stimFreq_thresh;
        private System.Windows.Forms.TextBox txt_min_stimFreq_thresh;
        private System.Windows.Forms.CheckBox check_remove_stim_artifact;
        private System.Windows.Forms.Button btn_adaptive_mode;
    }
}