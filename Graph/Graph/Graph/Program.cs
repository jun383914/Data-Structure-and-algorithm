using System;
using System.Collections;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> sample = new Graph<int>();
            Vertex<int> firstnode=sample.AddNode(5);
            Vertex<int> secondnode=sample.AddNode(3);
            Vertex<int> thirdnode=sample.AddNode(1);
            List<Vertex<int>> answer = sample.GetNodes();
            foreach(Vertex<int> i in answer)
                Console.WriteLine(i);
            sample.AddEdge(firstnode, secondnode, 4);
            sample.AddEdge(secondnode, thirdnode, 2);
            Console.WriteLine(sample.Size());
            Dictionary<Vertex<int>, int> expected = sample.GetNeighbors(firstnode);
            Console.WriteLine(expected.ContainsValue(3));
        }
    }
    public class Graph<T>
    {
        ArrayList vertices=new ArrayList();

        public Vertex<T> AddNode(T value)
        {
            Vertex<T> newvertex = new Vertex<T>(value);
            vertices.Add(newvertex);
            return newvertex;
        }

        public void AddEdge(Vertex<T> destination,Vertex<T> starting,int weight)
        {
            Edges<T> edgeone = new Edges<T>(weight, destination);
            Edges<T> edgetwo = new Edges<T>(weight, starting);
            destination.edges.AppendToLinkedList(edgeone);
            starting.edges.AppendToLinkedList(edgetwo);
        }
        public int Size()
        {
            return vertices.Count;
        }
        public List<Vertex<T>> GetNodes()
        {
            List<Vertex<T>> result = new List<Vertex<T>>();
            if(vertices.Count==0)
            {
                return null;
            }
            foreach(Vertex<T> i in vertices)
            {
                result.Add(i);
            }
            return result;
        }
        public Dictionary<Vertex<T>,int> GetNeighbors(Vertex<T> givenvertex)
        {
            Dictionary<Vertex<T>, int> result = new Dictionary<Vertex<T>, int>();
            if(givenvertex==null || givenvertex.edges==null)
            {
                return null;
            }
            List<Edges<T>> edges = givenvertex.getEdges();
            foreach (Edges<T> edge in edges)
            {
                result.Add(edge._nextNode, edge._weight);
            }
            return result;
        }
    }
}
