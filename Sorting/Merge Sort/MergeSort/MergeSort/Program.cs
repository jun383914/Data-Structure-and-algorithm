using System;

namespace DataStructuresAlgorithms
{

    public static class MergeSort
    {
        static void Main(string[] args)
        {
            int[] test = { 10, 0, 3, 11, 8, 9, 1, 12};
            MergeSort.TopDownSort(test);
            foreach (int item in test)
            {
                Console.WriteLine(item);
            }
        }
        /*Merge Sort is a Divide and Conquer algorithm, meaning it will divide array into array only
        has one element and then merge them back up. There are two ways to implement mergesort: 
        iterative(Bottom-up Merge Sort) and recursive(Top-down Merge Sort)*/
        /*public static void BottomUpSort(int[] a)
        {
            int[] aux = new int[a.Length];
            for (int len = 1; len < a.Length; len *= 2)
            {
                for (int lo = 0; lo < a.Length - len; lo += len + len)
                {
                    int mid = lo + len - 1;
                    int hi = Math.Min(lo + len + len - 1, a.Length - 1);
                    Merge(a, aux, lo, mid, hi);
                }
            }
        }*/

        public static void TopDownSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }
            int length = arr.Length;
            int mid = length / 2;
            int[] left = new int[mid];
            int[] right = new int[length - mid];
            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, length-mid);
            TopDownSort(left);
            TopDownSort(right);
            //merge the sorted array back to arr
            TopDownSortHelper(left, right, arr);
        }

        private static void TopDownSortHelper(int[] left, int[] right, int[] arr)
        {
            //i is the pointer for array left
            int i = 0;
            //j is the pointer for right array
            int j = 0;
            //k is the pointer for the sorted arr array
            int k = 0;
            while(i<left.Length&&j<right.Length)
            {
                if(left[i]<right[j])
                {
                    arr[k++] = left[i++];
                    /*The previouse statement is the same as follows:
                        arr[k]=left[i];
                        k++;
                        i++;
                    I found the smaller value and we set it to the sorted array,
                    then I increment the pointer value to move the pointer*/ 
                }
                else
                {
                    arr[k++] = right[j++];
                }
            }
            //right array was finish but left array was not.
            while(i<left.Length)
            {
                //we assign the rest value in left array to the sorted array
                arr[k++] = left[i++];
            }
            while(j<right.Length)
            {
                arr[k++] = right[j++];
            }
        }

    }
}