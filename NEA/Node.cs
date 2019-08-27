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
    class Node : IContainsID,ISerializable
    {
        string Name { get; set; }
        public int ID { get; set; }

        public Node(int ID,string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public Node()
        { }
        public Node(SerializationInfo info, StreamingContext context)
        {
          
            this.ID = (int)info.GetValue("ID", typeof(int));
            this.Name = (string)info.GetValue("Name", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", this.ID);
            info.AddValue("Name", this.Name);
            
        }
        public string ReturnFormattedData()//TODO: remove this temporary solution (maybe make a generic helper method that uses reflection name space to display all fields for any class)
        {

            return "Name: " + this.Name + " ID: " + this.ID.ToString();
        }
    }
}
