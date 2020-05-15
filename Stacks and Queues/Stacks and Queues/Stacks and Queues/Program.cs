using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            //test Stack class methods
            /*Stack teststack = new Stack();
            teststack.Push(3);
            teststack.Push(5);
            teststack.Push(7);
            Console.WriteLine(teststack.Pop());
            Console.WriteLine(teststack.Peek());
            teststack.Print();
            teststack.Push(1);
            teststack.Print();*/

            //test Queue class methods
            Queue testQueue = new Queue();
            testQueue.Enqueue(10);
            testQueue.Enqueue(30);
            testQueue.Enqueue(50);
            int peek=testQueue.Peek();
            Console.WriteLine(peek);
            testQueue.Dequeue();
            testQueue.Print();
            Console.WriteLine(testQueue.isEmpty());
        }
    }
    //Create a Node class that has properties for the integer value stored in the Node, and a pointer to the next node.
    public class Node
    {
        public int _value;
        public Node next;
        public Node(int value, Node node)
        {
            _value = value;
            next = node;
        }
    }
    /*Create a Stack class that has a top property. It creates an empty Stack when instantiated. 
    This object should be aware of a default empty value assigned to top when the stack is created.*/
    public class Stack
    {
        Node top;
        public Stack()
        {
            top = null;
        }
        //Define a method called push which takes any integer value as an argument and adds a new node with that value to the top of the stack with an O(1) Time performance.
        public void Push(int x)
        {
            Node toBeAdded = new Node(x,this.top);
            this.top = toBeAdded;

        }
        //Define a method called pop that does not take any argument, removes the node from the top of the stack, and returns the node’s value. 
        public int Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
            int result = this.top._value;
            this.top = this.top.next;
            return result;
        }
        //Define a method called peek that does not take an argument and returns the integer value of the node located on top of the stack, without removing it from the stack.
        public int Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
            int result = this.top._value;
            return result;
        }
        //Define a method called isEmpty that does not take an argument, and returns a boolean indicating whether or not the stack is empty. 
        public Boolean isEmpty()
        {
            if(this.top==null)
            {
                return true;
            }
            return false;
        }
        //Define a print method to test methods I created above
        public void Print()
        {
            Node currentNode = top;
            StringBuilder result = new StringBuilder();
            result.Append("Null");
            while (currentNode!=null)
            {
                result.Append("->");
                result.Append(currentNode._value);
                currentNode = currentNode.next;
            }
            Console.WriteLine(result);
        }
    }
    //============================================================================================
    /*Create a Queue class that has a front property. It creates an empty Queue when instantiated. 
    This object should be aware of a default empty integer value assigned to front when the queue is created.*/
    public class Queue
    {
        Node front;
        Node back;
        public Queue()
        {
            front = null;
            back = null;
        }
    
    //Define a method called enqueue which takes any integer value as an argument and adds a new node with that value to the back of the queue with an O(1) Time performance.
    public void Enqueue(int enqueuevalue)
    {
            Node enqueueNode = new Node(enqueuevalue, null);
            Node currentNode = back;
            if (this.front == null)
            {
                front = enqueueNode;
                back = enqueueNode;
            }
            else
            {
                currentNode.next = enqueueNode;
                back = enqueueNode;
            }
    }
        //Define a method called dequeue that does not take any argument, removes the node from the front of the queue, and returns the node’s integer value.
        public int Dequeue()
        {
            if(this.front==null)
            {
                throw new InvalidOperationException();
            }
            int result = this.front._value;
            this.front = this.front.next;
            return result;
        }
        //Define a method called peek that does not take an argument and returns the integer value of the node located in the front of the queue, without removing it from the queue. 
        public int Peek()
        {
            if(this.front==null&&this.back==null)
            {
                throw new InvalidOperationException();
            }
            int result = this.front._value;
            return result;
        }
        //Define a method called isEmpty that does not take an argument, and returns a boolean indicating whether or not the queue is empty.
        public Boolean isEmpty()
        {
            if(this.front==null)
            {
                return true;
            }
            return false;
        }
        //Define a print method to test my Queue class methods
        public void Print()
        {
            Node currentNode = front;
            StringBuilder result = new StringBuilder();
            while (currentNode != null)
            {
                result.Append(currentNode._value);
                result.Append("->");
                currentNode = currentNode.next;
            }
            result.Append("Null");
            Console.WriteLine(result);
        }
    }
}
