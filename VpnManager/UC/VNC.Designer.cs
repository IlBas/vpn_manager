namespace VpnManager.UC
{
    partial class VNC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RemoteViewing.Vnc.VncClient vncClient2 = new RemoteViewing.Vnc.VncClient();
            this.vncControl = new RemoteViewing.Windows.Forms.VncControl();
            this.SuspendLayout();
            // 
            // vncControl
            // 
            this.vncControl.AllowClipboardSharingFromServer = false;
            this.vncControl.AllowClipboardSharingToServer = false;
            this.vncControl.AllowInput = true;
            this.vncControl.AllowRemoteCursor = true;
            this.vncControl.BackColor = System.Drawing.Color.Black;
            vncClient2.MaxUpdateRate = 15D;
            vncClient2.UserData = null;
            this.vncControl.Client = vncClient2;
            this.vncControl.Location = new System.Drawing.Point(3, 3);
            this.vncControl.Name = "vncControl";
            this.vncControl.Size = new System.Drawing.Size(686, 588);
            this.vncControl.TabIndex = 0;
            this.vncControl.Load += new System.EventHandler(this.vncControl1_Load);
            // 
            // VNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vncControl);
            this.Name = "VNC";
            this.Size = new System.Drawing.Size(692, 594);
            this.ResumeLayout(false);

        }

        #endregion

        private RemoteViewing.Windows.Forms.VncControl vncControl;
    }
}
