using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bibliographie
{
    public class SpleenScreen : Form
    {
        private IContainer components;

        private Label label1;

        private ProgressBar progressBar1;

        public SpleenScreen()
        {
            this.InitializeComponent();
        }

        private void SpleenScreen_Load(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.progressBar1 = new ProgressBar();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 22f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(158, 89);
            this.label1.Name = "label1";
            this.label1.Size = new Size(155, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loading....";
            this.progressBar1.Location = new Point(164, 128);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(149, 23);
            this.progressBar1.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(483, 206);
            base.Controls.Add(this.progressBar1);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "SpleenScreen";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SpleenScreen";
            base.Load += new EventHandler(this.SpleenScreen_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
