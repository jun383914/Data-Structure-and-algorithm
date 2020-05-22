using System;

namespace Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /*A hash table is a data structure that allows key-value pairs to be stored within it. 
     * The advantage of a hash table over other data structures is that adding, removing, and lookup operations all take O(1) time to execute.
     * Implement a hash table that has the following methods: 
     * add: takes in both the key and value. This method should hash the key, and add the key and value pair to the table, handling collisions as needed.
       get: takes in a key and returns the value from the table.
       contains: takes in the key and returns a boolean, indicating if the key exists in the table already.
       hash: takes in an arbitrary key and returns an index in the collection.
     *Note: the above operations should all take O(1) time.*/
     public class Node
    {
        public string _key;
        public int _value;
        public Node _next;
        public Node(string key, int value, Node next)
        {
            this._key = key;
            this._next = next;
            this._value = value;
        }
        public Node()
        {
            this._next = null;
        }
    }
     public class HashTable<T>
    {
        int _size;
        Node[] HashArray;
        public HashTable(int size)
        {
            this._size = size;
            this.HashArray = new Node[size];
        }
        //Implementing chain concept using linkedlist can avoid collisions
        public void add(string key,int value)
        {
            int position = hash(key);
            if(this.HashArray[position]==null)
            {
                this.HashArray[position] = new Node(key, value, null);
                return;
            }
            Node currentNode = this.HashArray[position];
            while(currentNode._next!=null)
            {
                currentNode = currentNode._next;
            }
            currentNode._next = new Node(key, value, null);
        }
        public int hash(string key)
        {
           int position = key.GetHashCode()%_size;
            return Math.Abs(position);
        }
        public int get(string key)
        {
            int position = hash(key);
            if(this.HashArray[position]==null)
            {
                throw new NotSupportedException();
            }
            Node currentlist = HashArray[position];
            while(!currentlist._key.Contains(key))
            {
                currentlist = currentlist._next;
            }
            return currentlist._value;
        }
        public bool Contains(string key)
        {
            int position = hash(key);
            Node currentlist = HashArray[position];
            while(currentlist!=null)
            {
                if(HashArray[position]._key.Contains(key))
                {
                    return true;
                }
                currentlist = currentlist._next;
            }
            return false;
        }
    }
}
