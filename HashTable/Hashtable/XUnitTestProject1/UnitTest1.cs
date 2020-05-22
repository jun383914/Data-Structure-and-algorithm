using System;
using Xunit;
using Hashtable;

namespace XUnitTestProject1
{
    public class HashTableTest
    {
        HashTable<int> test = new HashTable<int>(1000);

        [Fact]
        public void TestaddandgetMethod()
        {
            test.add("Me", 5);
            test.add("Zhen", 3);
            test.add("You", 7);
            int result = test.get("Me");
            Assert.Equal(5, result);
        }
        [Fact]
        public void TestContainsMethod()
        {
            test.add("Me", 5);
            test.add("Zhen", 3);
            test.add("You", 7);
            Boolean result = test.Contains("Zhen");
            Assert.True(result);
            Boolean result2 = test.Contains("Yang");
            Assert.False(result2);
        }
    }
}
