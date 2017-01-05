using System;
using System.Collections;
using System.Collections.Generic;

namespace Bibliographie.Dao
{
    public interface IDaoGeneric<T, V>
    {
        T GetObjectById(V id);

        IList<T> GetObjects();

        bool AddObject(T objectToAdd);

        bool UpdateObject(T objectToUpdate, V id);

        bool DeleteObject(T objectToDelete);

        bool DeleteAllObjects();

        IList<T> ExecuteQuery(string query);

        IList ExecuteSelectQuery(string query);

        int ExecuteScalarQuery(string query);

        int ExecuteDeleteQuery(string query);

        int GetObjectCount(T objectToCount);
    }
}
