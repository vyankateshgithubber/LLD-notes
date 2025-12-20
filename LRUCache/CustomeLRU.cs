public class Node<K, V> 
{
    public K key;
    public V value;
    public Node<K, V> prev;
    public Node<K, V> next;     
    public Node(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}

// Doubly Linked List to hold the keys in order of usage
public class DoublyLinkedList<K, V> 
{
    private Node<K, V> head;
    private Node<K, V> tail;
    public DoublyLinkedList() 
    {
        head = new Node<K, V>(default(K), default(V));
        tail = new Node<K, V>(default(K), default(V));
        head.next = tail;
        tail.prev = head;
    }
    public void AddToFront(Node<K, V> node) 
    {
        node.next = head.next;
        node.prev = head;
        head.next.prev = node;
        head.next = node;
    }
    public void RemoveNode(Node<K, V> node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
    public Node<K, V> RemoveLast()
    {
        if (tail.prev == head)
            return null;
        Node<K, V> lastNode = tail.prev;
        RemoveNode(lastNode);
        return lastNode;        
    }
    public bool IsEmpty() 
    {
        return head.next == tail;
    }
}

public class CustomLRUCache<K, V> 
{
    private int capacity;
    private Dictionary<K, Node<K, V>> cacheMap;
    private DoublyLinkedList<K, V> cacheList;
    private readonly object lockObj = new object();

    public CustomLRUCache(int capacity) 
    {
        this.capacity = capacity;
        cacheMap = new Dictionary<K, Node<K, V>>();
        cacheList = new DoublyLinkedList<K, V>();
    }

    public V Get(K key) 
    {
        lock (lockObj) 
        {   
            if (cacheMap.TryGetValue(key, out Node<K, V> node)) 
            {
                cacheList.RemoveNode(node);
                cacheList.AddToFront(node);
                return node.value;
            }
            return default(V);
        }
    }

    public void Put(K key, V value) 
    {
        lock (lockObj) 
        {
            if (cacheMap.TryGetValue(key, out Node<K, V> node)) 
            {
                node.value = value;
                cacheList.RemoveNode(node);
                cacheList.AddToFront(node);
            } 
            else 
            {
                if (cacheMap.Count >= capacity) 
                {
                    Node<K, V> lruNode = cacheList.RemoveLast();
                    if (lruNode != null) 
                    {
                        cacheMap.Remove(lruNode.key);
                    }
                }
                Node<K, V> newNode = new Node<K, V>(key, value);
                cacheList.AddToFront(newNode);
                cacheMap[key] = newNode;
            }
        }
    }
}