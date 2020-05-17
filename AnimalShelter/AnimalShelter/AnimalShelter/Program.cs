using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    //Create a class called AnimalShelter which holds only dogs and cats. The shelter operates using a first-in, first-out approach. Implement the following methods:

    /*enqueue(animal) : adds animal to the shelter.animal can be either a dog or a cat object.
      dequeue(pref) : returns either a dog or a cat. If pref is not "dog" or "cat" then return null.*/

    //Since the shelter operates using a FIFO method, I will use Queue class to implement AnimalShelter.
    public class AnimalShelter
    {
        Queue cat; 
        Queue dog; 
        public AnimalShelter()
        {
            cat = new Queue();
            dog = new Queue();
        }
        public void Enqueue(string name)
        {
            string namelowercase = name.ToLower();
            if(namelowercase.Equals("cat"))
            {
                cat.Enqueue(namelowercase);
            }
            else if(namelowercase.Equals("dog"))
            {
                dog.Enqueue(namelowercase);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public string Dequeue(string pref)
        {
            string prefferd = pref.ToLower();

            if(prefferd.Equals("cat"))
            {
                if(!dog.isEmpty())
                {
                    return dog.Dequeue();
                }
            }
            else if(prefferd.Equals("cat"))
            {
                if(!cat.isEmpty())
                {
                    return cat.Dequeue();
                }
            }
            Console.WriteLine("Neither cat or dog selected.");
            return null;
        }
    }

    //============================================================================
    public class Node
    {
        public string _value;
        public Node next;
        public Node(string value, Node node)
        {
            _value = value;
            next = node;
        }
    }
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
        public void Enqueue(string enqueuevalue)
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
        public string Dequeue()
        {
            if (this.front == null)
            {
                throw new InvalidOperationException();
            }
            string result = this.front._value;
            this.front = this.front.next;
            return result;
        }
        public Boolean isEmpty()
        {
            if (this.front == null)
            {
                return true;
            }
            return false;
        }
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
