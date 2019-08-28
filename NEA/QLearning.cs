using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public static class QLearning//TODO: this could be considered the brain of the agent and it would therefore make sense to call it such
    {
        public static Graph graph;
        public static int[,] RMatrix;
        public static int[,] QMatrix;
        public static int TargetID;
        public static int TargetReward = 400;//Maybe make this modular and/or balance this
        public const int NullRValue = 0;//change this to a more modular solution?
        public static void InitialiseRMatrix()
        {
            TargetID = graph.Target.ID;

            RMatrix = new int[graph.Nodes.Count - 1, graph.Nodes.Count - 1];
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
    }
}
