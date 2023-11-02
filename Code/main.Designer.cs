
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_autoThresh
            // 
            this.btn_autoThresh.Location = new System.Drawing.Point(51, 82);
            this.btn_autoThresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_autoThresh.Name = "btn_autoThresh";
            this.btn_autoThresh.Size = new System.Drawing.Size(229, 54);
            this.btn_autoThresh.TabIndex = 0;
            this.btn_autoThresh.Text = "Auto Threshold";
            this.btn_autoThresh.UseVisualStyleBackColor = true;
            this.btn_autoThresh.Click += new System.EventHandler(this.btn_autoThresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 304);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "online aDFC ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bnt_chooseElecs
            // 
            this.bnt_chooseElecs.Location = new System.Drawing.Point(51, 156);
            this.bnt_chooseElecs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnt_chooseElecs.Name = "bnt_chooseElecs";
            this.bnt_chooseElecs.Size = new System.Drawing.Size(229, 54);
            this.bnt_chooseElecs.TabIndex = 2;
            this.bnt_chooseElecs.Text = "Monitoring Electrodes";
            this.bnt_chooseElecs.UseVisualStyleBackColor = true;
            this.bnt_chooseElecs.Click += new System.EventHandler(this.bnt_chooseElecs_Click);
            // 
            // bnt_dataViewer
            // 
            this.bnt_dataViewer.Enabled = false;
            this.bnt_dataViewer.Location = new System.Drawing.Point(1107, 40);
            this.bnt_dataViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnt_dataViewer.Name = "bnt_dataViewer";
            this.bnt_dataViewer.Size = new System.Drawing.Size(200, 54);
            this.bnt_dataViewer.TabIndex = 3;
            this.bnt_dataViewer.Text = "Data Viewer";
            this.bnt_dataViewer.UseVisualStyleBackColor = true;
            this.bnt_dataViewer.Click += new System.EventHandler(this.bnt_dataViewer_Click);
            // 
            // btn_poisson_stimulator
            // 
            this.btn_poisson_stimulator.Location = new System.Drawing.Point(51, 230);
            this.btn_poisson_stimulator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_poisson_stimulator.Name = "btn_poisson_stimulator";
            this.btn_poisson_stimulator.Size = new System.Drawing.Size(229, 54);
            this.btn_poisson_stimulator.TabIndex = 4;
            this.btn_poisson_stimulator.Text = "Stimulator";
            this.btn_poisson_stimulator.UseVisualStyleBackColor = true;
            this.btn_poisson_stimulator.Click += new System.EventHandler(this.btn_poisson_stimulator_Click);
            // 
            // btn_TestPoisson
            // 
            this.btn_TestPoisson.Enabled = false;
            this.btn_TestPoisson.Location = new System.Drawing.Point(1656, 40);
            this.btn_TestPoisson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_TestPoisson.Name = "btn_TestPoisson";
            this.btn_TestPoisson.Size = new System.Drawing.Size(200, 54);
            this.btn_TestPoisson.TabIndex = 5;
            this.btn_TestPoisson.Text = "Test Poisson";
            this.btn_TestPoisson.UseVisualStyleBackColor = true;
            this.btn_TestPoisson.Click += new System.EventHandler(this.btn_TestPoisson_Click);
            // 
            // btn_effectiveStim
            // 
            this.btn_effectiveStim.Location = new System.Drawing.Point(1380, 40);
            this.btn_effectiveStim.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_effectiveStim.Name = "btn_effectiveStim";
            this.btn_effectiveStim.Size = new System.Drawing.Size(200, 54);
            this.btn_effectiveStim.TabIndex = 6;
            this.btn_effectiveStim.Text = "Effective Stims Elecs";
            this.btn_effectiveStim.UseVisualStyleBackColor = true;
            this.btn_effectiveStim.Click += new System.EventHandler(this.btn_effectiveStim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(100, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "aDFC app";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 407);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_effectiveStim);
            this.Controls.Add(this.btn_TestPoisson);
            this.Controls.Add(this.btn_poisson_stimulator);
            this.Controls.Add(this.bnt_dataViewer);
            this.Controls.Add(this.bnt_chooseElecs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_autoThresh);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_autoThresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bnt_chooseElecs;
        private System.Windows.Forms.Button bnt_dataViewer;
        private System.Windows.Forms.Button btn_poisson_stimulator;
        private System.Windows.Forms.Button btn_TestPoisson;
        private System.Windows.Forms.Button btn_effectiveStim;
        private System.Windows.Forms.Label label1;
    }
}

