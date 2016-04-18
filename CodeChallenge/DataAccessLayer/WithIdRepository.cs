using System;
using System.Collections.Generic;

namespace CodeChallenge
{
    /// <summary>
    /// A class implemented IWithIdRepository interface based on Repository abstract class
    ///  KNOWN ISSUE: Although object reference will be returned after adding, any program shouldn't change stored object's id. This will lose data integrity (key == object.id)
    /// </summary>
    /// <typeparam name="EValue">Must be a class implement IItemWithId</typeparam>
    public class WithIdRepository <EValue> : Repository<int,EValue>, IWithIdRepository<EValue>
        where EValue : class, IItemWithId
    {
        ///Id increament constantly, so duplicate will never happens.
        protected int currentId = 1;

        public WithIdRepository() {}

        /// <summary>
        /// Add function, check if an item have been added before, or add a stored item will lost key/Id integrity.
        /// </summary>
        public bool Add(ref EValue item) {
            //prevent add multiple time.
            if (GetById(item.Id)==item) {
                return false;
            }
            item.Id = currentId;
            currentId += 1;
            return Add(item.Id, item);
        }

        public new IList<EValue> GetAll(){
            return base.GetAll();
        }

        public new IList<EValue> GetBy(List<Func<EValue, bool>> predicates){
            return base.GetBy(predicates);
        }

        public EValue GetById(int id) {
            return base.GetByKey(id);
        }

        public new bool Delete(int id){
            return base.Delete(id);
        }

        public bool Update(EValue item) {
            if (item == null || item.Id == 0) {
                return false;
            }
            return base.Update(item.Id, item);
        }

    }
}