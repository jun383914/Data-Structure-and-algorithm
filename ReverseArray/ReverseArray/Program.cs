using System;

namespace ReversedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 3, 4, 5, 6 };
            ReverseArray(test);
            foreach(int i in test)
            {
                Console.WriteLine(i);
            }
        }

        public static void ReverseArray(int[] array)
        {
            //Array with less than 2 elements doesn't need to be reversed
            if (array.Length > 1)
            {
                for (int i = 0; i < (array.Length - 1) / 2; i++)
                {
                    int previousValue = array[array.Length - i - 1];
                    array[array.Length - i - 1] = array[i];
                    array[i] = previousValue;
                }
            }
        }
    }
}
