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
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();

        }
     }
}
