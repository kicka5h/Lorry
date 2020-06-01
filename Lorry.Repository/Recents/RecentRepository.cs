using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/*
IEnumerable<T> GetAll();

T Get(int key);

void Update(T updateObject);

void Insert(T insertObject);
*/

namespace Lorry.Repository.Recents
{
    public class RecentRepository : IDatabaseRepository<Lorry.Repository.Recents.Recent>
    {
        public List<Recent> GetAll()
        {
            return DatabaseManager.Instance.Recent.Select(t => t.ToRepositoryModel()).ToList();
        }

        public Recent Get(int key)
        {
            throw new NotImplementedException();
        }

        public Recent Delete(Recent deleteObject)
        {
            var databaseObject = deleteObject.ToDBModel();

            DatabaseManager.Instance.Recent.Remove(databaseObject);
            DatabaseManager.Instance.SaveChanges();

            return databaseObject.ToRepositoryModel();
        }

        public Recent Insert(Recent newObject)
        {
            var databaseObject = newObject.ToDBModel();

            DatabaseManager.Instance.Recent.Add(databaseObject);
            DatabaseManager.Instance.SaveChanges();

            return databaseObject.ToRepositoryModel();
        }

        public Recent Update(Recent inputObject)
        {
            var updated = inputObject.ToDBModel();
            var original = DatabaseManager.Instance.Recent.Find(updated.RecentId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(updated);
                DatabaseManager.Instance.SaveChanges();
                return updated.ToRepositoryModel();
            }

            return original.ToRepositoryModel();
        }

    }

}
