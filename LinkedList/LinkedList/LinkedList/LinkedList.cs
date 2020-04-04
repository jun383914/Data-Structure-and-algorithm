using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    //Basic structure and methods for Linkedlist class
    public class LinkedList<T>
    {
        private class Node
        {
            public T t;
            public Node next;

            public Node(T t, Node next)
            {
                this.t = t;
                this.next = next;
            }
            public Node(T t)
            {
                this.t = t;
                this.next = null;
            }
            public Node()
            {
            }
            public override string ToString()
            {
                return t.ToString();
            }
        }
            private Node dummyhead;
            private int size;

            public LinkedList()
            {
                dummyhead = null;
                size = 0;
            }
        //Check how many element is in the LinkedList
        public int getSize()
        {
            return size;
        }
        //Check if the Linkedlist is empty
        public Boolean isEmpty()
        {
            return size == 0;
        }

        //Add a new element in the middle of the LinkedList
        public void add(int pos, T t)
        {
            if (pos < 0 || pos > size)
                throw new IndexOutOfRangeException("Add failed. Illegal index.");

                Node prev = dummyhead;
                    prev = prev.next;
                    prev.next = new Node(t, prev.next);
                    size++;       
        }
        //Add a new element at the head of the LinkedList
        public void addFirst(T t)
        {
            //Node node = new Node(t);
            //node.next = dummyhead;
            //dummyhead = node;
            //size++;
            dummyhead=new Node(t,dummyhead);
            size++;
        }
        //Add a new element at the end of the LinkedList
        public void addLast(T t)
        {
            add(size, t);
        }
        //Method to get element at a specified position
        public T get(int pos)
        {
            if (pos < 0 || pos >= size)
                throw new InvalidOperationException("Get failed. Illegal index.");

            Node current = dummyhead;
            for (int i = 0; i < pos; i++)            
                current = current.next;
                return current.t;
        }
        //method to edit an element at a specified position
        public void set(int pos, T t)
        {
            if (pos < 0 || pos >= size)
                throw new InvalidOperationException("Get failed. Illegal index.");

            Node current = dummyhead;
            for (int i = 0; i < pos; i++)
            
                current = current.next;
                current.t = t;            
        }
        //check if the LinkedList contains a certain value
        public Boolean contains(T t)
        {
            Node current = dummyhead;
            while (current != null)
            {
                if (current.t.Equals(t))
                    return true;
                current=current.next;
            }
            return false;
        }

        //Method to remove and return an element from linkedlist based on the position
        public T Remove(int pos)
        {
            if (pos < 0 || pos >= size)
                throw new IndexOutOfRangeException("Remove failed. Index is illegal.");
            else
            {
                Node prev = dummyhead;
                for (int i = 0; i < pos; i++)
                { prev = prev.next; }

                Node result = prev.next;
                prev.next = result.next;
                result.next = null;
                size--;

                return result.t;
            }
        }
        //Based on the Remove method, we can implement RemoveFirst and RemoveLast method
        public T RemoveFirst()
        {
            Node result = dummyhead.next;
            dummyhead.next = result.next;
            result.next = null;
            return result.t;
        }
        public T RemoveLast()
        {
            return Remove(size - 1);
        }
        //complete a ToString method to printout all elements in a Linkedlist
        public override String ToString()
        {
            StringBuilder result = new StringBuilder();

            Node current = dummyhead;
            while (current != null)
            {
                result.Append(current + "->");
                current = current.next;
            }
            result.Append("Null");
            return result.ToString();
        }
    }
}
