using System;
using TreeIntersection;
using System.Collections;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

    [Fact]
        public void Test1()
        {
            BinaryTree<int> tree1 = new BinaryTree<int>();
            tree1.Insert(1);
            tree1.Insert(3);
            tree1.Insert(5);
            BinaryTree<int> tree2 = new BinaryTree<int>();
            tree2.Insert(3);
            tree2.Insert(1);
            tree2.Insert(6);
            ArrayList result = new ArrayList();
            result = Program.Treeintersect(tree1, tree2);
            Assert.Equal("3", result[0].ToString());
            Assert.Equal("1", result[1].ToString());

        }
    }
}
