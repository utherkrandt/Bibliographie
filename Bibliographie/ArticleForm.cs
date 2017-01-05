using Bibliographie.Dao;
using Bibliographie.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Bibliographie
{
    public class ArticleForm : Form
    {
        private IContainer components;

        private Label label1;

        private Label label2;

        private Label label3;

        internal TextBox txtName;

        internal ComboBox cbxCategories;

        internal RichTextBox rtbContent;

        private MenuStrip mainMenu;

        private ToolStripMenuItem editionToolStripMenuItem;

        private ToolStripMenuItem annulerToolStripMenuItem;

        private ToolStripMenuItem rétablirToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator3;

        private ToolStripMenuItem couperToolStripMenuItem;

        private ToolStripMenuItem copierToolStripMenuItem;

        private ToolStripMenuItem collerToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator4;

        private ToolStripMenuItem sélectionnertoutToolStripMenuItem;

        private Button btnCancel;

        private Button btnOk;

        private ToolStrip toolStrip1;

        private ToolStripComboBox tsFont;

        private ToolStripComboBox tsSize;

        private ToolStripButton tsBold;

        private ToolStripButton tsItalic;

        private ToolStripButton tsUnderline;

        private ToolStripSeparator toolStripSeparator1;

        private ToolStripSeparator toolStripSeparator2;

        private ToolStripButton tsCut;

        private ToolStripButton tsCopy;

        private ToolStripButton tsPaste;

        private ToolStripMenuItem policeToolStripMenuItem;

        private FontDialog fontDlg;

        private ToolStripSeparator toolStripSeparator5;

        private ErrorProvider error;

        private ContextMenuStrip ctEditingMenu;

        private ToolStripMenuItem tsCtCut;

        private ToolStripMenuItem tsCtCopy;

        private ToolStripMenuItem tsCtPaste;

        private ToolStripMenuItem tsCtSelect;

        private Article _article;

        private Category _category;

        private string _mode;

        private Font _font;

        private Color _color;

        private int _positionBeam;

        public Category Category
        {
            get
            {
                return this._category;
            }
        }

        public Article Article
        {
            get
            {
                return this._article;
            }
        }

        public string Mode
        {
            get
            {
                return this._mode;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.ctEditingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsCtCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCtCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCtPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCtSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rétablirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.couperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sélectionnertoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.policeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFont = new System.Windows.Forms.ToolStripComboBox();
            this.tsSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.fontDlg = new System.Windows.Forms.FontDialog();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsBold = new System.Windows.Forms.ToolStripButton();
            this.tsItalic = new System.Windows.Forms.ToolStripButton();
            this.tsCut = new System.Windows.Forms.ToolStripButton();
            this.tsCopy = new System.Windows.Forms.ToolStripButton();
            this.tsPaste = new System.Windows.Forms.ToolStripButton();
            this.ctEditingMenu.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Catégorie:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contenu:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(84, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(393, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // cbxCategories
            // 
            this.cbxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(84, 90);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(393, 21);
            this.cbxCategories.TabIndex = 4;
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.ContextMenuStrip = this.ctEditingMenu;
            this.rtbContent.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbContent.Location = new System.Drawing.Point(12, 131);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(481, 358);
            this.rtbContent.TabIndex = 5;
            this.rtbContent.Text = "";
            this.rtbContent.Click += new System.EventHandler(this.rtbContent_Click);
            this.rtbContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtbContent_MouseClick);
            this.rtbContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.rtbContent_MouseDoubleClick);
            // 
            // ctEditingMenu
            // 
            this.ctEditingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCtCut,
            this.tsCtCopy,
            this.tsCtPaste,
            this.tsCtSelect});
            this.ctEditingMenu.Name = "ctEditingMenu";
            this.ctEditingMenu.Size = new System.Drawing.Size(165, 92);
            // 
            // tsCtCut
            // 
            this.tsCtCut.Name = "tsCtCut";
            this.tsCtCut.Size = new System.Drawing.Size(164, 22);
            this.tsCtCut.Tag = "Cut";
            this.tsCtCut.Text = "&Couper";
            this.tsCtCut.Click += new System.EventHandler(this.EditingOperation);
            // 
            // tsCtCopy
            // 
            this.tsCtCopy.Name = "tsCtCopy";
            this.tsCtCopy.Size = new System.Drawing.Size(164, 22);
            this.tsCtCopy.Tag = "Copy";
            this.tsCtCopy.Text = "Co&pier";
            this.tsCtCopy.Click += new System.EventHandler(this.EditingOperation);
            // 
            // tsCtPaste
            // 
            this.tsCtPaste.Name = "tsCtPaste";
            this.tsCtPaste.Size = new System.Drawing.Size(164, 22);
            this.tsCtPaste.Tag = "Paste";
            this.tsCtPaste.Text = "Col&ler";
            this.tsCtPaste.Click += new System.EventHandler(this.EditingOperation);
            // 
            // tsCtSelect
            // 
            this.tsCtSelect.Name = "tsCtSelect";
            this.tsCtSelect.Size = new System.Drawing.Size(164, 22);
            this.tsCtSelect.Tag = "Select";
            this.tsCtSelect.Text = "Sélectio&nner tout";
            this.tsCtSelect.Click += new System.EventHandler(this.EditingOperation);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editionToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(505, 24);
            this.mainMenu.TabIndex = 6;
            this.mainMenu.Text = "mainMenu";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annulerToolStripMenuItem,
            this.rétablirToolStripMenuItem,
            this.toolStripSeparator3,
            this.couperToolStripMenuItem,
            this.copierToolStripMenuItem,
            this.collerToolStripMenuItem,
            this.toolStripSeparator4,
            this.sélectionnertoutToolStripMenuItem,
            this.policeToolStripMenuItem});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "&Edition";
            // 
            // annulerToolStripMenuItem
            // 
            this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
            this.annulerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.annulerToolStripMenuItem.Tag = "Undo";
            this.annulerToolStripMenuItem.Text = "&Annuler";
            this.annulerToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // rétablirToolStripMenuItem
            // 
            this.rétablirToolStripMenuItem.Name = "rétablirToolStripMenuItem";
            this.rétablirToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rétablirToolStripMenuItem.Tag = "Redo";
            this.rétablirToolStripMenuItem.Text = "&Rétablir";
            this.rétablirToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // couperToolStripMenuItem
            // 
            this.couperToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.couperToolStripMenuItem.Name = "couperToolStripMenuItem";
            this.couperToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.couperToolStripMenuItem.Tag = "Cut";
            this.couperToolStripMenuItem.Text = "&Couper";
            this.couperToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // copierToolStripMenuItem
            // 
            this.copierToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copierToolStripMenuItem.Name = "copierToolStripMenuItem";
            this.copierToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copierToolStripMenuItem.Tag = "Copy";
            this.copierToolStripMenuItem.Text = "Co&pier";
            this.copierToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // collerToolStripMenuItem
            // 
            this.collerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collerToolStripMenuItem.Name = "collerToolStripMenuItem";
            this.collerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.collerToolStripMenuItem.Tag = "Paste";
            this.collerToolStripMenuItem.Text = "Co&ller";
            this.collerToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // sélectionnertoutToolStripMenuItem
            // 
            this.sélectionnertoutToolStripMenuItem.Name = "sélectionnertoutToolStripMenuItem";
            this.sélectionnertoutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.sélectionnertoutToolStripMenuItem.Tag = "Select";
            this.sélectionnertoutToolStripMenuItem.Text = "Sélectio&nner tout";
            this.sélectionnertoutToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // policeToolStripMenuItem
            // 
            this.policeToolStripMenuItem.Name = "policeToolStripMenuItem";
            this.policeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.policeToolStripMenuItem.Tag = "Police";
            this.policeToolStripMenuItem.Text = "Police...";
            this.policeToolStripMenuItem.Click += new System.EventHandler(this.EditingOperation);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(418, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(337, 495);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFont,
            this.tsSize,
            this.toolStripSeparator1,
            this.tsBold,
            this.tsItalic,
            this.tsUnderline,
            this.toolStripSeparator2,
            this.tsCut,
            this.tsCopy,
            this.tsPaste,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(505, 29);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsFont
            // 
            this.tsFont.Name = "tsFont";
            this.tsFont.Size = new System.Drawing.Size(151, 29);
            // 
            // tsSize
            // 
            this.tsSize.Name = "tsSize";
            this.tsSize.Size = new System.Drawing.Size(75, 29);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // tsUnderline
            // 
            this.tsUnderline.CheckOnClick = true;
            this.tsUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUnderline.Image = global::Bibliographie.Properties.Resources.img_underline;
            this.tsUnderline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUnderline.Name = "tsUnderline";
            this.tsUnderline.Size = new System.Drawing.Size(27, 26);
            this.tsUnderline.Tag = "Underline";
            this.tsUnderline.Text = "toolStripButton3";
            this.tsUnderline.ToolTipText = "Souligné";
            this.tsUnderline.Click += new System.EventHandler(this.ChangeStyle);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // fontDlg
            // 
            this.fontDlg.ShowColor = true;
            // 
            // error
            // 
            this.error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.error.ContainerControl = this;
            // 
            // tsBold
            // 
            this.tsBold.CheckOnClick = true;
            this.tsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBold.Image = global::Bibliographie.Properties.Resources.img_bold;
            this.tsBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBold.Name = "tsBold";
            this.tsBold.Size = new System.Drawing.Size(27, 26);
            this.tsBold.Tag = "Bold";
            this.tsBold.Text = "toolStripButton1";
            this.tsBold.ToolTipText = "Gras";
            this.tsBold.Click += new System.EventHandler(this.ChangeStyle);
            // 
            // tsItalic
            // 
            this.tsItalic.CheckOnClick = true;
            this.tsItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsItalic.Image = global::Bibliographie.Properties.Resources.img_italic;
            this.tsItalic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsItalic.Name = "tsItalic";
            this.tsItalic.Size = new System.Drawing.Size(27, 26);
            this.tsItalic.Tag = "Italic";
            this.tsItalic.Text = "toolStripButton2";
            this.tsItalic.ToolTipText = "Italic";
            this.tsItalic.Click += new System.EventHandler(this.ChangeStyle);
            // 
            // tsCut
            // 
            this.tsCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCut.Image = ((System.Drawing.Image)(resources.GetObject("tsCut.Image")));
            this.tsCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCut.Name = "tsCut";
            this.tsCut.Size = new System.Drawing.Size(23, 26);
            this.tsCut.Tag = "Cut";
            this.tsCut.Text = "toolStripButton1";
            this.tsCut.ToolTipText = "Couper";
            this.tsCut.Click += new System.EventHandler(this.EditingOperation);
            // 
            // tsCopy
            // 
            this.tsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCopy.Image = global::Bibliographie.Properties.Resources.img_copy;
            this.tsCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCopy.Name = "tsCopy";
            this.tsCopy.Size = new System.Drawing.Size(23, 26);
            this.tsCopy.Tag = "Copy";
            this.tsCopy.Text = "toolStripButton2";
            this.tsCopy.ToolTipText = "Copier";
            this.tsCopy.Click += new System.EventHandler(this.EditingOperation);
            // 
            // tsPaste
            // 
            this.tsPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsPaste.Image")));
            this.tsPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPaste.Name = "tsPaste";
            this.tsPaste.Size = new System.Drawing.Size(23, 26);
            this.tsPaste.Tag = "Paste";
            this.tsPaste.Text = "toolStripButton3";
            this.tsPaste.ToolTipText = "Coller";
            this.tsPaste.Click += new System.EventHandler(this.EditingOperation);
            // 
            // ArticleForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(505, 529);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.cbxCategories);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "ArticleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouvel Article";
            this.Load += new System.EventHandler(this.ArticleForm_Load);
            this.ctEditingMenu.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ArticleForm()
        {
            this.InitializeComponent();
            this.tsFont.ComboBox.DataSource = new InstalledFontCollection().Families;
            this.tsFont.ComboBox.DisplayMember = "Name";
            this.tsSize.Items.AddRange(new string[]
            {
                "8",
                "9",
                "10",
                "11",
                "12",
                "14",
                "16",
                "18",
                "20",
                "22",
                "24",
                "26",
                "28",
                "36",
                "48",
                "72"
            });
            this.tsSize.SelectedIndex = 4;
        }

        public ArticleForm(Article article, Category category) : this()
        {
            this._article = article;
            this._category = category;
            if (this._article.Id == 0)
            {
                this._mode = Operation.Save.ToString();
                return;
            }
            this._mode = Operation.Update.ToString();
        }

        private void ArticleForm_Load(object sender, EventArgs e)
        {
            this.cbxCategories.SelectedIndex = this.cbxCategories.FindString(this._category.Name);
            this.txtName.Text = this._article.Name;
            this.rtbContent.Rtf = this._article.Content;
            this._font = this.rtbContent.SelectionFont;
            this.tsFont.SelectedIndex = this.tsFont.ComboBox.FindString(this.rtbContent.SelectionFont.Name);
            this.tsSize.SelectedIndex = this.tsSize.FindString(this.rtbContent.SelectionFont.Size.ToString());
            if (this.tsSize.SelectedIndex == -1)
            {
                this.tsSize.Text = this.rtbContent.SelectionFont.Size.ToString();
            }
            this.tsSize.SelectedIndexChanged += new EventHandler(this.tsSize_SelectedIndexChanged);
            this.tsFont.SelectedIndexChanged += new EventHandler(this.tsFont_SelectedIndexChanged);
            this.txtName.Focus();
            this.tsCopy.Enabled = false;
            this.copierToolStripMenuItem.Enabled = false;
            this.tsCut.Enabled = false;
            this.couperToolStripMenuItem.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this._article.Name = this.txtName.Text;
            this._article.Content = this.rtbContent.Rtf;
            this._article.Category = (Category)this.cbxCategories.SelectedItem;
        }

        private void EditingOperation(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ToolStripItem toolStripItem = (ToolStripItem)sender;
                string key;
                switch (key = toolStripItem.Tag.ToString())
                {
                    case "Undo":
                        this.rtbContent.Undo();
                        return;
                    case "Redo":
                        this.rtbContent.Redo();
                        return;
                    case "Cut":
                        this.rtbContent.Cut();
                        return;
                    case "Copy":
                        this.rtbContent.Copy();
                        return;
                    case "Paste":
                        this.rtbContent.Paste();
                        return;
                    case "Select":
                        this.rtbContent.SelectAll();
                        return;
                    case "Police":
                        this.fontDlg.Font = this._font;
                        if (this.fontDlg.ShowDialog(this) == DialogResult.OK)
                        {
                            this._font = this.fontDlg.Font;
                            this._color = this.fontDlg.Color;
                            this.rtbContent.SelectionFont = this._font;
                            this.rtbContent.SelectionColor = this._color;
                        }
                        break;

                    
                }
            }
        }

        private void tsFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily[] families = new InstalledFontCollection().Families;
            FontFamily[] array = families;
            for (int i = 0; i < array.Length; i++)
            {
                FontFamily fontFamily = array[i];
                if (fontFamily.Name == ((FontFamily)this.tsFont.SelectedItem).Name)
                {
                    if (!fontFamily.IsStyleAvailable(FontStyle.Regular))
                    {
                        if (!fontFamily.IsStyleAvailable(FontStyle.Bold))
                        {
                            if (fontFamily.IsStyleAvailable(FontStyle.Italic))
                            {
                                this.CreateFont(this.tsFont.SelectedIndex, this.tsSize.FindStringExact(this.rtbContent.SelectionFont.Size.ToString()), FontStyle.Italic);
                            }
                        }
                        else
                        {
                            this.CreateFont(this.tsFont.SelectedIndex, this.tsSize.FindStringExact(this.rtbContent.SelectionFont.Size.ToString()), FontStyle.Bold);
                        }
                    }
                    else
                    {
                        this.CreateFont(this.tsFont.SelectedIndex, this.tsSize.FindStringExact(this.rtbContent.SelectionFont.Size.ToString()), FontStyle.Regular);
                    }
                    this.rtbContent.SelectionFont = this._font;
                    this.rtbContent.SelectionStart = this._positionBeam;
                    this.rtbContent.Focus();
                    return;
                }
            }
        }

        private void tsSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rtbContent.SelectionFont != null)
            {
                this.CreateFont(this.tsFont.FindStringExact(this.rtbContent.SelectionFont.Name), this.tsSize.SelectedIndex, this._font.Style);
            }
            else
            {
                this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.SelectedIndex, this._font.Style);
            }
            this.rtbContent.SelectionFont = this._font;
            this.rtbContent.SelectionStart = this._positionBeam;
            this.rtbContent.Focus();
        }

        private void rtbContent_MouseClick(object sender, MouseEventArgs e)
        {
            this._positionBeam = this.rtbContent.SelectionStart;
            if (this.rtbContent.SelectionFont != null)
            {
                this.tsFont.SelectedIndex = this.tsFont.FindStringExact(this.rtbContent.SelectionFont.Name);
                this.tsSize.SelectedIndex = this.tsSize.FindStringExact(this.rtbContent.SelectionFont.Size.ToString());
                if (this.tsSize.SelectedIndex == -1)
                {
                    this.tsSize.Text = this.rtbContent.SelectionFont.Size.ToString();
                }
            }
            else
            {
                this.tsFont.SelectedIndex = this.tsFont.FindStringExact(this._font.Name);
                this.tsSize.SelectedIndex = this.tsSize.FindStringExact(this._font.Size.ToString());
                if (this.tsSize.SelectedIndex == -1)
                {
                    this.tsSize.Text = this._font.Size.ToString();
                }
            }
            if (this.rtbContent.SelectionLength > 0)
            {
                this.tsCopy.Enabled = true;
                this.copierToolStripMenuItem.Enabled = true;
                this.tsCut.Enabled = true;
                this.couperToolStripMenuItem.Enabled = true;
                return;
            }
            this.tsCopy.Enabled = false;
            this.copierToolStripMenuItem.Enabled = false;
            this.tsCut.Enabled = false;
            this.couperToolStripMenuItem.Enabled = false;
        }

        private void CreateFont(int indexFont, int indexSize, FontStyle fontstyle)
        {
            if (indexSize == -1)
            {
                this._font = null;
                this._font = new Font((FontFamily)this.tsFont.Items[indexFont], this.rtbContent.SelectionFont.Size, fontstyle);
                return;
            }
            this._font = null;
            this._font = new Font((FontFamily)this.tsFont.Items[indexFont], float.Parse(this.tsSize.Items[indexSize].ToString()), fontstyle);
        }

        private void rtbContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this._positionBeam = this.rtbContent.SelectionStart;
            if (this.rtbContent.SelectionFont != null)
            {
                this.tsFont.SelectedIndex = this.tsFont.FindStringExact(this.rtbContent.SelectionFont.Name);
                this.tsSize.SelectedIndex = this.tsSize.FindStringExact(this.rtbContent.SelectionFont.Size.ToString());
                if (this.tsSize.SelectedIndex == -1)
                {
                    this.tsSize.Text = this.rtbContent.SelectionFont.Size.ToString();
                }
            }
            else
            {
                this.tsFont.SelectedIndex = this.tsFont.FindStringExact(this._font.Name);
                this.tsSize.SelectedIndex = this.tsSize.FindStringExact(this._font.Size.ToString());
                if (this.tsSize.SelectedIndex == -1)
                {
                    this.tsSize.Text = this._font.Size.ToString();
                }
            }
            if (this.rtbContent.SelectionLength > 0)
            {
                this.tsCopy.Enabled = true;
                this.copierToolStripMenuItem.Enabled = true;
                this.tsCut.Enabled = true;
                this.couperToolStripMenuItem.Enabled = true;
                return;
            }
            this.tsCopy.Enabled = false;
            this.copierToolStripMenuItem.Enabled = false;
            this.tsCut.Enabled = false;
            this.couperToolStripMenuItem.Enabled = false;
        }

        private void ChangeStyle(object sender, EventArgs e)
        {
            if (sender != null)
            {
                ToolStripItem toolStripItem = (ToolStripItem)sender;
                string a;
                if ((a = toolStripItem.Tag.ToString()) != null)
                {
                    if (!(a == "Bold"))
                    {
                        if (!(a == "Italic"))
                        {
                            if (!(a == "Underline"))
                            {
                                return;
                            }
                            if (this._font.FontFamily.IsStyleAvailable(FontStyle.Underline))
                            {
                                if (this.tsUnderline.Checked)
                                {
                                    this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.FindStringExact(this._font.Size.ToString()), this._font.Style | FontStyle.Underline);
                                    this.rtbContent.SelectionFont = this._font;
                                    return;
                                }
                                this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.FindStringExact(this._font.Size.ToString()), this._font.Style ^ FontStyle.Underline);
                                this.rtbContent.SelectionFont = this._font;
                            }
                        }
                        else if (this._font.FontFamily.IsStyleAvailable(FontStyle.Italic))
                        {
                            if (this.tsItalic.Checked)
                            {
                                this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.FindStringExact(this._font.Size.ToString()), this._font.Style | FontStyle.Italic);
                                this.rtbContent.SelectionFont = this._font;
                                return;
                            }
                            this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.FindStringExact(this._font.Size.ToString()), this._font.Style ^ FontStyle.Italic);
                            this.rtbContent.SelectionFont = this._font;
                            return;
                        }
                    }
                    else if (this._font.FontFamily.IsStyleAvailable(FontStyle.Bold))
                    {
                        if (this.tsBold.Checked)
                        {
                            this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.FindStringExact(this._font.Size.ToString()), this._font.Style | FontStyle.Bold);
                            this.rtbContent.SelectionFont = this._font;
                            return;
                        }
                        this.CreateFont(this.tsFont.FindStringExact(this._font.Name), this.tsSize.FindStringExact(this._font.Size.ToString()), this._font.Style ^ FontStyle.Bold);
                        this.rtbContent.SelectionFont = this._font;
                        return;
                    }
                }
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtName.Text == string.Empty)
            {
                this.error.SetError(this.txtName, "L'article doit posséder un nom");
                this.btnOk.Enabled = false;
                return;
            }
            this.error.Clear();
            this.btnOk.Enabled = true;
        }

        private void rtbContent_Click(object sender, EventArgs e)
        {
            base.AcceptButton = null;
        }
    }
}
