using System;
using System.Collections.Generic;

namespace Bibliographie.Dao
{
    public interface IDao
    {
        IList<Article> GetAllArticles();

        Article GetArticleById(int id);

        IList<Article> GetArticlesByCategory(Category category);

        IList<Article> GetArticlesByCategories(Category[] categories);

        int AddArticle(Article article);

        int ModifyArticle(Article article);

        int DeleteArticle(Article article);

        IList<Category> GetAllCategories();

        Category GetCategoryById(int id);

        IList<Category> GetCategories();

        IList<Category> GetCategories(Category parent);

        int AddCategory(Category category);

        int ModifyCategory(Category category);

        int DeleteCategory(Category category);
    }
}
