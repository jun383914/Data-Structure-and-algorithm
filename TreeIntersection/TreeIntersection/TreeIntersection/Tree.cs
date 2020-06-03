using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace TreeIntersection
{
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
    }
}
