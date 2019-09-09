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
   public class Node : IContainsID,ISerializable//TODO: add encounters to this class.
    {
        public string Name { get; set; }
        public int ID { get; set; }//NODE IDS MUST START FROM ZERO ELSE Q LEARNING WON'T WORK!
        public Encounter NodeEncounter { get; set; }//TODO: choose a more suitable name for this
        public Node(int ID,string Name,Encounter NodeEncounter)
        {
            this.ID = ID;
            this.Name = Name;
            this.NodeEncounter = NodeEncounter;
        }
        public Node()
        { }
        public Node(SerializationInfo info, StreamingContext context)
        {
          
            this.ID = (int)info.GetValue("ID", typeof(int));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.NodeEncounter = (Encounter)info.GetValue("NodeEncounter", typeof(Encounter));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", this.ID);
            info.AddValue("Name", this.Name);
            info.AddValue("NodeEncounter", this.NodeEncounter);
            
        }
        public string ReturnFormattedData()//TODO: remove this temporary solution (maybe make a generic helper method that uses reflection name space to display all fields for any class)
        {

            return "Name: " + this.Name + " ID: " + this.ID.ToString();
        }
    }
}
