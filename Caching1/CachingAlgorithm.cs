using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingLibrary
{
    public abstract class CachingAlgorithm<K, V>
    {
        protected readonly int _capacity;
        public CachingAlgorithm(int capacity)
        {
            _capacity = capacity;
        }
        public abstract V Get(K key);
        public abstract void Add(K key, V val);
    }
}
