using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_KthFromEnd
{
    class Program
    {
         static void Main(string[] args)
        {
            Linkedlist linkedlist = new Linkedlist();
            linkedlist.AppendToLinkedList(1);
            linkedlist.AppendToLinkedList(3);
            linkedlist.AppendToLinkedList(5);
            Console.WriteLine(linkedlist.Size());
            Console.WriteLine(linkedlist.kthFromEnd(0));

        }
        //Write a method which takes a number k as a parameter and return
        //the node's value that is k from the end of the linkedlist.
    }
    //Create LinkedList class
    public class Node
    {
        public Node _node;
        public int _value;
        public Node(int value,Node node)
        {
            _value = value;
            _node = node;
        }
    }
    public class Linkedlist
    {
        public int _value;
        public Node _node;
        public Node head;

        public Linkedlist()
        {
            _node = null;
        }
        public int Size()
        {
            int counter = 0;
            Node current = this.head;
            while(current!=null)
            {
                counter++;
                current = current._node;
            }
            return counter;
        }
        public int kthFromEnd(int k)
        {
            int counter = this.Size();
            if(k>counter)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 1; i < (counter-k); i++)
            {
                this.head = this.head._node;
            }
            return this.head._value;
        }




        //===================================================================

        public void printLinkedList()
        {
            Node currentNode = head;
            StringBuilder result = new StringBuilder();
            while (currentNode != null)
            {
                result.Append(currentNode._value);
                result.Append("->");
                currentNode = currentNode._node;
            }
            result.Append("NULL");

            Console.WriteLine(result);
        }
        public void InsertBefore(int Beforethisvalue, int valuetobeinserted)
        {
            if (this.head._value == Beforethisvalue)
            {
                this.head = new Node(valuetobeinserted, this.head);
                return;
            }
            Node currentNode = this.head;
            while (currentNode._node != null)
            {
                if (currentNode._node._value == Beforethisvalue)
                {
                    currentNode._node = new Node(valuetobeinserted, currentNode._node);
                    return;
                }

                currentNode = currentNode._node;
            }
            throw new Exception("Cannot find the correct place to insert the value");
        }
        public void InsertAfter(int Afterthisvalue, int valuetobeinserted)
        {
            Node currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode._value == Afterthisvalue)
                {
                    currentNode._node = new Node(valuetobeinserted, currentNode._node);
                }
                currentNode = currentNode._node;
            }
            throw new Exception("This value cannot be inserted");
        }
        public void Delete(int tobeDeleted)
        {
            Node currentNode = this.head;

            if (this.head._value == tobeDeleted)
            {
                head = currentNode._node;
            }
            while (currentNode._node != null)
            {
                if (currentNode._node._value == tobeDeleted)
                {
                    currentNode._node = currentNode._node._node;
                    break;
                }
                currentNode = currentNode._node;
            }
            throw new Exception("value cannot be deleted because it doesn't exist in linkedlist");
        }
        public void AppendToLinkedList(int I)
        {
            Node node = new Node(I, null);
            if (head == null)
            {
                this.head = node;
                return;
            }
            Node currentNode = head;
            while (currentNode._node != null)
            {
                currentNode = currentNode._node;
            }
            currentNode._node = node;
        }
    }
}

