using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace NEA
{
    [Serializable]
    public class Party : ISerializable//TODO change the name of party to agent as it will become the machine learning agent?
    {
        public List<Character> Characters { get; set; }
        public Node CurrentNode { get; set; }

        public Party(List<Character> Characters)
        {
            this.Characters = Characters;
        }
        public Party()
        {
            this.Characters = new List<Character>();
        }

        public Party (SerializationInfo info, StreamingContext context)
        {
            this.CurrentNode = (Node)info.GetValue("CurrentNode", typeof(Node));
            this.Characters = (List<Character>)info.GetValue("Characters", typeof(List<Character>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CurrentNode", this.CurrentNode);
            info.AddValue("Characters", this.Characters);

        }
    }
}
