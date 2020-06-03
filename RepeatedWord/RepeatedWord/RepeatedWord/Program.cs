using System;

namespace RepeatedWord
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public static string Repeatedword(string str)
        {
            //Here I assume str only include white space, the expression will be changed based on specific instructions for the problem.
            //Also assume that uppercase and lowercase are not the same word. Based on the problem, if uppercase and lowercase are the same word, 
            //then I need to use .ToLower() to make sure all word is in lowercase and then compare.
            string[] words = str.Split(' ');
            HashTable<string> storewords = new HashTable<string>(words.Length);
            foreach (string word in words)
            {
                
                if(storewords.Contains(word))
                {
                    return word;
                }
                else
                {
                    storewords.add(word, Array.IndexOf(words, word));
                }
            }
            return "There is no repeated word.";
        }
    }

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
