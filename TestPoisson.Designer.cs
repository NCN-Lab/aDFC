
namespace OnlineSpikeDetection
{
    partial class TestPoisson
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
            this.btn_set_minInterStim = new System.Windows.Forms.Button();
            this.txt_minInterStim_s = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_set = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_mean_rate = new System.Windows.Forms.TextBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_set_minInterStim
            // 
            this.btn_set_minInterStim.Location = new System.Drawing.Point(78, 91);
            this.btn_set_minInterStim.Name = "btn_set_minInterStim";
            this.btn_set_minInterStim.Size = new System.Drawing.Size(30, 23);
            this.btn_set_minInterStim.TabIndex = 17;
            this.btn_set_minInterStim.Text = "set";
            this.btn_set_minInterStim.UseVisualStyleBackColor = true;
            this.btn_set_minInterStim.Click += new System.EventHandler(this.btn_set_minInterStim_Click);
            // 
            // txt_minInterStim_s
            // 
            this.txt_minInterStim_s.Location = new System.Drawing.Point(27, 91);
            this.txt_minInterStim_s.Name = "txt_minInterStim_s";
            this.txt_minInterStim_s.Size = new System.Drawing.Size(46, 20);
            this.txt_minInterStim_s.TabIndex = 16;
            this.txt_minInterStim_s.TextChanged += new System.EventHandler(this.txt_minInterStim_s_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Min Inter-Stim interval [s]";
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(74, 35);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(29, 23);
            this.btn_set.TabIndex = 15;
            this.btn_set.Text = "set";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mean Rate [Hz]";
            // 
            // txt_mean_rate
            // 
            this.txt_mean_rate.Location = new System.Drawing.Point(25, 37);
            this.txt_mean_rate.Name = "txt_mean_rate";
            this.txt_mean_rate.Size = new System.Drawing.Size(43, 20);
            this.txt_mean_rate.TabIndex = 13;
            this.txt_mean_rate.TextChanged += new System.EventHandler(this.txt_mean_rate_TextChanged);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(164, 91);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 20;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(164, 36);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 19;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // TestPoisson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 142);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_set_minInterStim);
            this.Controls.Add(this.txt_minInterStim_s);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_mean_rate);
            this.Name = "TestPoisson";
            this.Text = "TestPoisson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_set_minInterStim;
        private System.Windows.Forms.TextBox txt_minInterStim_s;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_mean_rate;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
    }
}