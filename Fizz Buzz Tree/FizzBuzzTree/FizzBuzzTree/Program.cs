using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> testtree = new BinaryTree<int>();
            testtree.Insert(15);
            testtree.Insert(5);
            testtree.Insert(3);
            testtree.Insert(10);
            testtree.Insert(20);
            testtree.Insert(150);

            BinaryTree<string> result = testtree.FizzBuzzTree(testtree);
            Console.WriteLine(result.root._value);
            Console.WriteLine(result.root.leftnode._value);
            Console.WriteLine(result.root.rightnode._value);

        }
    }
    /*Write a function called FizzBuzzTree which takes a tree as an argument. 
     * Without utilizing any of the built-in methods available to your language
     * determine weather or not the value of each node is divisible by 3, 5 or both
     * and change the value of each of the nodes:

        If the value is divisible by 3, replace the value with “Fizz”
        If the value is divisible by 5, replace the value with “Buzz”
        If the value is divisible by 3 and 5, replace the value with “FizzBuzz”
        Return the tree with its new values.*/

    //This challenge involves parsing data type from integer to String, which means each node in the tree will be string type in the end.
    //Node._value should be able to accept a integer or string value. 

    //=============================================================================================
    public class Node<T>
    {
        public T _value { get; set; }
        public Node<T> leftnode { get; set; }
        public Node<T> rightnode { get; set; }
        public Node(T value)
        {
            _value = value;
            leftnode = null;
            rightnode = null;
        }
        public Node()
        {

        }
    }
    public class BinaryTree<T>
    {
        //create basic structure of the BinaryTree class
        public Node<T> root;

        public BinaryTree()
        {
            this.root = null;
        }
        //Write a method to test if tree is empty
        public bool IsEmpty()
        {
            return root == null;
        }
        //Write insert method to test the BinaryTree class later
        public void Insert(T newValue)
        {
            Node<T> newNode = new Node<T>(newValue);

            if (IsEmpty())
            {
                root = newNode;
            }
            else
            {
                Node<T> finger = root;
                while (true)
                {
                    if (Convert.ToInt32(newValue) <= Convert.ToInt32(finger._value))
                    {
                        if (finger.leftnode != null)
                        {
                            finger = finger.leftnode;
                        }
                        else
                        {
                            finger.leftnode = newNode;
                            break;
                        }
                    }
                    else
                    {
                        if (finger.rightnode != null)
                        {
                            finger = finger.rightnode;
                        }
                        else
                        {
                            finger.rightnode = newNode;
                            break;
                        }
                    }
                }
            }
        }
       
        public BinaryTree<string> FizzBuzzTree(BinaryTree<int> intBinaryTree)
        {
            if(intBinaryTree.root==null)
            {
                throw new InvalidOperationException();
            }
            BinaryTree<string> resulttree = new BinaryTree<string>();
            resulttree.root = fizzBuzzTree(intBinaryTree.root);
            return resulttree;
        }
        private static Node<string> fizzBuzzTree(Node<int> node)
        {
            Node<string> resultnode = new Node<string>();
            if(node!=null)
            {
                Node<string> leftnode = fizzBuzzTree(node.leftnode);
                Node<string> rightnode = fizzBuzzTree(node.rightnode);
                resultnode._value = fizzBuzzConverter(node._value);
                resultnode.leftnode = leftnode;
                resultnode.rightnode = rightnode;
            }
            return resultnode;
        }
        private static String fizzBuzzConverter(int value)
        {
            if(value%3==0&&value%5==0)
            {
                return "FizzBuzz";
            }
            else if(value%3==0)
            {
                return "Fizz";
            }
            else if(value%5==0)
            {
                return "Buzz";
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
