
namespace OnlineSpikeDetection
{
    partial class ThreshFrom
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
            this.btn_startDacq = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_stds = new System.Windows.Forms.TextBox();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.btn_set_filter = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_filter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_startDacq
            // 
            this.btn_startDacq.Location = new System.Drawing.Point(209, 25);
            this.btn_startDacq.Name = "btn_startDacq";
            this.btn_startDacq.Size = new System.Drawing.Size(93, 22);
            this.btn_startDacq.TabIndex = 0;
            this.btn_startDacq.Text = "Auto Threshold";
            this.btn_startDacq.UseVisualStyleBackColor = true;
            this.btn_startDacq.Click += new System.EventHandler(this.btn_startDacq_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 10);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "sigmas";
            // 
            // txt_stds
            // 
            this.txt_stds.Location = new System.Drawing.Point(315, 26);
            this.txt_stds.Name = "txt_stds";
            this.txt_stds.Size = new System.Drawing.Size(36, 20);
            this.txt_stds.TabIndex = 2;
            this.txt_stds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_stds.TextChanged += new System.EventHandler(this.text_stds_TextChanged);
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(44, 27);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(159, 21);
            this.cbDeviceList.TabIndex = 14;
            // 
            // btn_set_filter
            // 
            this.btn_set_filter.Enabled = false;
            this.btn_set_filter.Location = new System.Drawing.Point(545, 26);
            this.btn_set_filter.Name = "btn_set_filter";
            this.btn_set_filter.Size = new System.Drawing.Size(32, 23);
            this.btn_set_filter.TabIndex = 35;
            this.btn_set_filter.Text = "set";
            this.btn_set_filter.UseVisualStyleBackColor = true;
            this.btn_set_filter.Click += new System.EventHandler(this.btn_set_filter_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(391, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "High Pass Filter [Hz]";
            // 
            // txt_filter
            // 
            this.txt_filter.Location = new System.Drawing.Point(499, 27);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(40, 20);
            this.txt_filter.TabIndex = 33;
            this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
            // 
            // ThreshFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 910);
            this.Controls.Add(this.btn_set_filter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_filter);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.txt_stds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startDacq);
            this.Name = "ThreshFrom";
            this.Text = "ThreshFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_startDacq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_stds;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.Button btn_set_filter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_filter;
    }
}