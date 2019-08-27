using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public interface IContainsID
    {
        int ID
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\temp\\NEA\\data.xml";
            //Graph graph = TestFunctions.CreateTestGraph();
            // XmlHandler.SerializeGeneric<Graph>(graph, path);
            Graph graph = XmlHandler.DeserializeGeneric<Graph>(path);
            HelperFunctions.PrintGraph(graph);
            Console.ReadLine();
        }
    }

    static class TestFunctions
    {
        public static Graph CreateTestGraph()
        {
            Graph graph = new Graph();
           
            for (int i = 0; i < 5; i++)
            {
                Node n = new Node(i, i.ToString());
                graph.Nodes.Add(n);
            }
            
            graph.Edges.Add(new Edge(graph.Nodes.ElementAtOrDefault(0), graph.Nodes.ElementAtOrDefault(1), 10.4f,1));
            return graph;
        }
    }
    static class HelperFunctions
    {
        public static void PrintGraph(Graph graph)//Also a test function will most likely remove in the finished project.
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
        public static t SearchById<t>(List<t> list, int ID) where t : IContainsID
        {
            return list.First(x => x.ID == ID);
        }
    }
}
