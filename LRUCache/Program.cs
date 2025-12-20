using System;
using System.Collections.Generic;

public class LRUCache<K, V> {
    public int Capacity { get; private set; }
    private Dictionary<K, KeyValuePair<V, LinkedListNode<K>>> CacheMap;
    private LinkedList<K> CacheList;

    public LRUCache(int capacity) {
        Capacity = capacity;
        CacheList = new LinkedList<K>();
        CacheMap = new Dictionary<K, KeyValuePair<V, LinkedListNode<K>>>();
    }    
    public V Get(K key) {
        if (CacheMap.TryGetValue(key, out KeyValuePair<V, LinkedListNode<K>> value)) {
            CacheList.Remove(value.Value);
            LinkedListNode<K> newNode = CacheList.AddLast(key);
            CacheMap[key] = new KeyValuePair<V, LinkedListNode<K>>(value.Key, newNode);
            return value.Key;
        }
        return default;
    }
    public void Put(K key, V value) {
        if (CacheMap.TryGetValue(key, out KeyValuePair<V, LinkedListNode<K>> existingValue)) {
            CacheList.Remove(existingValue.Value);
            LinkedListNode<K> newNode = CacheList.AddLast(key);
            CacheMap[key] = new KeyValuePair<V, LinkedListNode<K>>(value, newNode);
        } else {
            if (CacheMap.Count >= Capacity) {
                K lruKey = CacheList.First.Value;
                CacheList.RemoveFirst();
                CacheMap.Remove(lruKey);
            }
            LinkedListNode<K> newNode = CacheList.AddLast(key);
            CacheMap[key] = new KeyValuePair<V, LinkedListNode<K>>(value, newNode);
        }
    }
}

public static class Program {
    public static void Main() {
        LRUCache<int, string> lruCache = new LRUCache<int, string>(2);
        lruCache.Put(1, "One");
        lruCache.Put(2, "Two");
        Console.WriteLine(lruCache.Get(1)); // Outputs: One
        lruCache.Put(3, "Three"); // Evicts key 2
        Console.WriteLine(lruCache.Get(2)); // Outputs: (null)
        lruCache.Put(4, "Four"); // Evicts key 1
        Console.WriteLine(lruCache.Get(1));
        Console.WriteLine(lruCache.Get(3)); // Outputs: (null)
        Console.WriteLine(lruCache.Get(4)); // Outputs: Four
    }
} 
