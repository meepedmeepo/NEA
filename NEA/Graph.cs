using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
        public Node Target { get; set; }//Change this to an int id for a node?
        public List<Edge> MoveOptions(int currentNodeID)//move this to a helper method or other more suitable place?
        {
            return this.Edges.FindAll(x => x.From.ID == currentNodeID).ToList();
        }
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();

        }
     }
}
