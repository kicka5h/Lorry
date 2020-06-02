using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lorry.Repository.Haikus
{
    public class HaikuRepository : IDatabaseRepository<Lorry.Repository.Haikus.Haiku>
    {

        public List<Haiku> GetAll()
        {
            return DatabaseManager.Instance.Haiku.Select(t => t.ToRepositoryModel()).ToList();
        }

        public Haiku Get(int key)
        {
            throw new NotImplementedException();
        }

        public Haiku Delete(Haiku deleteObject)
        {
            var databaseObject = deleteObject.ToDbModel();
            var original = DatabaseManager.Instance.Recent.Find(databaseObject.HaikuId);

            DatabaseManager.Instance.Recent.Remove(original);
            DatabaseManager.Instance.SaveChanges();

            return databaseObject.ToRepositoryModel();
        }

        public Haiku Insert(Haiku newObject)
        {
            var databaseObject = newObject.ToDbModel();

            DatabaseManager.Instance.Haiku.Add(databaseObject);
            DatabaseManager.Instance.SaveChanges();

            return databaseObject.ToRepositoryModel();
        }


        public Haiku Update(Haiku inputObject)
        {
            var updated = inputObject.ToDbModel();
            var original = DatabaseManager.Instance.Haiku.Find(updated.HaikuId);

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
