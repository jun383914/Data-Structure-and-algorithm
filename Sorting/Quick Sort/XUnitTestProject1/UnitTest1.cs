using System;
using Xunit;
using Quick_Sort;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        int[] expected = { 3, 8,44,55,65,70};
        [Fact]
        public void Test1()
        {
            int[] test = { 44, 55, 3,70,8,65 };
            Program.QuickSort(test);
            for (int i = 0; i < test.Length; i++)
            {
                Assert.Equal(test[i], expected[i]);
            }
        }
    }
}
