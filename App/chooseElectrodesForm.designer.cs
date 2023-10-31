
namespace OnlineSpikeDetection
{
    partial class chooseElectrodesForm
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
            this.check_all = new System.Windows.Forms.CheckBox();
            this.bnt_reset_FRs = new System.Windows.Forms.Button();
            this.btn_chooseActive = new System.Windows.Forms.Button();
            this.btn_set_auto_interval = new System.Windows.Forms.Button();
            this.btn_getActiveElecs = new System.Windows.Forms.Button();
            this.check_auto = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_update_s = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FR_thresh = new System.Windows.Forms.TextBox();
            this.btn_set_FR_thresh = new System.Windows.Forms.Button();
            this.btn_setMoni_elecs = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_max_FR = new System.Windows.Forms.Label();
            this.txt_min_FR = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.check_well_F = new System.Windows.Forms.CheckBox();
            this.check_well_E = new System.Windows.Forms.CheckBox();
            this.check_well_D = new System.Windows.Forms.CheckBox();
            this.check_well_C = new System.Windows.Forms.CheckBox();
            this.check_well_B = new System.Windows.Forms.CheckBox();
            this.check_well_A = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_well_J_9 = new System.Windows.Forms.CheckBox();
            this.check_well_H_9 = new System.Windows.Forms.CheckBox();
            this.check_well_G_9 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check_well_F_9 = new System.Windows.Forms.CheckBox();
            this.check_well_E_9 = new System.Windows.Forms.CheckBox();
            this.check_well_D_9 = new System.Windows.Forms.CheckBox();
            this.check_well_C_9 = new System.Windows.Forms.CheckBox();
            this.check_well_B_9 = new System.Windows.Forms.CheckBox();
            this.check_well_A_9 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // check_all
            // 
            this.check_all.AutoSize = true;
            this.check_all.Location = new System.Drawing.Point(31, 74);
            this.check_all.Name = "check_all";
            this.check_all.Size = new System.Drawing.Size(37, 17);
            this.check_all.TabIndex = 0;
            this.check_all.Text = "All";
            this.check_all.UseVisualStyleBackColor = true;
            this.check_all.CheckedChanged += new System.EventHandler(this.check_all_CheckedChanged);
            // 
            // bnt_reset_FRs
            // 
            this.bnt_reset_FRs.BackColor = System.Drawing.Color.Transparent;
            this.bnt_reset_FRs.Location = new System.Drawing.Point(330, 45);
            this.bnt_reset_FRs.Name = "bnt_reset_FRs";
            this.bnt_reset_FRs.Size = new System.Drawing.Size(72, 23);
            this.bnt_reset_FRs.TabIndex = 20;
            this.bnt_reset_FRs.Text = "Reset";
            this.bnt_reset_FRs.UseVisualStyleBackColor = false;
            this.bnt_reset_FRs.Click += new System.EventHandler(this.bnt_reset_FRs_Click);
            // 
            // btn_chooseActive
            // 
            this.btn_chooseActive.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_chooseActive.Location = new System.Drawing.Point(580, 18);
            this.btn_chooseActive.Name = "btn_chooseActive";
            this.btn_chooseActive.Size = new System.Drawing.Size(86, 48);
            this.btn_chooseActive.TabIndex = 19;
            this.btn_chooseActive.Text = "Only Active Electrodes";
            this.btn_chooseActive.UseVisualStyleBackColor = false;
            this.btn_chooseActive.Click += new System.EventHandler(this.btn_chooseActive_Click);
            // 
            // btn_set_auto_interval
            // 
            this.btn_set_auto_interval.Enabled = false;
            this.btn_set_auto_interval.Location = new System.Drawing.Point(537, 44);
            this.btn_set_auto_interval.Name = "btn_set_auto_interval";
            this.btn_set_auto_interval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_set_auto_interval.Size = new System.Drawing.Size(30, 22);
            this.btn_set_auto_interval.TabIndex = 18;
            this.btn_set_auto_interval.Text = "set";
            this.btn_set_auto_interval.UseVisualStyleBackColor = true;
            this.btn_set_auto_interval.Click += new System.EventHandler(this.btn_set_auto_interval_Click);
            // 
            // btn_getActiveElecs
            // 
            this.btn_getActiveElecs.Location = new System.Drawing.Point(234, 45);
            this.btn_getActiveElecs.Name = "btn_getActiveElecs";
            this.btn_getActiveElecs.Size = new System.Drawing.Size(93, 23);
            this.btn_getActiveElecs.TabIndex = 17;
            this.btn_getActiveElecs.Text = "Calc Mean FRs";
            this.btn_getActiveElecs.UseVisualStyleBackColor = true;
            this.btn_getActiveElecs.Click += new System.EventHandler(this.btn_getActiveElecs_Click);
            // 
            // check_auto
            // 
            this.check_auto.AutoSize = true;
            this.check_auto.Location = new System.Drawing.Point(423, 21);
            this.check_auto.Name = "check_auto";
            this.check_auto.Size = new System.Drawing.Size(111, 17);
            this.check_auto.TabIndex = 16;
            this.check_auto.Text = "Automatic Update";
            this.check_auto.UseVisualStyleBackColor = true;
            this.check_auto.CheckedChanged += new System.EventHandler(this.check_auto_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Update period [s]";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_update_s
            // 
            this.txt_update_s.Enabled = false;
            this.txt_update_s.Location = new System.Drawing.Point(506, 45);
            this.txt_update_s.Name = "txt_update_s";
            this.txt_update_s.Size = new System.Drawing.Size(26, 20);
            this.txt_update_s.TabIndex = 13;
            this.txt_update_s.TextChanged += new System.EventHandler(this.txt_update_s_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Firing Rate Thresh [Hz ]";
            // 
            // txt_FR_thresh
            // 
            this.txt_FR_thresh.Location = new System.Drawing.Point(331, 21);
            this.txt_FR_thresh.Name = "txt_FR_thresh";
            this.txt_FR_thresh.Size = new System.Drawing.Size(32, 20);
            this.txt_FR_thresh.TabIndex = 11;
            this.txt_FR_thresh.TextChanged += new System.EventHandler(this.txt_FR_thresh_TextChanged);
            // 
            // btn_set_FR_thresh
            // 
            this.btn_set_FR_thresh.Location = new System.Drawing.Point(365, 20);
            this.btn_set_FR_thresh.Name = "btn_set_FR_thresh";
            this.btn_set_FR_thresh.Size = new System.Drawing.Size(37, 23);
            this.btn_set_FR_thresh.TabIndex = 21;
            this.btn_set_FR_thresh.Text = "set";
            this.btn_set_FR_thresh.UseVisualStyleBackColor = true;
            this.btn_set_FR_thresh.Click += new System.EventHandler(this.btn_set_FR_thresh_Click);
            // 
            // btn_setMoni_elecs
            // 
            this.btn_setMoni_elecs.Location = new System.Drawing.Point(29, 20);
            this.btn_setMoni_elecs.Name = "btn_setMoni_elecs";
            this.btn_setMoni_elecs.Size = new System.Drawing.Size(118, 48);
            this.btn_setMoni_elecs.TabIndex = 22;
            this.btn_setMoni_elecs.Text = "Set Monitoring Electrodes";
            this.btn_setMoni_elecs.UseVisualStyleBackColor = true;
            this.btn_setMoni_elecs.Click += new System.EventHandler(this.btn_setMoni_elecs_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(625, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(33, 492);
            this.panel1.TabIndex = 23;
            // 
            // txt_max_FR
            // 
            this.txt_max_FR.AutoSize = true;
            this.txt_max_FR.Location = new System.Drawing.Point(627, 109);
            this.txt_max_FR.Name = "txt_max_FR";
            this.txt_max_FR.Size = new System.Drawing.Size(44, 13);
            this.txt_max_FR.TabIndex = 24;
            this.txt_max_FR.Text = "Max FR";
            // 
            // txt_min_FR
            // 
            this.txt_min_FR.AutoSize = true;
            this.txt_min_FR.Location = new System.Drawing.Point(626, 627);
            this.txt_min_FR.Name = "txt_min_FR";
            this.txt_min_FR.Size = new System.Drawing.Size(40, 13);
            this.txt_min_FR.TabIndex = 25;
            this.txt_min_FR.Text = "min FR";
            this.txt_min_FR.Click += new System.EventHandler(this.txt_min_FR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.check_well_F);
            this.groupBox1.Controls.Add(this.check_well_E);
            this.groupBox1.Controls.Add(this.check_well_D);
            this.groupBox1.Controls.Add(this.check_well_C);
            this.groupBox1.Controls.Add(this.check_well_B);
            this.groupBox1.Controls.Add(this.check_well_A);
            this.groupBox1.Location = new System.Drawing.Point(22, 705);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 37);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(18, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "6 well";
            // 
            // check_well_F
            // 
            this.check_well_F.AutoSize = true;
            this.check_well_F.Location = new System.Drawing.Point(566, 13);
            this.check_well_F.Name = "check_well_F";
            this.check_well_F.Size = new System.Drawing.Size(56, 17);
            this.check_well_F.TabIndex = 28;
            this.check_well_F.Text = "Well F";
            this.check_well_F.UseVisualStyleBackColor = true;
            this.check_well_F.CheckedChanged += new System.EventHandler(this.check_well_F_CheckedChanged);
            // 
            // check_well_E
            // 
            this.check_well_E.AutoSize = true;
            this.check_well_E.Location = new System.Drawing.Point(464, 13);
            this.check_well_E.Name = "check_well_E";
            this.check_well_E.Size = new System.Drawing.Size(57, 17);
            this.check_well_E.TabIndex = 27;
            this.check_well_E.Text = "Well E";
            this.check_well_E.UseVisualStyleBackColor = true;
            this.check_well_E.CheckedChanged += new System.EventHandler(this.check_well_E_CheckedChanged);
            // 
            // check_well_D
            // 
            this.check_well_D.AutoSize = true;
            this.check_well_D.Location = new System.Drawing.Point(360, 13);
            this.check_well_D.Name = "check_well_D";
            this.check_well_D.Size = new System.Drawing.Size(58, 17);
            this.check_well_D.TabIndex = 3;
            this.check_well_D.Text = "Well D";
            this.check_well_D.UseVisualStyleBackColor = true;
            this.check_well_D.CheckedChanged += new System.EventHandler(this.check_well_D_CheckedChanged);
            // 
            // check_well_C
            // 
            this.check_well_C.AutoSize = true;
            this.check_well_C.Location = new System.Drawing.Point(265, 13);
            this.check_well_C.Name = "check_well_C";
            this.check_well_C.Size = new System.Drawing.Size(57, 17);
            this.check_well_C.TabIndex = 2;
            this.check_well_C.Text = "Well C";
            this.check_well_C.UseVisualStyleBackColor = true;
            this.check_well_C.CheckedChanged += new System.EventHandler(this.check_well_C_CheckedChanged);
            // 
            // check_well_B
            // 
            this.check_well_B.AutoSize = true;
            this.check_well_B.Location = new System.Drawing.Point(171, 13);
            this.check_well_B.Name = "check_well_B";
            this.check_well_B.Size = new System.Drawing.Size(57, 17);
            this.check_well_B.TabIndex = 1;
            this.check_well_B.Text = "Well B";
            this.check_well_B.UseVisualStyleBackColor = true;
            this.check_well_B.CheckedChanged += new System.EventHandler(this.check_well_B_CheckedChanged);
            // 
            // check_well_A
            // 
            this.check_well_A.AutoSize = true;
            this.check_well_A.Location = new System.Drawing.Point(81, 13);
            this.check_well_A.Name = "check_well_A";
            this.check_well_A.Size = new System.Drawing.Size(57, 17);
            this.check_well_A.TabIndex = 0;
            this.check_well_A.Text = "Well A";
            this.check_well_A.UseVisualStyleBackColor = true;
            this.check_well_A.CheckedChanged += new System.EventHandler(this.check_well_A_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_well_J_9);
            this.groupBox2.Controls.Add(this.check_well_H_9);
            this.groupBox2.Controls.Add(this.check_well_G_9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.check_well_F_9);
            this.groupBox2.Controls.Add(this.check_well_E_9);
            this.groupBox2.Controls.Add(this.check_well_D_9);
            this.groupBox2.Controls.Add(this.check_well_C_9);
            this.groupBox2.Controls.Add(this.check_well_B_9);
            this.groupBox2.Controls.Add(this.check_well_A_9);
            this.groupBox2.Location = new System.Drawing.Point(22, 750);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 37);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // check_well_J_9
            // 
            this.check_well_J_9.AutoSize = true;
            this.check_well_J_9.Location = new System.Drawing.Point(562, 13);
            this.check_well_J_9.Name = "check_well_J_9";
            this.check_well_J_9.Size = new System.Drawing.Size(55, 17);
            this.check_well_J_9.TabIndex = 31;
            this.check_well_J_9.Text = "Well J";
            this.check_well_J_9.UseVisualStyleBackColor = true;
            this.check_well_J_9.CheckedChanged += new System.EventHandler(this.check_well_J_9_CheckedChanged);
            // 
            // check_well_H_9
            // 
            this.check_well_H_9.AutoSize = true;
            this.check_well_H_9.Location = new System.Drawing.Point(500, 13);
            this.check_well_H_9.Name = "check_well_H_9";
            this.check_well_H_9.Size = new System.Drawing.Size(58, 17);
            this.check_well_H_9.TabIndex = 30;
            this.check_well_H_9.Text = "Well H";
            this.check_well_H_9.UseVisualStyleBackColor = true;
            this.check_well_H_9.CheckedChanged += new System.EventHandler(this.check_well_H_9_CheckedChanged);
            // 
            // check_well_G_9
            // 
            this.check_well_G_9.AutoSize = true;
            this.check_well_G_9.Location = new System.Drawing.Point(439, 13);
            this.check_well_G_9.Name = "check_well_G_9";
            this.check_well_G_9.Size = new System.Drawing.Size(58, 17);
            this.check_well_G_9.TabIndex = 29;
            this.check_well_G_9.Text = "Well G";
            this.check_well_G_9.UseVisualStyleBackColor = true;
            this.check_well_G_9.CheckedChanged += new System.EventHandler(this.check_well_G_9_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(18, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "9 well";
            // 
            // check_well_F_9
            // 
            this.check_well_F_9.AutoSize = true;
            this.check_well_F_9.Location = new System.Drawing.Point(380, 13);
            this.check_well_F_9.Name = "check_well_F_9";
            this.check_well_F_9.Size = new System.Drawing.Size(56, 17);
            this.check_well_F_9.TabIndex = 28;
            this.check_well_F_9.Text = "Well F";
            this.check_well_F_9.UseVisualStyleBackColor = true;
            this.check_well_F_9.CheckedChanged += new System.EventHandler(this.check_well_F_9_CheckedChanged);
            // 
            // check_well_E_9
            // 
            this.check_well_E_9.AutoSize = true;
            this.check_well_E_9.Location = new System.Drawing.Point(320, 13);
            this.check_well_E_9.Name = "check_well_E_9";
            this.check_well_E_9.Size = new System.Drawing.Size(57, 17);
            this.check_well_E_9.TabIndex = 27;
            this.check_well_E_9.Text = "Well E";
            this.check_well_E_9.UseVisualStyleBackColor = true;
            this.check_well_E_9.CheckedChanged += new System.EventHandler(this.check_well_E_9_CheckedChanged);
            // 
            // check_well_D_9
            // 
            this.check_well_D_9.AutoSize = true;
            this.check_well_D_9.Location = new System.Drawing.Point(259, 13);
            this.check_well_D_9.Name = "check_well_D_9";
            this.check_well_D_9.Size = new System.Drawing.Size(58, 17);
            this.check_well_D_9.TabIndex = 3;
            this.check_well_D_9.Text = "Well D";
            this.check_well_D_9.UseVisualStyleBackColor = true;
            this.check_well_D_9.CheckedChanged += new System.EventHandler(this.check_well_D_9_CheckedChanged);
            // 
            // check_well_C_9
            // 
            this.check_well_C_9.AutoSize = true;
            this.check_well_C_9.Location = new System.Drawing.Point(200, 13);
            this.check_well_C_9.Name = "check_well_C_9";
            this.check_well_C_9.Size = new System.Drawing.Size(57, 17);
            this.check_well_C_9.TabIndex = 2;
            this.check_well_C_9.Text = "Well C";
            this.check_well_C_9.UseVisualStyleBackColor = true;
            this.check_well_C_9.CheckedChanged += new System.EventHandler(this.check_well_C_9_CheckedChanged);
            // 
            // check_well_B_9
            // 
            this.check_well_B_9.AutoSize = true;
            this.check_well_B_9.Location = new System.Drawing.Point(140, 13);
            this.check_well_B_9.Name = "check_well_B_9";
            this.check_well_B_9.Size = new System.Drawing.Size(57, 17);
            this.check_well_B_9.TabIndex = 1;
            this.check_well_B_9.Text = "Well B";
            this.check_well_B_9.UseVisualStyleBackColor = true;
            this.check_well_B_9.CheckedChanged += new System.EventHandler(this.check_well_B_9_CheckedChanged);
            // 
            // check_well_A_9
            // 
            this.check_well_A_9.AutoSize = true;
            this.check_well_A_9.Location = new System.Drawing.Point(81, 13);
            this.check_well_A_9.Name = "check_well_A_9";
            this.check_well_A_9.Size = new System.Drawing.Size(57, 17);
            this.check_well_A_9.TabIndex = 0;
            this.check_well_A_9.Text = "Well A";
            this.check_well_A_9.UseVisualStyleBackColor = true;
            this.check_well_A_9.CheckedChanged += new System.EventHandler(this.check_well_A_9_CheckedChanged);
            // 
            // chooseElectrodesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 817);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_min_FR);
            this.Controls.Add(this.txt_max_FR);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_setMoni_elecs);
            this.Controls.Add(this.btn_set_FR_thresh);
            this.Controls.Add(this.bnt_reset_FRs);
            this.Controls.Add(this.btn_chooseActive);
            this.Controls.Add(this.btn_set_auto_interval);
            this.Controls.Add(this.btn_getActiveElecs);
            this.Controls.Add(this.check_auto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_update_s);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_FR_thresh);
            this.Controls.Add(this.check_all);
            this.Name = "chooseElectrodesForm";
            this.Text = "chooseElectrodesForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox check_all;
        private System.Windows.Forms.Button bnt_reset_FRs;
        private System.Windows.Forms.Button btn_chooseActive;
        private System.Windows.Forms.Button btn_set_auto_interval;
        private System.Windows.Forms.Button btn_getActiveElecs;
        private System.Windows.Forms.CheckBox check_auto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_update_s;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FR_thresh;
        private System.Windows.Forms.Button btn_set_FR_thresh;
        private System.Windows.Forms.Button btn_setMoni_elecs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txt_max_FR;
        private System.Windows.Forms.Label txt_min_FR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox check_well_F;
        private System.Windows.Forms.CheckBox check_well_E;
        private System.Windows.Forms.CheckBox check_well_D;
        private System.Windows.Forms.CheckBox check_well_C;
        private System.Windows.Forms.CheckBox check_well_B;
        private System.Windows.Forms.CheckBox check_well_A;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox check_well_J_9;
        private System.Windows.Forms.CheckBox check_well_H_9;
        private System.Windows.Forms.CheckBox check_well_G_9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_well_F_9;
        private System.Windows.Forms.CheckBox check_well_E_9;
        private System.Windows.Forms.CheckBox check_well_D_9;
        private System.Windows.Forms.CheckBox check_well_C_9;
        private System.Windows.Forms.CheckBox check_well_B_9;
        private System.Windows.Forms.CheckBox check_well_A_9;
    }
}