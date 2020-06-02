using System;
using System.Collections.Generic;
using System.Text;

namespace Lorry.Repository
{
    public interface IDatabaseRepository<T>
    {
        //get a list of all the objects
        List<T> GetAll();

        //get a specific object by its primary key
        T Get(int key);

        //make changes to an object
        T Update(T updateObject);

        //add a new object
        T Insert(T insertObject);

        //delete an object
        T Delete(T deleteObject);
    }
}
