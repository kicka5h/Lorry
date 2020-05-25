using System;
using System.Collections.Generic;
using System.Text;

namespace Lorry.Repository
{
    public interface IDatabaseRepository<T>
    {            
        List<T> GetAll();

        T Get(int key);

        T Update(T updateObject);

        T Insert(T insertObject);

    }
}
