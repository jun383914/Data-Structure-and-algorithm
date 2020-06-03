using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeIntersection
{
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
        public void add(string key, int value)
        {
            int position = hash(key);
            if (this.HashArray[position] == null)
            {
                this.HashArray[position] = new Node(key, value, null);
                return;
            }
            Node currentNode = this.HashArray[position];
            while (currentNode._next != null)
            {
                currentNode = currentNode._next;
            }
            currentNode._next = new Node(key, value, null);
        }
        public int hash(string key)
        {
            int position = key.GetHashCode() % _size;
            return Math.Abs(position);
        }
        public int get(string key)
        {
            int position = hash(key);
            if (this.HashArray[position] == null)
            {
                throw new NotSupportedException();
            }
            Node currentlist = HashArray[position];
            while (!currentlist._key.Contains(key))
            {
                currentlist = currentlist._next;
            }
            return currentlist._value;
        }
        public bool Contains(string key)
        {
            int position = hash(key);
            Node currentlist = HashArray[position];
            while (currentlist != null)
            {
                if (HashArray[position]._key.Contains(key))
                {
                    return true;
                }
                currentlist = currentlist._next;
            }
            return false;
        }
    }
}
