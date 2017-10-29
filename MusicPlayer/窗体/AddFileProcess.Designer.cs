namespace MusicPlayer
{
    partial class ADDFILEPROCESSFORM
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
            this.pb_AddFlieProcess = new System.Windows.Forms.ProgressBar();
            this.btn_CancelAddProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_CurAddFileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_AddFlieProcess
            // 
            this.pb_AddFlieProcess.Location = new System.Drawing.Point(1, 5);
            this.pb_AddFlieProcess.Name = "pb_AddFlieProcess";
            this.pb_AddFlieProcess.Size = new System.Drawing.Size(474, 16);
            this.pb_AddFlieProcess.TabIndex = 0;
            // 
            // btn_CancelAddProcess
            // 
            this.btn_CancelAddProcess.Location = new System.Drawing.Point(400, 23);
            this.btn_CancelAddProcess.Name = "btn_CancelAddProcess";
            this.btn_CancelAddProcess.Size = new System.Drawing.Size(75, 25);
            this.btn_CancelAddProcess.TabIndex = 1;
            this.btn_CancelAddProcess.Text = "取消";
            this.btn_CancelAddProcess.UseVisualStyleBackColor = true;
            this.btn_CancelAddProcess.Click += new System.EventHandler(this.btn_CancelAddProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "正在添加：";
            // 
            // lbl_CurAddFileName
            // 
            this.lbl_CurAddFileName.AutoSize = true;
            this.lbl_CurAddFileName.Location = new System.Drawing.Point(59, 29);
            this.lbl_CurAddFileName.Name = "lbl_CurAddFileName";
            this.lbl_CurAddFileName.Size = new System.Drawing.Size(0, 13);
            this.lbl_CurAddFileName.TabIndex = 3;
            // 
            // ADDFILEPROCESSFORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 49);
            this.Controls.Add(this.btn_CancelAddProcess);
            this.Controls.Add(this.lbl_CurAddFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_AddFlieProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ADDFILEPROCESSFORM";
            this.ShowInTaskbar = false;
            this.Text = "添加文件中 ...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ADDFILEPROCESSFORM_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_AddFlieProcess;
        private System.Windows.Forms.Button btn_CancelAddProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_CurAddFileName;
    }
}