using System;
using Xunit;
using DataStructuresAlgorithms;

namespace MergeSortTest
{
    public class UnitTest1
    {
        public static readonly int[] expectInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        [Fact]
        public void MergeSortTest()
        {
            int[] array = { 10, 0, 3, 11, 8, 9, 1, 12, 5, 2, 4, 6, 7 };
            MergeSort.TopDownSort(array);
            for(int i=0;i<array.Length;i++)
            {
                Assert.Equal(array[i], expectInt[i]);
            }
        }
    }
}
