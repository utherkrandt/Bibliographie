using Bibliographie.Dao;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bibliographie.Core
{
    public class CategoryManagement : ICore, IDisposable
    {
        public DaoGeneric<Category, int> _categoryFactor = new DaoGeneric<Category, int>();

        public DaoGeneric<Article, int> _articleFactor = new DaoGeneric<Article, int>();

        public IList<Category> GetChilds(Category parent)
        {
            IList<Category> result;
            if (parent != null)
            {
                result = this._categoryFactor.ExecuteQuery("FROM Category as c WHERE c.ParentId=" + parent.Id);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public IList<Category> GetParentsRoot()
        {
            return this._categoryFactor.ExecuteQuery("FROM Category as c WHERE c.ParentId=0");
        }

        public IList<Category> GetPossiblyParent(Category category)
        {
            IList list = this._categoryFactor.ExecuteSelectQuery(string.Concat(new object[]
            {
                "SELECT c.Id, c.Name, c.ParentId FROM Category as c WHERE c.ParentId<>",
                category.Id,
                " AND c.Id<>",
                category.Id,
                " AND c.id not in (SELECT Distinct a.Category FROM Article as a )"
            }));
            IList<Category> result;
            if (list != null)
            {
                result = this.Convert(list);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public IList<Category> GetCategoriesLessChild()
        {
            string query = "SELECT c.Id, c.Name, c.ParentId FROM Category as c WHERE (SELECT count(*) FROM Category as cat WHERE cat.ParentId=c.Id)=0";
            IList list = this._categoryFactor.ExecuteSelectQuery(query);
            IList<Category> result;
            if (list != null)
            {
                result = this.Convert(list);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public Category GetParent(Category child)
        {
            IList<Category> list = this._categoryFactor.ExecuteQuery("FROM Category as C WHERE C.Id=" + child.ParentId);
            Category result;
            if (list != null)
            {
                result = list[0];
            }
            else
            {
                result = null;
            }
            return result;
        }

        public Category GetCategoryByName(string name)
        {
            IList list = this._categoryFactor.ExecuteSelectQuery("SELECT c.Id, c.Name, c.ParentId FROM Category as c WHERE c.Name='" + name + "'");
            Category result;
            if (list != null)
            {
                result = this.Convert(list)[0];
            }
            else
            {
                result = null;
            }
            return result;
        }

        public IList<Article> GetResult(string query)
        {
            Console.WriteLine(query);
            return this._articleFactor.ExecuteQuery(query);
        }

        public IList<Article> GetArticleByCategory(Category category)
        {
            IList<Article> result;
            if (category != null)
            {
                string text = "From Article as a Where a.Category=" + category.Id;
                Console.WriteLine(text);
                result = this._articleFactor.ExecuteQuery(text);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public int GetArticlesCount(Category category)
        {
            int result = -1;
            if (category != null)
            {
                result = this._articleFactor.ExecuteScalarQuery("SELECT count(*) FROM Article as a WHERE a.Category.Id=" + category.Id);
            }
            return result;
        }

        public bool HasChilds(Category category)
        {
            bool result;
            if (category != null)
            {
                int num = this._categoryFactor.ExecuteScalarQuery("SELECT count(*) FROM Category as c WHERE c.ParentId=" + category.Id);
                result = (num > 0);
            }
            else
            {
                result = false;
            }
            return result;
        }

        public void MoveArticle(Article articleToMove, Category newCategory)
        {
            articleToMove.Category = newCategory;
            this._articleFactor.UpdateObject(articleToMove, articleToMove.Id);
        }

        public void DeleteArticles(Category category)
        {
            if (category != null)
            {
                this._articleFactor.ExecuteDeleteQuery("FROM Article as a WHERE a.Category=" + category.Id);
            }
        }

        public IList<Category> Convert(IList recordset)
        {
            IList<Category> result;
            if (recordset != null)
            {
                IList<Category> list = new List<Category>();
                foreach (object[] array in recordset)
                {
                    Category category = new Category();
                    switch (array.Length)
                    {
                        case 1:
                            category.Id = int.Parse(array[0].ToString());
                            list.Add(category);
                            break;
                        case 2:
                            category.Id = int.Parse(array[0].ToString());
                            category.Name = array[1].ToString();
                            list.Add(category);
                            break;
                        case 3:
                            category.Id = int.Parse(array[0].ToString());
                            category.Name = array[1].ToString();
                            category.ParentId = int.Parse(array[2].ToString());
                            list.Add(category);
                            break;
                        default:
                            throw new ArgumentException("Erreur lors de la conversion maximum 3 champs pour categorie");
                    }
                }
                result = list;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public void Dispose()
        {
            this._categoryFactor.Dispose();
            this._articleFactor.Dispose();
        }
    }
}
