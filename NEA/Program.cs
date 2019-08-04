using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = TestFunctions.CreatTestGraph();
            HelperFunctions.PrintGraph(graph);//Testing to see if the graph is functioning as it should do
            Console.ReadLine();
        }
    }

    static class TestFunctions
    {
        public static Graph CreatTestGraph()
        {
            Graph graph = new Graph();
           
            for (int i = 0; i < 5; i++)
            {
                Node n = new Node(i, i.ToString());
                graph.Nodes.Add(n);
            }
            
            graph.Edges.Add(new Edge(graph.Nodes.ElementAtOrDefault(0), graph.Nodes.ElementAtOrDefault(1), 10.4f));
            return graph;
        }
    }
    static class HelperFunctions
    {
        public static void PrintGraph(Graph graph)
        {
            Console.WriteLine("Nodes:\n");
            foreach (Node node in graph.Nodes)
            {
                Console.WriteLine(node.ReturnFormattedData());
            }
            Console.WriteLine("\nEdges:\n");
            foreach (Edge edge in graph.Edges)
            {
                Console.WriteLine(edge.ReturnFormattedData());
            }

        }
    }
}
