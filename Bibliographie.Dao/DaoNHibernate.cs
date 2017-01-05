using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bibliographie.Dao
{
    public class DaoNHibernate : IDao
    {
        private ISession _session;

        private ISessionFactory _factory;

        private Configuration _configuration;

        public ISession Session
        {
            get
            {
                return this._session;
            }
            set
            {
                this._session = value;
            }
        }

        public ISessionFactory Factory
        {
            get
            {
                return this._factory;
            }
            set
            {
                this._factory = value;
            }
        }

        public Configuration Configuration
        {
            get
            {
                return this._configuration;
            }
            set
            {
                this._configuration = value;
            }
        }

        public DaoNHibernate()
        {
            this._configuration = new Configuration();
            this._configuration.Configure(Assembly.GetAssembly(typeof(DaoNHibernate)), "Bibliographie.Configuration.hibernate.cfg.xml");
            this._configuration.AddResource("Bibliographie.Mapping.Bibliographie.hbm.xml", Assembly.GetAssembly(typeof(DaoNHibernate)));
            this._factory = this._configuration.BuildSessionFactory();
        }

        public IList<Article> GetAllArticles()
        {
            return null;
        }

        public Article GetArticleById(int id)
        {
            return null;
        }

        public IList<Article> GetArticlesByCategory(Category category)
        {
            return null;
        }

        public IList<Article> GetArticlesByCategories(Category[] categories)
        {
            return null;
        }

        public int AddArticle(Article article)
        {
            return 0;
        }

        public int ModifyArticle(Article article)
        {
            return 0;
        }

        public int DeleteArticle(Article article)
        {
            return 0;
        }

        public IList<Category> GetAllCategories()
        {
            return null;
        }

        public Category GetCategoryById(int id)
        {
            return null;
        }

        public IList<Category> GetCategories()
        {
            return null;
        }

        public IList<Category> GetCategories(Category parent)
        {
            return null;
        }

        public int AddCategory(Category category)
        {
            return 0;
        }

        public int ModifyCategory(Category category)
        {
            return 0;
        }

        public int DeleteCategory(Category category)
        {
            return 0;
        }
    }
}
