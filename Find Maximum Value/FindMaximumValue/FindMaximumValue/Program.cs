using System;
using System.Collections;
using System.Collections.Generic;

namespace FindMaximumValue
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(1);
            binaryTree.Insert(7);
            binaryTree.Insert(4);
            binaryTree.Insert(6);
            binaryTree.Insert(9);
            Console.WriteLine(binaryTree.FindMax());
        }
    }
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
        public int FindMax()
        {
            return findMax(root);
        }
        public int findMax(Node<T> node)
        {
            int highest = int.MinValue;
            if(root==null)
            {
                throw new InvalidOperationException();
            }
            Queue<Node<T>> treeQueue = new Queue<Node<T>>();
            treeQueue.Enqueue(root);
            while(treeQueue.Count!=0)
            {
                Node<T> traversalNode = treeQueue.Dequeue();
                if(Convert.ToInt32(traversalNode._value)>highest)
                {
                    highest = Convert.ToInt32(traversalNode._value);
                }
                if(traversalNode.leftnode!=null)
                {
                    treeQueue.Enqueue(traversalNode.leftnode);
                }
                if (traversalNode.rightnode != null)
                {
                    treeQueue.Enqueue(traversalNode.rightnode);
                }
            }
            return highest;
        }
        //==================================================================================================
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
        //Traverse a tree
        public int[] preOrder()
        {
            ArrayList arrayList = new ArrayList();
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            return preOrderHelper(root, arrayList).ToArray(typeof(int)) as int[];
        }
        public ArrayList preOrderHelper(Node<T> root, ArrayList arrayList)
        {
            if (root != null)
            {
                arrayList.Add(root._value);
                preOrderHelper(root.leftnode, arrayList);
                preOrderHelper(root.rightnode, arrayList);
            }
            return arrayList;
        }
        public int[] inOrder()
        {
            ArrayList arrayList = new ArrayList();
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            return inOrderHelper(root, arrayList);
        }
        public int[] inOrderHelper(Node<T> root, ArrayList arrayList)
        {
            if (root != null)
            {
                inOrderHelper(root.leftnode, arrayList);
                arrayList.Add(root._value);
                inOrderHelper(root.rightnode, arrayList);
            }
            return arrayList.ToArray(typeof(int)) as int[];
        }

        public int[] postOrder()
        {
            ArrayList arrayList = new ArrayList();
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            return postOrderHelper(root, arrayList);
        }
        public int[] postOrderHelper(Node<T> root, ArrayList arraylist)
        {
            if (root != null)
            {
                postOrderHelper(root.rightnode, arraylist);
                arraylist.Add(root._value);
                postOrderHelper(root.leftnode, arraylist);
            }
            return arraylist.ToArray(typeof(int)) as int[];
        }
    }
}
