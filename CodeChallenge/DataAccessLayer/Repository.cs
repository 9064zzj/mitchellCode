using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge
{
    /// <summary>
    /// Universal abstract class for all repositories. Implemented by Dictionary. All methods are protected in order to avoid access by repository user.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="EValue"></typeparam>
    public abstract class Repository<TKey, EValue>
        where EValue : class
    {
        protected Dictionary<TKey, EValue> Container = new Dictionary<TKey, EValue>();

        protected bool Add(TKey key, EValue item)
        {
            if (item == null || key == null)
            {
                return false;
            }
            if (Container.ContainsKey(key)) {
                return false;
            }
            Container.Add(key, item);
            return true;
        }

        protected IList<EValue> GetAll() {
            return Container.Values.ToList();
        }

        protected IList<EValue> GetBy(List<Func<EValue, bool>> predicates) {
            IList<EValue> list = Container.Values.ToList();
            if(predicates != null && predicates.Count != 0)
            {
                foreach (Func<EValue, bool> predicate in predicates)
                {
                    list = list.Where(predicate).ToList();
                }
            }
            return list;
        }

        protected EValue GetByKey(TKey key) {
            if (key == null) {
                return null;
            }
            EValue defaultItem = null;
            Container.TryGetValue(key, out defaultItem);
            return defaultItem;
        }

        protected bool Delete(TKey key) {
            if (key == null) {
                return false;
            }
            return Container.Remove(key);
        }

        protected bool Update(TKey key, EValue item) {
            if (item == null || key == null) {
                return false;
            }
            if (Container.Remove(key)) {
                Container.Add(key, item);
                return true;
            }
            return false;
        }

        protected int Count {
            get { return Container.Count;  }
        }
    }
}