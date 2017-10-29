namespace MusicPlayer
{
    partial class CoverShowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoverShowForm));
            this.pic_CoverShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CoverShow)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_CoverShow
            // 
            resources.ApplyResources(this.pic_CoverShow, "pic_CoverShow");
            this.pic_CoverShow.Name = "pic_CoverShow";
            this.pic_CoverShow.TabStop = false;
            this.pic_CoverShow.Click += new System.EventHandler(this.pic_CoverShow_Click);
            this.pic_CoverShow.DoubleClick += new System.EventHandler(this.pic_CoverShow_DoubleClick);
            this.pic_CoverShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_CoverShow_MouseDown);
            this.pic_CoverShow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_CoverShow_MouseMove);
            this.pic_CoverShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_CoverShow_MouseUp);
            // 
            // CoverShowForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pic_CoverShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "CoverShowForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Deactivate += new System.EventHandler(this.CoverShowForm_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoverShowForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pic_CoverShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pic_CoverShow;
    }
}