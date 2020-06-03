using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace TreeIntersection
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static ArrayList Treeintersect(BinaryTree<int> treeA, BinaryTree<int> treeB)
        {
            ArrayList result = new ArrayList();
            int[] treeAInteger = treeA.preOrder();
            int[] treeBInteger = treeB.preOrder();
            //I will use Hashtable here to store treeA integers and use hashtable contains function to check if two trees have any intersection
            // and store them in result ArrayList.
            HashTable<int> treeAint = new HashTable<int>(treeAInteger.Length);
            foreach(int i in treeAInteger)
            {
                treeAint.add(i.ToString(), 0);
            }
            foreach (int integer in treeBInteger)
            {
                if(treeAint.Contains(integer.ToString()))
                {
                    result.Add(integer);
                }
            }
            return result;
        }
    }

}
