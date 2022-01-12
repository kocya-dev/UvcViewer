namespace UvcViewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._deviceSelectControl = new UvcViewer.Controls.DeviceSelectControl();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _deviceSelectControl
            // 
            this._deviceSelectControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._deviceSelectControl.Location = new System.Drawing.Point(12, 12);
            this._deviceSelectControl.MinimumSize = new System.Drawing.Size(44, 99);
            this._deviceSelectControl.Name = "_deviceSelectControl";
            this._deviceSelectControl.Size = new System.Drawing.Size(440, 122);
            this._deviceSelectControl.TabIndex = 0;
            this._deviceSelectControl.ResolutionSelected += new System.EventHandler(this._deviceSelectControl_ResolutionSelected);
            // 
            // _pictureBox
            // 
            this._pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBox.Location = new System.Drawing.Point(12, 140);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(440, 244);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 1;
            this._pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 396);
            this.Controls.Add(this._pictureBox);
            this.Controls.Add(this._deviceSelectControl);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DeviceSelectControl _deviceSelectControl;
        private PictureBox _pictureBox;
    }
}