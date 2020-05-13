using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedlist_Insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            //test appendtolinkedlist
            linkedlist Linkedlist = new linkedlist();
            Linkedlist.AppendToLinkedList(3);
            Linkedlist.AppendToLinkedList(5);
            Linkedlist.InsertBefore(5,4);
            Linkedlist.InsertBefore(3,2);
            Linkedlist.printLinkedList();
            //Linkedlist.InsertBefore(1, 20);
            Linkedlist.Delete(1);
            Linkedlist.printLinkedList();
        }
        //Extending LinkedList Class to append, insertBefore, insertAfter, and delete

    }
    //Create Node class
    public class Node
    {
         public int _value;
         public Node _node;

        public Node(int value, Node node)
        {
            _value =value;
            _node = node;
        }
    }
    //Create Linkedlist class
    public class linkedlist
    {
        public Node head;
        public linkedlist()
        {
            this.head = null;
        }
        public void AppendToLinkedList(int I)
        {
            Node node = new Node(I, null);
            if(head==null)
            {
                this.head = node;
                return;
            }
                Node currentNode = head;
                while(currentNode._node!=null)
                {
                    currentNode = currentNode._node;
                }
                currentNode._node = node;
        }
        public void printLinkedList()
        {
            Node currentNode = head;
            StringBuilder result = new StringBuilder();
            while(currentNode!=null)
            {
                result.Append(currentNode._value);
                result.Append("->");
                currentNode = currentNode._node;
            }
            result.Append("NULL");

            Console.WriteLine(result);
        }
        public void InsertBefore(int Beforethisvalue,int valuetobeinserted)
        {
            if(this.head._value==Beforethisvalue)
            {
                this.head = new Node(valuetobeinserted, this.head);
                return;
            }
            Node currentNode = this.head;
            while(currentNode._node!=null)
            {
                if(currentNode._node._value==Beforethisvalue)
                {
                    currentNode._node = new Node(valuetobeinserted, currentNode._node);
                    return;
                }

                currentNode = currentNode._node;
            }
            throw new Exception("Cannot find the correct place to insert the value");
        }
        public void InsertAfter(int Afterthisvalue,int valuetobeinserted)
        {
            Node currentNode = this.head;
                while(currentNode!=null)
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

            if (this.head._value==tobeDeleted)
            {
                head = currentNode._node;
            }
            while(currentNode._node!=null)
            {
                if(currentNode._node._value==tobeDeleted)
                {
                    currentNode._node = currentNode._node._node;
                    break;
                }
                currentNode = currentNode._node;
            }
            throw new Exception("value cannot be deleted because it doesn't exist in linkedlist");
        }
    }


}
