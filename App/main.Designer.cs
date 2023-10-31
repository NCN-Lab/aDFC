
namespace OnlineSpikeDetection
{
    partial class main
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
            this.btn_autoThresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bnt_chooseElecs = new System.Windows.Forms.Button();
            this.bnt_dataViewer = new System.Windows.Forms.Button();
            this.btn_poisson_stimulator = new System.Windows.Forms.Button();
            this.btn_TestPoisson = new System.Windows.Forms.Button();
            this.btn_effectiveStim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_autoThresh
            // 
            this.btn_autoThresh.Location = new System.Drawing.Point(30, 26);
            this.btn_autoThresh.Name = "btn_autoThresh";
            this.btn_autoThresh.Size = new System.Drawing.Size(133, 35);
            this.btn_autoThresh.TabIndex = 0;
            this.btn_autoThresh.Text = "Auto Threshold";
            this.btn_autoThresh.UseVisualStyleBackColor = true;
            this.btn_autoThresh.Click += new System.EventHandler(this.btn_autoThresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delayed Controller";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bnt_chooseElecs
            // 
            this.bnt_chooseElecs.Location = new System.Drawing.Point(207, 26);
            this.bnt_chooseElecs.Name = "bnt_chooseElecs";
            this.bnt_chooseElecs.Size = new System.Drawing.Size(133, 35);
            this.bnt_chooseElecs.TabIndex = 2;
            this.bnt_chooseElecs.Text = "Monitoring Electrodes";
            this.bnt_chooseElecs.UseVisualStyleBackColor = true;
            this.bnt_chooseElecs.Click += new System.EventHandler(this.bnt_chooseElecs_Click);
            // 
            // bnt_dataViewer
            // 
            this.bnt_dataViewer.Enabled = false;
            this.bnt_dataViewer.Location = new System.Drawing.Point(738, 26);
            this.bnt_dataViewer.Name = "bnt_dataViewer";
            this.bnt_dataViewer.Size = new System.Drawing.Size(133, 35);
            this.bnt_dataViewer.TabIndex = 3;
            this.bnt_dataViewer.Text = "Data Viewer";
            this.bnt_dataViewer.UseVisualStyleBackColor = true;
            this.bnt_dataViewer.Click += new System.EventHandler(this.bnt_dataViewer_Click);
            // 
            // btn_poisson_stimulator
            // 
            this.btn_poisson_stimulator.Location = new System.Drawing.Point(382, 26);
            this.btn_poisson_stimulator.Name = "btn_poisson_stimulator";
            this.btn_poisson_stimulator.Size = new System.Drawing.Size(133, 35);
            this.btn_poisson_stimulator.TabIndex = 4;
            this.btn_poisson_stimulator.Text = "Stimulator";
            this.btn_poisson_stimulator.UseVisualStyleBackColor = true;
            this.btn_poisson_stimulator.Click += new System.EventHandler(this.btn_poisson_stimulator_Click);
            // 
            // btn_TestPoisson
            // 
            this.btn_TestPoisson.Enabled = false;
            this.btn_TestPoisson.Location = new System.Drawing.Point(1104, 26);
            this.btn_TestPoisson.Name = "btn_TestPoisson";
            this.btn_TestPoisson.Size = new System.Drawing.Size(133, 35);
            this.btn_TestPoisson.TabIndex = 5;
            this.btn_TestPoisson.Text = "Test Poisson";
            this.btn_TestPoisson.UseVisualStyleBackColor = true;
            this.btn_TestPoisson.Click += new System.EventHandler(this.btn_TestPoisson_Click);
            // 
            // btn_effectiveStim
            // 
            this.btn_effectiveStim.Location = new System.Drawing.Point(920, 26);
            this.btn_effectiveStim.Name = "btn_effectiveStim";
            this.btn_effectiveStim.Size = new System.Drawing.Size(133, 35);
            this.btn_effectiveStim.TabIndex = 6;
            this.btn_effectiveStim.Text = "Effective Stims Elecs";
            this.btn_effectiveStim.UseVisualStyleBackColor = true;
            this.btn_effectiveStim.Click += new System.EventHandler(this.btn_effectiveStim_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 85);
            this.Controls.Add(this.btn_effectiveStim);
            this.Controls.Add(this.btn_TestPoisson);
            this.Controls.Add(this.btn_poisson_stimulator);
            this.Controls.Add(this.bnt_dataViewer);
            this.Controls.Add(this.bnt_chooseElecs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_autoThresh);
            this.Name = "main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_autoThresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bnt_chooseElecs;
        private System.Windows.Forms.Button bnt_dataViewer;
        private System.Windows.Forms.Button btn_poisson_stimulator;
        private System.Windows.Forms.Button btn_TestPoisson;
        private System.Windows.Forms.Button btn_effectiveStim;
    }
}

