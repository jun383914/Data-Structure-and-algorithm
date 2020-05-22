using System;

namespace Quick_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static void QuickSort<T>(T[] arr) where T : IComparable
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
        }
        public static void QuickSortHelper<T>(T[] arr, int low, int high) where T : IComparable
        {
            if (high - low >= 1) //only do the sort if you have at least two elements 
            {
                /*QuickSort was done by choose a pivot and put value less than pivot on the left side and 
                value greater than pivot will be on the right side.*/
                int newPivotPos = Partition(arr, low, high);
                QuickSortHelper(arr, low, newPivotPos - 1);
                QuickSortHelper(arr, newPivotPos + 1, high);
            }
        }

        public static int Partition<T>(T[] arr, int L, int H) where T : IComparable
        {
            T pivot = arr[L];//I chose the first element as pivot
            while(L<H)
            {
                //Compare pivot with values starting from H position
                while(L<H&&(arr[H].CompareTo(pivot)>0))
                {
                    H--;
                }
                arr[L] = arr[H];
                //Compare pivot with values starting from H position
                while(L<H&&(arr[L].CompareTo(pivot)<0))
                {
                    L++;
                }
                arr[H] = arr[L];
            }
            arr[L] = pivot;
            return L;
        }
    }
}

