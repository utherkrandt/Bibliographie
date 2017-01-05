using Bibliographie.Dao;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bibliographie
{
    public class ModCat : Form
    {
        private IContainer components;

        private Label label1;

        private Label labelCategorieNom;

        private Label label2;

        private Label labelDeplacerDans;

        private TextBox textBoxNewCategoryName;

        private ComboBox comboBoxCategories;

        private Button buttonOK;

        private Button buttonAnnuler;

        private string _modifyCategory;

        private Category _oldCategory;

        public string ModifiedCategory
        {
            get
            {
                return this._modifyCategory;
            }
        }

        public Category OldCategory
        {
            get
            {
                return this._oldCategory;
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
            this.labelCategorieNom = new Label();
            this.label2 = new Label();
            this.labelDeplacerDans = new Label();
            this.textBoxNewCategoryName = new TextBox();
            this.comboBoxCategories = new ComboBox();
            this.buttonOK = new Button();
            this.buttonAnnuler = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vous allez modifier la catégorie";
            this.labelCategorieNom.AutoSize = true;
            this.labelCategorieNom.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelCategorieNom.Location = new Point(160, 20);
            this.labelCategorieNom.Name = "labelCategorieNom";
            this.labelCategorieNom.Size = new Size(85, 13);
            this.labelCategorieNom.TabIndex = 1;
            this.labelCategorieNom.Text = "labelCatName";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nouveau nom :";
            this.labelDeplacerDans.AutoSize = true;
            this.labelDeplacerDans.Location = new Point(12, 80);
            this.labelDeplacerDans.Name = "labelDeplacerDans";
            this.labelDeplacerDans.Size = new Size(82, 13);
            this.labelDeplacerDans.TabIndex = 3;
            this.labelDeplacerDans.Text = "Déplacer dans :";
            this.textBoxNewCategoryName.Location = new Point(100, 47);
            this.textBoxNewCategoryName.Name = "textBoxNewCategoryName";
            this.textBoxNewCategoryName.Size = new Size(200, 20);
            this.textBoxNewCategoryName.TabIndex = 4;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new Point(100, 77);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new Size(200, 21);
            this.comboBoxCategories.TabIndex = 5;
            this.buttonOK.Location = new Point(144, 113);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonAnnuler.DialogResult = DialogResult.Cancel;
            this.buttonAnnuler.Location = new Point(225, 113);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new Size(75, 23);
            this.buttonAnnuler.TabIndex = 7;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonAnnuler;
            base.ClientSize = new Size(312, 148);
            base.Controls.Add(this.buttonAnnuler);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.comboBoxCategories);
            base.Controls.Add(this.textBoxNewCategoryName);
            base.Controls.Add(this.labelDeplacerDans);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.labelCategorieNom);
            base.Controls.Add(this.label1);
            base.Name = "ModCat";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Modification de catégorie";
            base.Load += new EventHandler(this.ModCat_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public ModCat()
        {
            this.InitializeComponent();
        }

        public ModCat(ref Category categoryToModify) : this()
        {
            this._oldCategory = categoryToModify;
            this.labelCategorieNom.Text = this._oldCategory.Name;
            this.textBoxNewCategoryName.Text = this._oldCategory.Name;
            this._modifyCategory = this._oldCategory.Name;
        }

        private void ModCat_Load(object sender, EventArgs e)
        {
            this.comboBoxCategories.DataSource = ((CategoryForm)base.Owner).Factor.GetPossiblyParent(this._oldCategory);
            this.comboBoxCategories.DisplayMember = "Name";
            this.comboBoxCategories.SelectedItem = ((CategoryForm)base.Owner).Factor.GetParent(this._oldCategory);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxNewCategoryName.Text))
            {
                Category category = (Category)this.comboBoxCategories.SelectedItem;
                if (category != null)
                {
                    this._oldCategory.ParentId = category.Id;
                }
                else
                {
                    this._oldCategory.ParentId = 0;
                }
                this._oldCategory.Name = this.textBoxNewCategoryName.Text;
                base.DialogResult = DialogResult.OK;
            }
        }
    }
}
