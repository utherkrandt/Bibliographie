using System;
using System.Collections;
using System.Text;

namespace Bibliographie.Dao
{
    public class Category
    {
        private int _id;

        private string _name;

        private int _parentId;

        private IList _articles;

        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
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
                this._id = value;
            }
        }

        public virtual int ParentId
        {
            get
            {
                return this._parentId;
            }
            set
            {
                this._parentId = value;
            }
        }

        public virtual IList Articles
        {
            get
            {
                return this._articles;
            }
            set
            {
                this._articles = value;
            }
        }

        public Category()
        {
            this._id = 0;
            this._name = string.Empty;
            this._parentId = 1;
            this._articles = new ArrayList();
        }

        public Category(int id, string name, int parentId)
        {
            this._id = id;
            this._name = name;
            this._parentId = parentId;
        }

        public Category(int id, Category parent)
        {
            this._id = id;
            this._parentId = parent.ParentId;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Id:{0} - Name:{1} - Parent:{2} ", this._id, this._name, this._parentId);
            if (this._articles != null)
            {
                stringBuilder.AppendFormat("{0}Articles:{0}", Environment.NewLine);
                for (int i = 0; i < this._articles.Count; i++)
                {
                    stringBuilder.AppendFormat("Id:{0} - Name:{1}", ((Article)this._articles[i]).Id, ((Article)this._articles[i]).Name);
                    stringBuilder.Append(Environment.NewLine);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
