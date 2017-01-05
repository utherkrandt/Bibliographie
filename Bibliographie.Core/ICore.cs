using Bibliographie.Dao;
using System;
using System.Collections.Generic;

namespace Bibliographie.Core
{
    public interface ICore
    {
        IList<Category> GetChilds(Category parent);

        IList<Category> GetParentsRoot();

        IList<Category> GetPossiblyParent(Category category);

        IList<Category> GetCategoriesLessChild();

        Category GetParent(Category child);

        Category GetCategoryByName(string name);

        IList<Article> GetResult(string query);

        IList<Article> GetArticleByCategory(Category category);

        int GetArticlesCount(Category category);

        bool HasChilds(Category category);

        void MoveArticle(Article articleToMove, Category newCategory);

        void DeleteArticles(Category category);
    }
}
