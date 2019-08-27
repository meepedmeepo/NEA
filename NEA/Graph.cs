using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace NEA
{
    [Serializable]
    public class Graph : ISerializable
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
        public Node Target { get; set; }//Change this to an int id for a node?
        public Party Characters { get; set; }//TODO: maybe change the name of this property?
        //TODO: maybe remove this from the graph as it could be seen as not appropriate for an agent to be part of the world in a model free approach to machine learning.
        
        public List<Edge> MoveOptions(int currentNodeID)//move this to a helper method or other more suitable place?
        {
            return this.Edges.FindAll(x => x.From.ID == currentNodeID).ToList();
        }
        public Graph()
        {
            this.Nodes = new List<Node>();
            this.Edges = new List<Edge>();
            
        }
        public Graph(SerializationInfo info, StreamingContext context)
        {
            this.Nodes = (List<Node>)info.GetValue("Nodes", typeof(List<Node>));
            this.Edges = (List<Edge>)info.GetValue("Edges", typeof(List<Edge>));
            this.Target = (Node)info.GetValue("Target", typeof(Node));
            this.Characters = (Party)info.GetValue("Party", typeof(Party));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Nodes", this.Nodes);
            info.AddValue("Edges", this.Edges);
            info.AddValue("Target", this.Target);
            info.AddValue("Party", this.Characters);
            
        }
    }
}
