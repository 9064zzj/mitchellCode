using System;
using System.Collections.Generic;

namespace CodeChallenge
{
    /// <summary>
    /// Repository interface that can store and do CRUD operation for class that implemented IItemWithId interface
    /// </summary>
    /// <typeparam name="EValue">Must be a class implement IItemWithId</typeparam>
    public interface IWithIdRepository <EValue>
        where EValue : class, IItemWithId
    {
        IList<EValue> GetAll();

        IList<EValue> GetBy(List<Func<EValue, bool>> predicates);

        EValue GetById(int id);

        bool Add(ref EValue item);

        bool Delete(int id);

        bool Update(EValue item);

    }
}