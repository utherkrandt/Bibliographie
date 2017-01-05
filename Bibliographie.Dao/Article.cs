using System;

namespace Bibliographie.Dao
{
    public class Article
    {
        private int _id;

        private string _name;

        private string _content;

        private Category _category;

        private string _creationDate;

        private string _modificationDate;

        public virtual Category Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }

        public virtual string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        public virtual string ModificationDate
        {
            get
            {
                return this._modificationDate;
            }
            set
            {
                this._modificationDate = value;
            }
        }

        public virtual string CreationDate
        {
            get
            {
                return this._creationDate;
            }
            set
            {
                this._creationDate = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._name = value;
                    return;
                }
                throw new ArgumentException("Name ne doit pas être une chaine vide", "Name:" + value);
            }
        }

        public virtual int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (value >= 0)
                {
                    this._id = value;
                    return;
                }
                throw new ArgumentException("ID doit être supérieur à 0", "Id:" + value);
            }
        }

        public Article()
        {
            this._id = 0;
            this._name = string.Empty;
            this._content = string.Empty;
            this._category = new Category();
            this._creationDate = DateTime.Now.ToLongDateString();
            this._modificationDate = string.Empty;
        }

        public Article(int id, string name) : this()
        {
            this._id = id;
            this._name = name;
        }

        public Article(int id, string name, string content) : this(id, name)
        {
            this._content = content;
        }

        public Article(int id, string name, string content, Category category) : this(id, name, content)
        {
            this._category = category;
        }

        public override string ToString()
        {
            return string.Format("{0}-Article:{1}, créé le {2}.Categorie:{3} Contenu:{4}{5}", new object[]
            {
                this.Id,
                this.Name,
                this.CreationDate,
                this.Category.Name,
                Environment.NewLine,
                this.Content
            });
        }
    }
}
