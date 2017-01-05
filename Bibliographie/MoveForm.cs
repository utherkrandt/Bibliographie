using Bibliographie.Dao;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bibliographie
{
    public class MoveForm : Form
    {
        private IContainer components;

        private Label label1;

        internal ComboBox cbxCategorie;

        private Button button1;

        private Button button2;

        private Category _categoryDestination;

        public Category Category
        {
            get
            {
                return this._categoryDestination;
            }
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
            this.cbxCategorie = new ComboBox();
            this.button1 = new Button();
            this.button2 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(196, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sélectionner la catégorie de destination:";
            this.cbxCategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbxCategorie.FormattingEnabled = true;
            this.cbxCategorie.Location = new Point(16, 29);
            this.cbxCategorie.Name = "cbxCategorie";
            this.cbxCategorie.Size = new Size(193, 21);
            this.cbxCategorie.TabIndex = 3;
            this.cbxCategorie.SelectedIndexChanged += new EventHandler(this.cbxCategorie_SelectedIndexChanged);
            this.button1.DialogResult = DialogResult.Cancel;
            this.button1.Location = new Point(135, 57);
            this.button1.Name = "button1";
            this.button1.Size = new Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            this.button2.DialogResult = DialogResult.OK;
            this.button2.Location = new Point(54, 57);
            this.button2.Name = "button2";
            this.button2.Size = new Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            base.AcceptButton = this.button1;
            base.CancelButton = this.button2;
            base.ClientSize = new Size(222, 92);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cbxCategorie);
            base.Name = "MoveForm";
            this.Text = "Déplacer...";
            base.Load += new EventHandler(this.MoveForm_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public MoveForm()
        {
            this.InitializeComponent();
        }

        private void cbxCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._categoryDestination = (Category)this.cbxCategorie.SelectedItem;
        }

        private void MoveForm_Load(object sender, EventArgs e)
        {
        }
    }
}
