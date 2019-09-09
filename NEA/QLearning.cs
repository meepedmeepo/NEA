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
        public static int FailureReward = Int32.Parse(ConfigurationManager.AppSettings["FailureReward"]);
        public const int NullRValue = 0;//change this to a more modular solution?
        public static float LearningRate = float.Parse(ConfigurationManager.AppSettings["BaseLearningRate"]);
        public static string Path = ConfigurationManager.AppSettings["Path"];
        public static Random RandGen = new Random();
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
                    QMatrix[i, e] = 0;//TODO: see if this works with the null value of the RMatrix being zero also see if this is the correct approach to the qmatrix
                }
            }

        }

        public static void QTransition(int State, int Action)
        {
            QMatrix[State, Action] = (int)(RMatrix[State, Action] + graph.Characters.CurrentNode.NodeEncounter.RunEncounter() + LearningRate * GetHighestQReward(State));//TODO: Check to see if this does what it should do with encounterreward
        }
        public static int GetHighestQReward(int State)
        {
            int currentHighest = int.MinValue;
            for (int Action = 0; Action < QMatrix.GetLength(1); Action++)
            {
                if (QMatrix[State,Action] > currentHighest)
                {
                    currentHighest = QMatrix[State, Action];
                }
            }

            return currentHighest;
        }
        public static void TrainQMatrix(int maxEpochs,bool firstTraining,Party party)
        {
            if (firstTraining)
            {
                InitialiseRMatrix();
                InitialiseQMatrix();
                for (int e = 0; e < maxEpochs; e++)
                {
                    int state = RandGen.Next(0, graph.Nodes.Count);
                    while (party.CurrentNode.ID != TargetID && graph.Characters.Characters.Count() > 0)
                    {
                        int action = RandGen.Next(0, graph.Edges.Count());
                        QTransition(state, action);
                        state = HelperFunctions.SearchById<Edge>(graph.Edges, action).To.ID;//TODO: Test this fully to see if it actually selects the corrects ids for both edge and the node.
                    }
                }
                XmlHandler.SerializeGeneric<int[,]>(QMatrix, Path);
            }
        }
    }
}
