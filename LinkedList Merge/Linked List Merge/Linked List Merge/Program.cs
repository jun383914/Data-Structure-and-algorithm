using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List_Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            Linkedlist linkedlist = new Linkedlist();
            linkedlist.AppendToLinkedList(1);
            linkedlist.AppendToLinkedList(3);
            linkedlist.AppendToLinkedList(5);
            Linkedlist linkedlist2 = new Linkedlist();
            linkedlist2.AppendToLinkedList(2);
            linkedlist2.AppendToLinkedList(4);
            Linkedlist result=linkedlist.Mergelist(linkedlist, linkedlist2);
            result.printLinkedList();
        }
        //Write a function called mergeLists which takes two linked lists as arguments. 
        //Zip the two linked lists together into one so that the nodes alternate between the two lists 
        //and return a reference to the head of the zipped list. Try and keep additional space down to O(1). 
    }
    public class Node
    {
        public int _value;
        public Node _node;
        public Node()
        {

        }
        public Node(int value, Node node)
        {
            _value = value;
            _node = node;
        }
    }
    public class Linkedlist
    {
        public Node head;

        //Two methods are created to merge to linkedlist, this one is using recursion.
        public Linkedlist Mergelist(Linkedlist A, Linkedlist B)
        {
            Node nodeA = A.head;
            Node nodeB = B.head;
            A.head = mergeList(nodeA, nodeB);
            return A;
        }
        private Node mergeList(Node A,Node B)
        {
            if(A==null)
            {
                return B;
            }
            else
            {
                A._node = mergeList(B, A._node);
                return A;
            }
        }
        //The second method is to traverse the linkedlist
        /*public Linkedlist Mergelist(Linkedlist A, Linkedlist B)
        {
            if (A.head == null)
            {
                return B;
            }
            Node nodeA = A.head;
            Node nodeB = B.head;
            while(nodeA!=null&&nodeB!=null)
            {
                Node tempA = nodeA._node;
                Node tempB = nodeB._node;
                if(nodeA._node!=null)
                {
                    nodeB._node = nodeA._node;
                }
                nodeA._node = nodeB;
                nodeA = tempA;
                nodeB = tempB;
            }
            return A;
        }*/


        //============================================

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
    }


}
