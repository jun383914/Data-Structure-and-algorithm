using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                linkedList.addFirst(i);
                Console.WriteLine(linkedList);
            }
            Console.ReadLine();

            linkedList.add(2, 666);
            Console.WriteLine(linkedList);
            Console.ReadLine();

            linkedList.Remove(2);
            Console.WriteLine(linkedList);
            Console.ReadLine();

            linkedList.Remove(4);
            Console.WriteLine(linkedList);


            linkedList.RemoveLast();
            Console.WriteLine(linkedList);

            linkedList.RemoveFirst();
            Console.WriteLine(linkedList);
            Console.ReadLine();


        }
    }
}
