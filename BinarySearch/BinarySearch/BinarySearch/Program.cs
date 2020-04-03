using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] duplicate = { 1, 3, 3, 4, 5 };
            int[] input = { 1, 3, 4, 5, 6 };
            Console.WriteLine(BinarySearch(duplicate, 4));
        }

        //Write a method called BinarySearch which takes 2 parameter: a sorted array and a search key
        //Return the index of the array's element that is equal to the search key, or -1 if the element doesn't exist.

        static int BinarySearch(int[] sorted, int key)
        {
            int leftlimit = 0;
            int rightlimit = sorted.Length;
            while (leftlimit<rightlimit)
            {
                int half = (rightlimit + leftlimit) / 2;
                if (key>sorted[half])
                {
                    leftlimit = half;
                }
                else if (key<sorted[half])
                {
                    rightlimit = half;
                }
                else if (key==sorted[half])
                {
                    return half;
                }
            }
            return -1;
        }
    }
}
//Binary Search: How I think about it is I always need to seperate the data into two sets, and then companre, then seperate again, then compare.
//So the right and left limited of the set will be changing so it's good to set these two variable at the begining.
