using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingLibrary
{
    public class MRUAlgorithm<K, V> : CachingAlgorithm<K, V>
    {
        public MRUAlgorithm(int capacity = 100) : base (capacity)
        {
        }
        private Dictionary<K, LinkedListNode<CacheItem<K, V>>> cacheMap = new Dictionary<K, LinkedListNode<CacheItem<K, V>>>();
        private LinkedList<CacheItem<K, V>> list = new LinkedList<CacheItem<K, V>>();
        public override V Get(K key)
        {
            LinkedListNode<CacheItem<K, V>> node;
            if (cacheMap.TryGetValue(key, out node))
            {
                V value = node.Value.value;
                list.Remove(node);
                list.AddFirst(node);
                return value;
            }
            return default(V);
        }
        public override void Add(K key, V val)
        {
            if (cacheMap.Count >= _capacity)
            {
                RemoveFirst();
            }
            LinkedListNode<CacheItem<K, V>> nodeFound;
            if (cacheMap.TryGetValue(key, out nodeFound))
            {
                list.Remove(nodeFound);
                cacheMap.Remove(nodeFound.Value.key);
            }
            CacheItem<K, V> cacheItem = new CacheItem<K, V>(key, val);
            LinkedListNode<CacheItem<K, V>> node = new LinkedListNode<CacheItem<K, V>>(cacheItem);
            list.AddLast(node);
            cacheMap.Add(key, node);
        }

        private void RemoveFirst()
        {
            LinkedListNode<CacheItem<K, V>> node = list.First;
            list.RemoveFirst();
            cacheMap.Remove(node.Value.key);
        }
    }
}
