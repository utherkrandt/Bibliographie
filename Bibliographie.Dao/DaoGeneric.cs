using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Bibliographie.Dao
{
    public class DaoGeneric<T, V> : IDaoGeneric<T, V>, IDisposable
    {
        private ISession _session;

        private ISessionFactory _factory;

        private NHibernate.Cfg.Configuration _configuration;

        private ITransaction _transaction;

        public ITransaction Transaction
        {
            get
            {
                return this._transaction;
            }
            set
            {
                this._transaction = value;
            }
        }

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

        public NHibernate.Cfg.Configuration Configuration
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

        public DaoGeneric()
        {
            try
            {
                this._configuration = new NHibernate.Cfg.Configuration();
                IDictionary dictionary = new Hashtable();
                dictionary["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
                dictionary["dialect"] = "NHibernate.JetDriver.JetDialect, NHibernate.JetDriver";
                dictionary["connection.driver_class"] = "NHibernate.JetDriver.JetDriver, NHibernate.JetDriver";
                dictionary["connection.connection_string"] = ConfigurationManager.ConnectionStrings["Bibliographie"].ConnectionString;
                dictionary["show_sql"] = "true";
                foreach (DictionaryEntry dictionaryEntry in dictionary)
                {
                    this._configuration.SetProperty(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString());
                }
                this._configuration.AddResource("Bibliographie.Dao.Bibliographie.Mapping.Bibliographie.hbm.xml", Assembly.GetAssembly(typeof(DaoNHibernate)));
                this._factory = this._configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erreur lors de la construction de la Factory:" + ex.Message);
                Console.WriteLine("Erreur lors de la construction de la Factory:" + ex.Message);
            }
        }

        private IList<T> ArrayListToIlist(IList list)
        {
            IList<T> result;
            if (list != null)
            {
                IList<T> list2 = new List<T>();
                for (int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        if (list[i] is T)
                        {
                            list2.Add((T)((object)list[i]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Erreur lors de la conversion de la Ilist:" + ex.Message);
                        Console.WriteLine("Erreur lors de la conversion de la Ilist:" + ex.Message);
                        result = null;
                        return result;
                    }
                }
                result = list2;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public void Dispose()
        {
            if (this._session != null)
            {
                this._session.Close();
                this._session.Dispose();
            }
        }

        public T GetObjectById(V id)
        {
            T result;
            try
            {
                string queryString = string.Concat(new object[]
                {
                    "from ",
                    typeof(T),
                    " as o where o.id=",
                    id
                });
                this._session = this._factory.OpenSession();
                IList list = this._session.CreateQuery(queryString).List();
                if (list.Count > 0)
                {
                    result = (T)((object)list[0]);
                }
                else
                {
                    result = default(T);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                result = default(T);
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public IList<T> GetObjects()
        {
            IList<T> result;
            try
            {
                string queryString = "from " + typeof(T) + " as o";
                this._session = this._factory.OpenSession();
                IList list = this._session.CreateQuery(queryString).List();
                if (list.Count > 0)
                {
                    result = this.ArrayListToIlist(list);
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                result = null;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public bool AddObject(T objectToAdd)
        {
            bool result;
            try
            {
                this._session = this._factory.OpenSession();
                this._session.Save(objectToAdd);
                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la sauvegarde de l'objet:",
                    objectToAdd,
                    System.Environment.NewLine,
                    "Erreur:",
                    ex.Message
                }));
                Console.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la sauvegarde de l'objet:",
                    objectToAdd,
                    System.Environment.NewLine,
                    "Erreur:",
                    ex.Message
                }));
                result = false;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public bool UpdateObject(T objectToUpdate, V id)
        {
            bool result;
            try
            {
                Console.WriteLine(objectToUpdate);
                this._session = this._factory.OpenSession();
                this._transaction = this._session.BeginTransaction();
                this._session.Update(objectToUpdate);
                this._session.Flush();
                this._transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                if (this._transaction != null)
                {
                    this._transaction.Rollback();
                }
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la mise à jour de l'objet:",
                    objectToUpdate,
                    System.Environment.NewLine,
                    "Erreur:",
                    ex.Message
                }));
                result = false;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public bool DeleteObject(T objectToDelete)
        {
            bool result;
            try
            {
                this._session = this._factory.OpenSession();
                this._transaction = this._session.BeginTransaction();
                this._session.Delete(objectToDelete);
                this._transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                if (this._transaction != null)
                {
                    this._transaction.Rollback();
                }
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la suppression de l'objet:",
                    objectToDelete,
                    System.Environment.NewLine,
                    "Erreur:",
                    ex.Message
                }));
                Console.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la suppression de l'objet:",
                    objectToDelete,
                    System.Environment.NewLine,
                    "Erreur:",
                    ex.Message
                }));
                result = false;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public bool DeleteAllObjects()
        {
            bool result;
            try
            {
                Console.WriteLine("Suppression de tous les objets");
                this._session = this._factory.OpenSession();
                this._transaction = this._session.BeginTransaction();
                this._session.Delete("FROM " + typeof(T));
                this._transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                if (this._transaction != null)
                {
                    this._transaction.Rollback();
                }
                Debug.WriteLine("Erreur lors de la suppression de tous les objets: Erreur:" + ex.Message);
                Console.WriteLine("Erreur lors de la suppression de tous les objets:Erreur:" + ex.Message);
                result = false;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public int ExecuteDeleteQuery(string query)
        {
            int result;
            try
            {
                this._session = this._factory.OpenSession();
                this._transaction = this._session.BeginTransaction();
                int num = this._session.Delete(query);
                this._session.Flush();
                this._transaction.Commit();
                result = num;
            }
            catch (Exception ex)
            {
                if (this._transaction != null)
                {
                    this._transaction.Rollback();
                }
                Debug.WriteLine("Erreur lors de la suppression de l'objet:" + System.Environment.NewLine + "Erreur:" + ex.Message);
                result = -1;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public IList<T> ExecuteQuery(string query)
        {
            IList<T> result;
            try
            {
                this._session = this._factory.OpenSession();
                IList list = this._session.CreateQuery(query).List();
                if (list.Count > 0)
                {
                    result = this.ArrayListToIlist(list);
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erreur lors de l'exécution de la requête:" + query + System.Environment.NewLine + ex.Message);
                result = null;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public IList ExecuteSelectQuery(string query)
        {
            IList result;
            try
            {
                this._session = this._factory.OpenSession();
                IList list = this._session.CreateQuery(query).List();
                if (list.Count > 0)
                {
                    result = list;
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erreur lors de l'exécution de la requête:" + query + System.Environment.NewLine + ex.Message);
                result = null;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public int ExecuteScalarQuery(string query)
        {
            int result;
            try
            {
                this._session = this._factory.OpenSession();
                IEnumerator enumerator = this._session.CreateQuery(query).Enumerable().GetEnumerator();
                enumerator.MoveNext();
                result = int.Parse(enumerator.Current.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                result = -1;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }

        public int GetObjectCount(T objectToCount)
        {
            int result;
            try
            {
                string query = "select count(*) from " + typeof(T) + " as o";
                this._session = this._factory.OpenSession();
                IEnumerator enumerator = this._session.CreateQuery(query).Enumerable().GetEnumerator();
                enumerator.MoveNext();
                result = int.Parse(enumerator.Current.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                Debug.WriteLine(string.Concat(new object[]
                {
                    "Erreur lors de la récupération des objets:",
                    typeof(T),
                    System.Environment.NewLine,
                    ex.Message
                }));
                result = -1;
            }
            finally
            {
                this._session.Close();
            }
            return result;
        }
    }
}
