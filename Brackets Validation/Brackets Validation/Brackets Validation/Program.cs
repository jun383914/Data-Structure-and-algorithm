using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BracketValidation("())"));
            Console.WriteLine(BracketValidation("[][]"));
            Console.WriteLine(BracketValidation("{()}"));
            Console.WriteLine(BracketValidation("{[]}()"));

        }

        //Write a function that takes a string as its only argument and should return a boolean representing whether or not the brackets in the string are balanced. 
        //There are 3 types of brackets: [], (), {}.

        //Sample Input: ()[[Extra Characters]]

        //Sample Output: TRUE
        public static bool BracketValidation(string input)
    {
        //I will use Stack class I created earlier to implement this method.
        Stack stack = new Stack();
        for (int i = 0; i < input.Length; i++)
        {
            char chari = input[i];
            if (chari == '('||chari=='{'||chari=='[')
            {
                stack.Push(chari);
            }
            else if((chari==')' && stack.isEmpty())
                || (chari=='}' && stack.isEmpty())
                || (chari==']' && stack.isEmpty()))
            {
                return false;
            }
            else if((chari==')' && stack.Peek()=='(')
                || (chari=='}' && stack.Peek()=='{')
                || (chari==']' && stack.Peek()==']'))
            {
                stack.Pop();
            }
        }
        return true;
    }
    }
    //================================================================================================================    
    //Create a Node class that has properties for the integer value stored in the Node, and a pointer to the next node.
    public class Node
    {
        public char _value;
        public Node next;
        public Node(char value, Node node)
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
        public void Push(char x)
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
        //Define a method called isEmpty that does not take an argument, and returns a boolean indicating whether or not the stack is empty. 
        public Boolean isEmpty()
        {
            if (this.top == null)
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
            while (currentNode != null)
            {
                result.Append("->");
                result.Append(currentNode._value);
                currentNode = currentNode.next;
            }
            Console.WriteLine(result);
        }
    }
}
