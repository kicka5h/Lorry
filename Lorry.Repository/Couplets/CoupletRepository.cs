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


namespace Lorry.Repository.Couplets
{

    public class CoupletRepository : IDatabaseRepository<Lorry.Repository.Couplets.Couplet>
    { 

        public List<Couplet> GetAll()
        {
            return DatabaseManager.Instance.Couplet.Select(t => t.ToRepositoryModel()).ToList();
        }

        public Couplet Get(int key)
        {
            throw new NotImplementedException();            
        }


        public Couplet Insert(Couplet newObject)
        {
            var databaseObject = newObject.ToDbModel();

            DatabaseManager.Instance.Couplet.Add(databaseObject);
            DatabaseManager.Instance.SaveChanges();

            return databaseObject.ToRepositoryModel();
        }


        public Couplet Update(Couplet inputObject)
        {
            var updated = inputObject.ToDbModel();
            var original = DatabaseManager.Instance.Couplet.Find(updated.CoupletId);

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
