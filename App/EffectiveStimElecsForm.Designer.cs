
namespace OnlineSpikeDetection
{
    partial class EfectiveStimElecsForm
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
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.btn_StopDacq = new System.Windows.Forms.Button();
            this.btn_StartDacq = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(28, 33);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(159, 21);
            this.cbDeviceList.TabIndex = 49;
            // 
            // btn_StopDacq
            // 
            this.btn_StopDacq.Enabled = false;
            this.btn_StopDacq.Location = new System.Drawing.Point(322, 33);
            this.btn_StopDacq.Name = "btn_StopDacq";
            this.btn_StopDacq.Size = new System.Drawing.Size(55, 21);
            this.btn_StopDacq.TabIndex = 47;
            this.btn_StopDacq.Text = "Stop";
            this.btn_StopDacq.UseVisualStyleBackColor = true;
            // 
            // btn_StartDacq
            // 
            this.btn_StartDacq.Location = new System.Drawing.Point(257, 33);
            this.btn_StartDacq.Name = "btn_StartDacq";
            this.btn_StartDacq.Size = new System.Drawing.Size(59, 21);
            this.btn_StartDacq.TabIndex = 46;
            this.btn_StartDacq.Text = "Start";
            this.btn_StartDacq.UseVisualStyleBackColor = true;
            this.btn_StartDacq.Click += new System.EventHandler(this.btn_StartDacq_Click);
            // 
            // EfectiveStimElecsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 622);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.btn_StopDacq);
            this.Controls.Add(this.btn_StartDacq);
            this.Name = "EfectiveStimElecsForm";
            this.Text = "EfectiveStimElecsForm";
            this.Load += new System.EventHandler(this.EfectiveStimElecsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.Button btn_StopDacq;
        private System.Windows.Forms.Button btn_StartDacq;
    }
}