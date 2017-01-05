using Bibliographie.Core;
using Bibliographie.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bibliographie
{
    public class CategoryForm : Form
    {
        private IContainer components;

        private ToolStrip toolStrip;

        private ToolStripButton newToolStripButton;

        private ToolStripButton modifyToolStripButton;

        private ToolStripButton deleteToolStripButton;

        private TreeView treeViewCat;

        private Button buttonClose;

        private ContextMenuStrip contextMenuStrip;

        private ToolStripMenuItem ajouterToolStripMenuItem;

        private ToolStripMenuItem modifierToolStripMenuItem;

        private ToolStripMenuItem supprimerToolStripMenuItem;

        private Label lblArticle;

        private Label lblCount;

        private CategoryManagement _factor;

        private IList<Category> _categories;

        private Font _parentFont;

        private Color _parentColor;

        public CategoryManagement Factor
        {
            get
            {
                return this._factor;
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.modifyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.treeViewCat = new System.Windows.Forms.TreeView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblArticle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.modifyToolStripButton,
            this.deleteToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(292, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // modifyToolStripButton
            // 
            this.modifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.modifyToolStripButton.Enabled = false;
            this.modifyToolStripButton.Image = global::Bibliographie.Properties.Resources.img_modify;
            this.modifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modifyToolStripButton.Name = "modifyToolStripButton";
            this.modifyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.modifyToolStripButton.Text = "toolStripButton1";
            this.modifyToolStripButton.ToolTipText = "Modifier la catégorie";
            this.modifyToolStripButton.Click += new System.EventHandler(this.modifyToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Enabled = false;
            this.deleteToolStripButton.Image = global::Bibliographie.Properties.Resources.img_delete;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "toolStripButton1";
            this.deleteToolStripButton.ToolTipText = "Supprimer la catégorie";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // treeViewCat
            // 
            this.treeViewCat.AllowDrop = true;
            this.treeViewCat.ForeColor = System.Drawing.Color.Black;
            this.treeViewCat.Location = new System.Drawing.Point(12, 28);
            this.treeViewCat.Name = "treeViewCat";
            this.treeViewCat.Size = new System.Drawing.Size(268, 247);
            this.treeViewCat.TabIndex = 1;
            this.treeViewCat.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCat_NodeMouseClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(205, 281);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Fermer";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(130, 70);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripButton_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Location = new System.Drawing.Point(13, 283);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(96, 13);
            this.lblArticle.TabIndex = 3;
            this.lblArticle.Text = "Nombres d\'articles:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(106, 283);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 4;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = global::Bibliographie.Properties.Resources.img_new;
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.ToolTipText = "Ajouter une catégorie";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 308);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblArticle);
            this.Controls.Add(this.treeViewCat);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des catégories";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public CategoryForm()
        {
            this.InitializeComponent();
        }

        public CategoryForm(CategoryManagement factor) : this()
        {
            this._factor = factor;
            this._parentFont = new Font("Arial", 8f);
            this._parentColor = Color.Green;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            this.TreeviewFill();
        }

        public void TreeviewFill()
        {
            this.treeViewCat.Nodes.Clear();
            this.treeViewCat.Sort();
            Category category = new Category(0, "Catégories", 0);
            TreeNode treeNode = new TreeNode(category.Name);
            this._categories = this._factor.GetParentsRoot();
            if (this._categories != null)
            {
                foreach (Category current in this._categories)
                {
                    int articlesCount = this._factor.GetArticlesCount(current);
                    TreeNode treeNode2 = new TreeNode(current.Name);
                    if (articlesCount == 0)
                    {
                        treeNode2.ForeColor = this._parentColor;
                        treeNode2.NodeFont = this._parentFont;
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
            this.treeViewCat.Nodes.Add(treeNode);
            this.treeViewCat.SelectedNode = this.treeViewCat.Nodes[0];
            this.treeViewCat.Nodes[0].Expand();
        }

        private void ParseCategories(Category category, TreeNode tree)
        {
            IList<Category> childs = this._factor.GetChilds(category);
            if (childs != null)
            {
                foreach (Category current in childs)
                {
                    int articlesCount = this._factor.GetArticlesCount(current);
                    TreeNode treeNode = new TreeNode(current.Name);
                    if (articlesCount == 0)
                    {
                        treeNode.ForeColor = this._parentColor;
                        treeNode.NodeFont = this._parentFont;
                    }
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

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewCat newCat = new NewCat(this._factor.GetCategoryByName(this.treeViewCat.SelectedNode.Text));
            if (newCat.ShowDialog(this) == DialogResult.OK)
            {
                if (this._factor.GetCategoryByName(newCat.NewCategory.Name) == null)
                {
                    this._factor._categoryFactor.AddObject(newCat.NewCategory);
                    TreeNode treeNode = new TreeNode(newCat.NewCategory.Name);
                    treeNode.Text = newCat.NewCategory.Name;
                    treeNode.NodeFont = this._parentFont;
                    treeNode.ForeColor = this._parentColor;
                    this.treeViewCat.SelectedNode.Nodes.Add(treeNode);
                    this.treeViewCat.Sort();
                    this.treeViewCat.SelectedNode = treeNode;
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de la categorie " + newCat.NewCategory.Name + Environment.NewLine + "Ce nom existe dejà.", "Erreur d'intégrité", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            newCat.Dispose();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this._factor.Dispose();
            base.Close();
        }

        private void treeViewCat_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.treeViewCat.SelectedNode = e.Node;
            this.lblCount.Text = this._factor.GetArticlesCount((Category)e.Node.Tag).ToString();
            if (e.Node.GetNodeCount(false) == 1 && e.Node.Text != "Catégories")
            {
                e.Node.Nodes.Clear();
                this.ParseCategories((Category)e.Node.Tag, e.Node);
                this.newToolStripButton.Enabled = false;
                this.ajouterToolStripMenuItem.Enabled = false;
            }
            this.newToolStripButton.Enabled = true;
            this.ajouterToolStripMenuItem.Enabled = true;
            if (e.Node.Text != "Catégories")
            {
                this.modifyToolStripButton.Enabled = true;
                this.modifierToolStripMenuItem.Enabled = true;
                this.supprimerToolStripMenuItem.Enabled = true;
                this.deleteToolStripButton.Enabled = true;
            }
        }

        private void modifyToolStripButton_Click(object sender, EventArgs e)
        {
            Category categoryByName = this._factor.GetCategoryByName(this.treeViewCat.SelectedNode.Text);
            TreeNode selectedNode = this.treeViewCat.SelectedNode;
            ModCat modCat = new ModCat(ref categoryByName);
            if (modCat.ShowDialog(this) == DialogResult.OK)
            {
                this.treeViewCat.Nodes.Remove(selectedNode);
                if (modCat.ModifiedCategory != categoryByName.Name)
                {
                    if (this._factor.GetCategoryByName(categoryByName.Name) == null)
                    {
                        this._factor._categoryFactor.UpdateObject(categoryByName, categoryByName.Id);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de la categorie " + categoryByName.Name + Environment.NewLine + "Ce nom existe dejà.", "Erreur d'intégrité", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    this._factor._categoryFactor.UpdateObject(categoryByName, categoryByName.Id);
                }
                TreeNode[] array = this.treeViewCat.Nodes.Find(this._factor.GetParent(categoryByName).Name, true);
                if (array != null && array.Length > 0)
                {
                    array[0].Nodes.Add(categoryByName.Name, categoryByName.Name);
                    array[0].Expand();
                }
            }
            modCat.Dispose();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            Category categoryByName = this._factor.GetCategoryByName(this.treeViewCat.SelectedNode.Text);
            DialogResult dialogResult = MessageBox.Show(this, "Etes-vous sur de vouloir supprimer cette catégorie?" + Environment.NewLine + "Les articles associés à cette catégorie seront également supprimés", "Supprimer une catégorie", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.OK)
            {
                this.ParseCategoryToDelete(categoryByName, this.treeViewCat.SelectedNode);
                this.treeViewCat.Nodes.Remove(this.treeViewCat.SelectedNode);
            }
        }

        private void ParseCategoryToDelete(Category category, TreeNode tree)
        {
            IList<Category> childs = this._factor.GetChilds(category);
            if (childs != null)
            {
                foreach (Category current in childs)
                {
                    this.ParseCategoryToDelete(current, tree);
                }
            }
            this._factor.DeleteArticles(category);
            this._factor._categoryFactor.DeleteObject(category);
        }
    }
}
