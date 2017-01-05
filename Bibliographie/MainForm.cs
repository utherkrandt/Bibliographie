using Bibliographie.Core;
using Bibliographie.Dao;
using Bibliographie.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Bibliographie
{
    public class MainForm : Form
    {
        private CategoryManagement _factor;

        private IList<Category> _categories;

        private IList<Article> _articles;

        private Category _categoryRequest;

        public Thread thread;

        private IContainer components;

        private ToolStrip tsSystem;

        private ToolStripButton ouvrirToolStripButton;

        private ToolStripButton supprimerToolStripButton;

        private ToolStripButton imprimerToolStripButton;

        private ToolStripSeparator toolStripSeparator;

        private MenuStrip mainMenu;

        private ToolStripMenuItem fichierToolStripMenuItem;

        private ToolStripMenuItem nouveauToolStripMenuItem;

        private ToolStripMenuItem ouvrirToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator3;

        private ToolStripMenuItem imprimerToolStripMenuItem;

        private ToolStripMenuItem aperçuavantimpressionToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator4;

        private ToolStripMenuItem quitterToolStripMenuItem;

        private ToolStripMenuItem outilsToolStripMenuItem;

        private ToolStripMenuItem personnaliserToolStripMenuItem;

        private ToolStripMenuItem optionsToolStripMenuItem;

        private TreeView tvwCategorie;

        private Label lblCategorie;

        private ListView lvwCategorie;

        private ColumnHeader chName;

        private ColumnHeader chCreation;

        private ColumnHeader chModification;

        private ToolStripButton nouveauToolStripButton;

        private ToolStripMenuItem supprimerToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator1;

        private ToolStripButton tsMove;

        public MainForm()
        {
            this.InitializeComponent();
        }

        public MainForm(CategoryManagement factor) : this()
        {
            this._factor = factor;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new SpleenScreen();
            this.thread = new Thread(new ThreadStart(this.TreeviewFill));
            this.TreeviewFill();
            this.nouveauToolStripButton.Enabled = false;
            this.nouveauToolStripMenuItem.Enabled = false;
            this.ouvrirToolStripButton.Enabled = false;
            this.ouvrirToolStripMenuItem.Enabled = false;
            this.supprimerToolStripButton.Enabled = false;
            this.supprimerToolStripMenuItem.Enabled = false;
            this.tsMove.Enabled = false;
        }

        public void TreeviewFill()
        {
            this.tvwCategorie.Nodes.Clear();
            this.tvwCategorie.Sort();
            Category category = new Category(0, "Catégories", 0);
            TreeNode treeNode = new TreeNode(category.Name);
            this._categories = this._factor.GetParentsRoot();
            if (this._categories != null)
            {
                foreach (Category current in this._categories)
                {
                    int articlesCount = this._factor.GetArticlesCount(current);
                    TreeNode treeNode2;
                    if (articlesCount > 0)
                    {
                        treeNode2 = new TreeNode(string.Concat(new object[]
                        {
                            current.Name,
                            " (",
                            articlesCount,
                            ")"
                        }));
                    }
                    else
                    {
                        treeNode2 = new TreeNode(current.Name);
                    }
                    treeNode2.Name = current.Name;
                    treeNode2.Tag = current;
                    if (this._factor.HasChilds(current))
                    {
                        treeNode2.Nodes.Add("Chargement des catégories");
                    }
                    treeNode.Nodes.Add(treeNode2);
                }
            }
            this.tvwCategorie.Nodes.Add(treeNode);
            this.tvwCategorie.SelectedNode = this.tvwCategorie.Nodes[0];
            this.tvwCategorie.Nodes[0].Expand();
        }

        private void ParseCategories(Category category, TreeNode tree)
        {
            IList<Category> childs = this._factor.GetChilds(category);
            if (childs != null)
            {
                foreach (Category current in childs)
                {
                    TreeNode treeNode = new TreeNode(string.Concat(new object[]
                    {
                        current.Name,
                        " (",
                        this._factor.GetArticlesCount(current),
                        ")"
                    }));
                    treeNode.Name = current.Name;
                    treeNode.Tag = current;
                    if (this._factor.HasChilds(current))
                    {
                        treeNode.Nodes.Add("Chargement des catégories");
                    }
                    tree.Nodes.Add(treeNode);
                }
            }
        }

        private void ListviewFill(IList<Article> articles)
        {
            if (articles.Count > 0)
            {
                ListView.ListViewItemCollection listViewItemCollection = new ListView.ListViewItemCollection(this.lvwCategorie);
                foreach (Article current in articles)
                {
                    listViewItemCollection.Add(new ListViewItem
                    {
                        Text = current.Name,
                        Tag = current,
                        SubItems =
                        {
                            current.CreationDate,
                            current.ModificationDate
                        }
                    });
                }
            }
        }

        private void tvwCategorie_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.tvwCategorie.SelectedNode = e.Node;
            this.lvwCategorie.SelectedIndices.Clear();
            if (e.Node.GetNodeCount(false) == 1 && e.Node.Text != "Catégories")
            {
                e.Node.Nodes.Clear();
                this.ParseCategories((Category)e.Node.Tag, e.Node);
                this.nouveauToolStripButton.Enabled = false;
                this.nouveauToolStripMenuItem.Enabled = false;
            }
            if (e.Node.GetNodeCount(false) == 0)
            {
                if (this._categoryRequest != (Category)e.Node.Tag)
                {
                    this._articles = this._factor.GetArticleByCategory((Category)e.Node.Tag);
                    this.lvwCategorie.Items.Clear();
                    if (this._articles != null)
                    {
                        this.ListviewFill(this._articles);
                    }
                    this._categoryRequest = (Category)e.Node.Tag;
                }
                this.nouveauToolStripButton.Enabled = true;
                this.nouveauToolStripMenuItem.Enabled = true;
            }
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticleForm form = new ArticleForm(new Article(), (Category)this.tvwCategorie.SelectedNode.Tag);
            this.ArticleManagementForm(form);
        }

        private void ouvrirToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.lvwCategorie.SelectedItems.Count > 0)
            {
                ArticleForm form = new ArticleForm((Article)this.lvwCategorie.SelectedItems[0].Tag, (Category)this.tvwCategorie.SelectedNode.Tag);
                this.ArticleManagementForm(form);
            }
        }

        private void supprimerToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.lvwCategorie.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Etes-vous sur de vouloir supprimer les articles sélectionnés ?", "Supprimer un article", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.OK)
                {
                    for (int i = 0; i < this.lvwCategorie.SelectedItems.Count; i++)
                    {
                        Article objectToDelete = (Article)this.lvwCategorie.SelectedItems[i].Tag;
                        this._factor._articleFactor.DeleteObject(objectToDelete);
                    }
                    this._categoryRequest = null;
                    this.tvwCategorie_NodeMouseClick(sender, new TreeNodeMouseClickEventArgs(this.tvwCategorie.SelectedNode, MouseButtons.Left, 1, 0, 0));
                    this.lvwCategorie.SelectedItems.Clear();
                }
            }
        }

        private void tsMove_Click(object sender, EventArgs e)
        {
            if (this.lvwCategorie.SelectedItems.Count > 0)
            {
                MoveForm moveForm = new MoveForm();
                moveForm.cbxCategorie.DataSource = this._factor.GetCategoriesLessChild();
                moveForm.cbxCategorie.DisplayMember = "Name";
                if (moveForm.ShowDialog(this) == DialogResult.OK)
                {
                    for (int i = 0; i < this.lvwCategorie.SelectedItems.Count; i++)
                    {
                        this._factor.MoveArticle((Article)this.lvwCategorie.SelectedItems[i].Tag, moveForm.Category);
                    }
                    Category category = (Category)this.tvwCategorie.SelectedNode.Tag;
                    this.tvwCategorie.SelectedNode.Text = string.Concat(new object[]
                    {
                        category.Name,
                        " (",
                        this._factor.GetArticlesCount(category),
                        ")"
                    });
                    TreeNode[] array = this.tvwCategorie.Nodes.Find(moveForm.Category.Name, true);
                    if (array != null && array.Length > 0)
                    {
                        array[0].Text = string.Concat(new object[]
                        {
                            moveForm.Category.Name,
                            " (",
                            this._factor.GetArticlesCount(moveForm.Category),
                            ")"
                        });
                    }
                }
                this.lvwCategorie.SelectedItems.Clear();
                this.lvwCategorie.Items.Clear();
                moveForm.Dispose();
            }
        }

        private void personnaliserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm(this._factor);
            categoryForm.ShowDialog(this);
            this.TreeviewFill();
            categoryForm.Dispose();
        }

        private void ArticleManagementForm(ArticleForm form)
        {
            form.cbxCategories.DataSource = this._factor.GetCategoriesLessChild();
            form.cbxCategories.DisplayMember = "Name";
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string mode;
                if ((mode = form.Mode) != null)
                {
                    if (!(mode == "Save"))
                    {
                        if (mode == "Update")
                        {
                            form.Article.ModificationDate = DateTime.Now.ToLongDateString();
                            this._factor._articleFactor.UpdateObject(form.Article, form.Article.Id);
                        }
                    }
                    else
                    {
                        form.Article.CreationDate = DateTime.Now.ToLongDateString();
                        this._factor._articleFactor.AddObject(form.Article);
                    }
                }
                this._categoryRequest = null;
                this.tvwCategorie_NodeMouseClick(form, new TreeNodeMouseClickEventArgs(this.tvwCategorie.SelectedNode, MouseButtons.Left, 1, 0, 0));
                Category category = (Category)this.tvwCategorie.SelectedNode.Tag;
                this.tvwCategorie.SelectedNode.Text = string.Concat(new object[]
                {
                    category.Name,
                    " (",
                    this._factor.GetArticlesCount(category),
                    ")"
                });
            }
            this.lvwCategorie.SelectedItems.Clear();
            form.Dispose();
        }

        private void lvwCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvwCategorie.SelectedIndices.Count > 0)
            {
                this.ouvrirToolStripButton.Enabled = true;
                this.ouvrirToolStripMenuItem.Enabled = true;
                this.supprimerToolStripButton.Enabled = true;
                this.supprimerToolStripMenuItem.Enabled = true;
                this.tsMove.Enabled = true;
                return;
            }
            this.ouvrirToolStripButton.Enabled = false;
            this.ouvrirToolStripMenuItem.Enabled = false;
            this.supprimerToolStripButton.Enabled = false;
            this.supprimerToolStripMenuItem.Enabled = false;
            this.tsMove.Enabled = false;
        }

        private void lvwCategorie_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ouvrirToolStripButton_Click(sender, e);
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._factor.Dispose();
            Application.Exit();
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
            this.tsSystem = new ToolStrip();
            this.nouveauToolStripButton = new ToolStripButton();
            this.ouvrirToolStripButton = new ToolStripButton();
            this.supprimerToolStripButton = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.tsMove = new ToolStripButton();
            this.imprimerToolStripButton = new ToolStripButton();
            this.toolStripSeparator = new ToolStripSeparator();
            this.mainMenu = new MenuStrip();
            this.fichierToolStripMenuItem = new ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.imprimerToolStripMenuItem = new ToolStripMenuItem();
            this.aperçuavantimpressionToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.quitterToolStripMenuItem = new ToolStripMenuItem();
            this.outilsToolStripMenuItem = new ToolStripMenuItem();
            this.personnaliserToolStripMenuItem = new ToolStripMenuItem();
            this.optionsToolStripMenuItem = new ToolStripMenuItem();
            this.tvwCategorie = new TreeView();
            this.lblCategorie = new Label();
            this.lvwCategorie = new ListView();
            this.chName = new ColumnHeader();
            this.chCreation = new ColumnHeader();
            this.chModification = new ColumnHeader();
            this.tsSystem.SuspendLayout();
            this.mainMenu.SuspendLayout();
            base.SuspendLayout();
            this.tsSystem.Items.AddRange(new ToolStripItem[]
            {
                this.nouveauToolStripButton,
                this.ouvrirToolStripButton,
                this.supprimerToolStripButton,
                this.toolStripSeparator1,
                this.tsMove,
                this.imprimerToolStripButton,
                this.toolStripSeparator
            });
            this.tsSystem.Location = new Point(0, 24);
            this.tsSystem.Name = "tsSystem";
            this.tsSystem.Size = new Size(1016, 25);
            this.tsSystem.TabIndex = 0;
            this.tsSystem.Text = "toolStrip1";
            this.nouveauToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.nouveauToolStripButton.Image = Resources.img_new;
            this.nouveauToolStripButton.ImageTransparentColor = Color.Magenta;
            this.nouveauToolStripButton.Name = "nouveauToolStripButton";
            this.nouveauToolStripButton.Size = new Size(23, 22);
            this.nouveauToolStripButton.Text = "&Nouveau";
            this.nouveauToolStripButton.Click += new EventHandler(this.nouveauToolStripMenuItem_Click);
            this.ouvrirToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.ouvrirToolStripButton.Image = Resources.img_modify;
            this.ouvrirToolStripButton.ImageTransparentColor = Color.Magenta;
            this.ouvrirToolStripButton.Name = "ouvrirToolStripButton";
            this.ouvrirToolStripButton.Size = new Size(23, 22);
            this.ouvrirToolStripButton.Text = "&Modifier";
            this.ouvrirToolStripButton.Click += new EventHandler(this.ouvrirToolStripButton_Click);
            this.supprimerToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.supprimerToolStripButton.Image = Resources.img_delete;
            this.supprimerToolStripButton.ImageTransparentColor = Color.Magenta;
            this.supprimerToolStripButton.Name = "supprimerToolStripButton";
            this.supprimerToolStripButton.Size = new Size(23, 22);
            this.supprimerToolStripButton.Text = "&Supprimer";
            this.supprimerToolStripButton.Click += new EventHandler(this.supprimerToolStripButton_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 25);
            this.tsMove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsMove.Image = Resources.img_move;
            this.tsMove.ImageTransparentColor = Color.Magenta;
            this.tsMove.Name = "tsMove";
            this.tsMove.Size = new Size(23, 22);
            this.tsMove.Text = "Déplacer";
            this.tsMove.Click += new EventHandler(this.tsMove_Click);
            this.imprimerToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.imprimerToolStripButton.Image = Resources.img_print;
            this.imprimerToolStripButton.ImageTransparentColor = Color.Magenta;
            this.imprimerToolStripButton.Name = "imprimerToolStripButton";
            this.imprimerToolStripButton.Size = new Size(23, 22);
            this.imprimerToolStripButton.Text = "&Imprimer";
            this.imprimerToolStripButton.Visible = false;
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new Size(6, 25);
            this.mainMenu.Items.AddRange(new ToolStripItem[]
            {
                this.fichierToolStripMenuItem,
                this.outilsToolStripMenuItem
            });
            this.mainMenu.Location = new Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new Size(1016, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menu";
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.nouveauToolStripMenuItem,
                this.ouvrirToolStripMenuItem,
                this.supprimerToolStripMenuItem,
                this.toolStripSeparator3,
                this.imprimerToolStripMenuItem,
                this.aperçuavantimpressionToolStripMenuItem,
                this.toolStripSeparator4,
                this.quitterToolStripMenuItem
            });
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new Size(50, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            this.nouveauToolStripMenuItem.Image = Resources.img_new;
            this.nouveauToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.ShortcutKeys = (Keys)131150;
            this.nouveauToolStripMenuItem.Size = new Size(192, 22);
            this.nouveauToolStripMenuItem.Text = "&Nouveau";
            this.nouveauToolStripMenuItem.Click += new EventHandler(this.nouveauToolStripMenuItem_Click);
            this.ouvrirToolStripMenuItem.Image = Resources.img_modify;
            this.ouvrirToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.ShortcutKeys = (Keys)131151;
            this.ouvrirToolStripMenuItem.Size = new Size(192, 22);
            this.ouvrirToolStripMenuItem.Text = "&Modifier";
            this.supprimerToolStripMenuItem.Image = Resources.img_delete;
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new Size(192, 22);
            this.supprimerToolStripMenuItem.Text = "&Supprimer";
            this.supprimerToolStripMenuItem.Click += new EventHandler(this.supprimerToolStripButton_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(189, 6);
            this.imprimerToolStripMenuItem.Image = Resources.img_print;
            this.imprimerToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            this.imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
            this.imprimerToolStripMenuItem.ShortcutKeys = (Keys)131152;
            this.imprimerToolStripMenuItem.Size = new Size(192, 22);
            this.imprimerToolStripMenuItem.Text = "&Imprimer";
            this.imprimerToolStripMenuItem.Visible = false;
            this.aperçuavantimpressionToolStripMenuItem.Image = Resources.img_preview;
            this.aperçuavantimpressionToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            this.aperçuavantimpressionToolStripMenuItem.Name = "aperçuavantimpressionToolStripMenuItem";
            this.aperçuavantimpressionToolStripMenuItem.Size = new Size(192, 22);
            this.aperçuavantimpressionToolStripMenuItem.Text = "Aperçu a&vant impression";
            this.aperçuavantimpressionToolStripMenuItem.Visible = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(189, 6);
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new Size(192, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new EventHandler(this.quitterToolStripMenuItem_Click);
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.personnaliserToolStripMenuItem,
                this.optionsToolStripMenuItem
            });
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Size = new Size(46, 20);
            this.outilsToolStripMenuItem.Text = "&Outils";
            this.personnaliserToolStripMenuItem.Name = "personnaliserToolStripMenuItem";
            this.personnaliserToolStripMenuItem.Size = new Size(183, 22);
            this.personnaliserToolStripMenuItem.Text = "&Gestion des catégories";
            this.personnaliserToolStripMenuItem.Click += new EventHandler(this.personnaliserToolStripMenuItem_Click);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new Size(183, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Visible = false;
            this.tvwCategorie.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            this.tvwCategorie.Location = new Point(12, 78);
            this.tvwCategorie.Name = "tvwCategorie";
            this.tvwCategorie.Size = new Size(343, 683);
            this.tvwCategorie.TabIndex = 2;
            this.tvwCategorie.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tvwCategorie_NodeMouseClick);
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            this.lblCategorie.Location = new Point(12, 59);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new Size(149, 16);
            this.lblCategorie.TabIndex = 3;
            this.lblCategorie.Text = "Liste des catégories";
            this.lvwCategorie.AllowColumnReorder = true;
            this.lvwCategorie.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.lvwCategorie.Columns.AddRange(new ColumnHeader[]
            {
                this.chName,
                this.chCreation,
                this.chModification
            });
            this.lvwCategorie.FullRowSelect = true;
            this.lvwCategorie.Location = new Point(361, 78);
            this.lvwCategorie.Name = "lvwCategorie";
            this.lvwCategorie.Size = new Size(643, 683);
            this.lvwCategorie.TabIndex = 4;
            this.lvwCategorie.UseCompatibleStateImageBehavior = false;
            this.lvwCategorie.View = View.Details;
            this.lvwCategorie.MouseDoubleClick += new MouseEventHandler(this.lvwCategorie_MouseDoubleClick);
            this.lvwCategorie.SelectedIndexChanged += new EventHandler(this.lvwCategorie_SelectedIndexChanged);
            this.chName.Text = "Nom";
            this.chName.Width = 323;
            this.chCreation.Text = "Date de création";
            this.chCreation.Width = 156;
            this.chModification.Text = "Date de modification";
            this.chModification.Width = 160;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(1016, 766);
            base.Controls.Add(this.lvwCategorie);
            base.Controls.Add(this.lblCategorie);
            base.Controls.Add(this.tvwCategorie);
            base.Controls.Add(this.tsSystem);
            base.Controls.Add(this.mainMenu);
            base.MainMenuStrip = this.mainMenu;
            base.Name = "MainForm";
            this.Text = "Bibliographie";
            base.Load += new EventHandler(this.MainForm_Load);
            this.tsSystem.ResumeLayout(false);
            this.tsSystem.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
