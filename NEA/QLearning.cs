using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace NEA
{
    public static class QLearning//TODO: this could be considered the brain of the agent and it would therefore make sense to call it such
    {
        public static Graph graph;
        public static int[,] RMatrix;
        public static int[,] QMatrix;
        public static int TargetID;
        public static int TargetReward = Int32.Parse(ConfigurationManager.AppSettings["TargetReward"]);
        public const int NullRValue = 0;//change this to a more modular solution?
        public static float LearningRate = float.Parse(ConfigurationManager.AppSettings["BaseLearningRate"]);
        public static void InitialiseRMatrix()
        {
            TargetID = graph.Target.ID;

            RMatrix = new int[graph.Nodes.Count , graph.Nodes.Count];//TODO: run proper tests to see if it should be count or count -1
            for (int s = 0; s < RMatrix.GetLength(0); s++)//TODO: maybe refactor this
            {

                for (int a = 0; a < RMatrix.GetLength(0); a++)
                {
                    RMatrix[s, a] = NullRValue;
                }
            }
            foreach (Edge e in graph.Edges)
            {
                RMatrix[e.To.ID, e.From.ID] = -e.Weight;
                RMatrix[e.From.ID, e.To.ID] = -e.Weight;
            }
            for (int s = 0; s < RMatrix.GetLength(0); s++)//TODO: definitely maybe refactor this
            {
                if (RMatrix[s, TargetID] != NullRValue)
                {
                    RMatrix[s, TargetID] = TargetReward;
                }
            }
        }

        public static void InitialiseQMatrix()
        {
            QMatrix = new int[graph.Nodes.Count, graph.Nodes.Count];
            for (int i = 0; i < QMatrix.GetLength(0); i++)
            {
                for (int e = 0; e < QMatrix.GetLength(1); e++)
                {
                    QMatrix[i, e] = 0;//TODO: see if this works with the null value of the RMatrix being zero also
                }
            }

        }
    }
}
