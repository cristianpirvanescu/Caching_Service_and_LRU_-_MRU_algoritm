using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingLibrary
{
    public interface ICachingService<K, V>
    {
        V Get(K key);
        void Add(K key, V val);
    }
}
