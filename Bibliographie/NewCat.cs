using Bibliographie.Dao;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bibliographie
{
    public class NewCat : Form
    {
        private IContainer components;

        private Label label1;

        private Label label2;

        private Label labelCatParent;

        private TextBox textBoxNewCatName;

        private Button buttonOk;

        private Button buttonCancel;

        private Category _parent;

        private Category _newCategory;

        public Category NewCategory
        {
            get
            {
                return this._newCategory;
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
            this.label2 = new Label();
            this.labelCatParent = new Label();
            this.textBoxNewCatName = new TextBox();
            this.buttonOk = new Button();
            this.buttonCancel = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entrez le nom de la nouvelle catégorie";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "à ajouter à";
            this.labelCatParent.AutoSize = true;
            this.labelCatParent.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelCatParent.Location = new Point(70, 30);
            this.labelCatParent.Name = "labelCatParent";
            this.labelCatParent.Size = new Size(90, 13);
            this.labelCatParent.TabIndex = 2;
            this.labelCatParent.Text = "labelCatParent";
            this.textBoxNewCatName.Location = new Point(12, 50);
            this.textBoxNewCatName.Name = "textBoxNewCatName";
            this.textBoxNewCatName.Size = new Size(187, 20);
            this.textBoxNewCatName.TabIndex = 3;
            this.buttonOk.Location = new Point(43, 76);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(124, 76);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            base.AcceptButton = this.buttonOk;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(211, 108);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOk);
            base.Controls.Add(this.textBoxNewCatName);
            base.Controls.Add(this.labelCatParent);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "NewCat";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nouvelle catégorie";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public NewCat()
        {
            this.InitializeComponent();
        }

        public NewCat(Category parent) : this()
        {
            this._parent = parent;
            if (this._parent != null)
            {
                this.labelCatParent.Text = this._parent.Name;
                return;
            }
            this.labelCatParent.Text = "Catégorie parent";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxNewCatName.Text))
            {
                if (this._parent != null)
                {
                    this._newCategory = new Category(0, this.textBoxNewCatName.Text, this._parent.Id);
                }
                else
                {
                    this._newCategory = new Category(0, this.textBoxNewCatName.Text, 0);
                }
                base.DialogResult = DialogResult.OK;
            }
        }
    }
}
