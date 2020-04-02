using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftArray
{
    class Program
    {
        //Insert a number in the middle of a array
        static void Main(string[] args)
        {
            int[] odd = { 1, 2, 4 };
            int[] even = { 1, 2, 4, 5 };
            InserttoArray(3, odd);
            Console.ReadLine();
            InserttoArray(3, even);
        }

        static void InserttoArray(int x, int [] y)
        {
            int[] newArray = new int[y.Length+1];
            int pos = (y.Length + 1) / 2;
            //Method 1
            //int pos = y.Length / 2;
            //int posodd = pos + 1;
            //if (y.Length % 2 == 0)
            //{
            //    newArray[pos] = x;
            //    for (int i = 0; i < pos; i++)
            //        for (int j = y.Length; j > pos; j--)
            //        {
            //            newArray[i] = y[i];
            //            newArray[j] = y[j - 1];
            //        }
            //}
            //else
            //{
            //    newArray[posodd] = x;
            //    for (int i = 0; i <= pos; i++)
            //        for (int j = y.Length; j > posodd; j--)
            //        {
            //            newArray[i] = y[i];
            //            newArray[j] = y[j - 1];
            //        }
            //}
            //    foreach(int m in newArray)
            //{
            //    Console.WriteLine(m.ToString());
            //}
            //Method 2
            for (int i = 0; i < newArray.Length; i++)
                if (i < pos)
                {
                    newArray[i] = y[i];
                }
                else if (i == pos)
                {
                    newArray[i] = x;
                }
                else
                {
                    newArray[i] = y[i - 1];
                }
            foreach(int m in newArray)
            {
                Console.WriteLine(m.ToString());
            }

            //I prefer method 2 which is concise and more readable.
        }
    }
}
