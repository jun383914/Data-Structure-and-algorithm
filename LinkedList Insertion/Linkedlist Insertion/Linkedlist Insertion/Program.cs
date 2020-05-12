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
            //Linkedlist.AppendToLinkedList(8);
            //Linkedlist.AppendToLinkedList(9);
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
    }


}
