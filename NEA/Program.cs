﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
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
        public static Graph graph = TestFunctions.CreateTestGraph();
        public static string GeneralPath = Environment.SpecialFolder.ApplicationData + "\\NEA";
        static void Main(string[] args)
        {

            string path = "C:\\temp\\NEA\\data.xml";//Make this more universal
            if (!Directory.Exists(GeneralPath))
            {
                Directory.CreateDirectory(GeneralPath);
                Console.WriteLine("Tests");
            }
             //XmlHandler.SerializeGeneric<Graph>(graph, path);//TODO: sort out issue with serialization (it is possibly something needing to be changed with teh create test graph function - it is time to make a specific 
             //dungeon to test with going forward that can be used as a benchmark)
            //Graph graph = XmlHandler.DeserializeGeneric<Graph>(path);
            HelperFunctions.PrintGraph(graph);
            graph.Target = HelperFunctions.SearchById<Node>(graph.Nodes, 1);
            QLearning.graph = graph;
            QLearning.InitialiseRMatrix();
            //Console.WriteLine(QLearning.RMatrix);
            for (int i = 0; i < QLearning.RMatrix.GetLength(0); i++)//prints out all of the rows of the array to display it as a matrix TODO: remove this as it is only for testing.
            {
                for (int e = 0; e < QLearning.RMatrix.GetLength(1); e++)
                {
                    Console.Write(QLearning.RMatrix[i,e] + " ");
                }
                Console.WriteLine("");
            }
           
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
                Node n = new Node(i, i.ToString(),new CombatEncounter(150, null));
                graph.Nodes.Add(n);
            }
            
            graph.Edges.Add(new Edge(graph.Nodes.ElementAtOrDefault(0), graph.Nodes.ElementAtOrDefault(1), 10,1));
            graph.Edges.Add(new Edge(graph.Nodes.ElementAtOrDefault(1), graph.Nodes.ElementAtOrDefault(3),34,2));
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
