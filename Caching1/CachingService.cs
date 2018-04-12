using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingLibrary
{
    public class CachingService<K, V> : ICachingService<K, V>
    {
        private static object syncLock = new object();
        private readonly CachingAlgorithm<K, V> _algorithm;
        public CachingService()
        {
            _algorithm = new LRUAlgorithm<K, V>();
        }
        public CachingService(CachingAlgorithm<K, V> algorithm)
        {
            if (algorithm != null)
                _algorithm = algorithm;
        }

        public V Get(K key)
        {
            lock (syncLock)
            {
                return _algorithm.Get(key);
            }
        }
        public void Add(K key, V val)
        {
            lock (syncLock)
            {
                _algorithm.Add(key, val);
            }
        }
    }

    //public static class CachingServiceStatic<K, V>
    //{
    //    private static CachingAlgorithm<K, V> _algorithm = new LRUAlgorithm<K, V>();
    //    private static readonly object syncLock = new object();

    //    static void SetAlgorithm(CachingAlgorithm<K, V> algorithm)
    //    {
    //        _algorithm = new LRUAlgorithm<K, V>();
    //    }
    //    static V Get(K key)
    //    {
    //        lock (syncLock)
    //        {
    //            return _algorithm.Get(key);
    //        }
    //    }

    //    static void Add(K key, V val)
    //    {
    //        lock (syncLock)
    //        {
    //            _algorithm.Add(key, val);
    //        }
    //    }
    //}
}
