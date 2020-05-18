using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeExample
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

            int[] preorder=binaryTree.preOrder();
            foreach(int i in preorder)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==================");
            int[] inorder = binaryTree.inOrder();
            foreach (int i in inorder)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==================");
            int[] postorder = binaryTree.postOrder();
            foreach (int i in postorder)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==================");
            ArrayList arrayList = binaryTree.BreathFirstTraversal();
            foreach (int item in arrayList)
            {
                Console.WriteLine(item);
            }
            binaryTree.DisplayNumLeaves();
            binaryTree.DisplayHeight();
        }
    }
    /*Create a Node class that has properties for the value stored in the node,the left child node, and the right child node.
      Create a BinaryTree class
        Define a method for each of the depth first traversals called preOrder, inOrder, and postOrder which returns an array of the values, ordered appropriately.
     Create a BinarySearchTree class
        Define a method named add that accepts a value, and adds a new node with that value in the correct location in the binary search tree.
        Define a method named contains that accepts a value, and returns a boolean indicating whether or not the value is in the tree at least once.*/
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
        public int[] postOrderHelper(Node<T> root,ArrayList arraylist)
        {
            if(root!=null)
            {
                postOrderHelper(root.rightnode, arraylist);
                arraylist.Add(root._value);
                postOrderHelper(root.leftnode, arraylist);
            }
            return arraylist.ToArray(typeof(int)) as int[];
        }
        //I created two extra methods here to track number of leaf nodes and height of the tree
        public void DisplayNumLeaves()
        {
            Console.WriteLine("\nNumber of leaf nodes: {0}", CountNumLeavesHelper(root));
        }
        public int CountNumLeavesHelper(Node<T> root)
        {
            if(root==null)
            {
                return 0;
            }
            else if(root.leftnode==null && root.rightnode==null)
            {
                return 1;
            }
            else
            {
                return CountNumLeavesHelper(root.leftnode) + CountNumLeavesHelper(root.rightnode);
            }
        }
        public void DisplayHeight()
        {
            Console.WriteLine("\nHeight: {0}", DisplayHeightHelper(root));
        }
        public int DisplayHeightHelper(Node<T> root)
        {
            if(root==null)
            {
                return -1;
            }
            return 1 + Math.Max(DisplayHeightHelper(root.leftnode), DisplayHeightHelper(root.rightnode));
        }
        //Adding BreathFirstTraversal here
        public ArrayList BreathFirstTraversal()
        {
            ArrayList arrayList = new ArrayList();
            BreathFirstTraversalHelper(root, arrayList);
            return arrayList;
        }
        public void BreathFirstTraversalHelper(Node<T> root,ArrayList arrayList)
        {
            Queue<Node<T>> treeQueue = new Queue<Node<T>>();
            treeQueue.Enqueue(root);
            while(treeQueue.Count!=0)
            {
                Node<T> traversalNode = treeQueue.Dequeue();
                arrayList.Add(traversalNode._value);
                if(traversalNode.leftnode!=null)
                {
                    treeQueue.Enqueue(traversalNode.leftnode);
                }
                if(traversalNode.rightnode!=null)
                {
                    treeQueue.Enqueue(traversalNode.rightnode);
                }
            }
        }
    }

//=======================================================================================================================
    public class BinarySearchTree<T>: BinaryTree<T>
    {
        public void Add(T value)
        {
            root = add(root, value);
        }
        public Node<T> add(Node<T> node,T value)
        {
            if(node==null)
            {
                return new Node<T>(value);
            }
            if(Convert.ToInt32(value)<Convert.ToInt32(root._value))
            {
                node.leftnode = add(node.leftnode, value);
            }
            else if(Convert.ToInt32(value)>Convert.ToInt32(node._value))
            {
                node.rightnode = add(node.rightnode, value);
            }
            return node;
        }
        public bool Contains(int value)
        {
            return contains(root, value);
        }
        public bool contains(Node<T> node, int value)
        {
            if(node==null)
            {
                return false;
            }
            if((Convert.ToInt32(node._value))==value)
            {
                return true;
            }
            else if(value>Convert.ToInt32(node._value))
            {
                contains(node.rightnode, value);
            }
            else
            {
                contains(node.leftnode, value);
            }
            return false;
        }
    }
}
