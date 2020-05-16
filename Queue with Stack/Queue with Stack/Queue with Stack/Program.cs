using System;
using System.Collections.Generic;
using System.Text;

namespace Queue_with_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test PseudoQueue class
            PseudoQueue test = new PseudoQueue();
            test.Enqueue(1);
            test.Enqueue(3);
            test.Enqueue(5);
            int Dequeueitem=test.Dequeue();
            Console.WriteLine(Dequeueitem);
            test.Print();
        }
    }
    //Implement a Queue using two Stacks. This PseudoQueue class should internally utilize two stack objects implemented in previous exercises. 
    //The PseudoClass should have the following methods:
    //enqueue(value) which inserts value into the PseudoQueue, using a first-in, first-out approach.
    //dequeue() which extracts a value from the PseudoQueue, using a first-in, first-out approach.
    public class PseudoQueue
    {
        Stack stackone;
        Stack stacktwo;
        public PseudoQueue()
        {
            this.stackone = new Stack();
            this.stacktwo = new Stack();
        }
        public void Enqueue(int value)
        {
            while(!stacktwo.isEmpty())
            {
                stackone.Push(stacktwo.Pop());
            }
            stackone.Push(value);
        }
        public int Dequeue()
        {
            while(!stackone.isEmpty())
            {
                stacktwo.Push(stackone.Pop());
            }
            return stacktwo.Pop();
        }
        public void Print()
        {
            StringBuilder result = new StringBuilder();
            Stack samplestack = this.stacktwo;
            while(samplestack.top!=null)
            {
                result.Append("->");
                result.Append(samplestack.top._value);
                samplestack.top = samplestack.top.next;
            }
            result.Append("->");
            result.Append("NULL");
            Console.WriteLine(result);
        }

    }
    //====================================================================================
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
        public Node top;
        public Stack()
        {
            top = null;
        }
        public void Push(int x)
        {
            Node toBeAdded = new Node(x, this.top);
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
        //Define a print method to test methods I created above
        public void Print()
        {
            Node currentNode = top;
            StringBuilder result = new StringBuilder();
            result.Append("Null");
            while (currentNode != null)
            {
                result.Append("->");
                result.Append(currentNode._value);
                currentNode = currentNode.next;
            }
            Console.WriteLine(result);
        }
        //Define a method called isEmpty that does not take an argument, and returns a boolean indicating whether or not the queue is empty.
        public bool isEmpty()
        {
            if (this.top == null)
            {
                return true;
            }
            return false;
        }
    }
    }
