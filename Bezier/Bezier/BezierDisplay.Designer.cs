namespace Bezier
{
    partial class BezierDisplay
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
            //this.components = new System.ComponentModel.Container();
            //this.timer1 = new System.Windows.Forms.Timer(this.components);
            //this.SuspendLayout();
            //// 
            //// timer1
            //// 
            //this.timer1.Interval = 500;
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BezierDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "BezierDisplay";
            this.Size = new System.Drawing.Size(300, 300);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BezierDisplay_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BezierDisplay_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BezierDisplay_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.Timer timer1;
    }
}
