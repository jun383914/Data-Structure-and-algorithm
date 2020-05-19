using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 9,5,6,3,4};
            InsertionSort(test);
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
        }

        public static void InsertionSort(int[] vs)
        {
            if(vs.Length<1)
            {
                throw new InvalidOperationException();
            }
            for (int i = 1; i < vs.Length; i++)
            {
                int j = i - 1;
                int temp = vs[i];
                while (j>=0&&temp<vs[j])
                {
                    vs[j + 1] = vs[j];
                    //I need to decrement j because I need to make sure smallest number will be in the front
                    j--;
                }
                vs[j + 1] = temp;
            }
        }
    }
}
