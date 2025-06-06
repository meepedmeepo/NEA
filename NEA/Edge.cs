﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace NEA
{
    [Serializable]
    public class Edge : IContainsID,ISerializable//TODO: possibly add encounnters to this class
    {
        public Node From { get; set; }
        public Node To { get; set; }
        public int Weight { get; set; }
        public int ID  {get; set; }
        public Edge(Node From, Node To,int Weight,int ID)
        {
            this.From = From;
            this.To = To;
            this.Weight = Weight;
            this.ID = ID;
        }
        public Edge()
        { }
        public Edge(SerializationInfo info, StreamingContext context)
        {
            this.From = (Node)info.GetValue("From", typeof(Node));
            this.To = (Node)info.GetValue("To", typeof(Node));
            this.ID = (int)info.GetValue("ID", typeof(int));
            this.Weight = (int)info.GetValue("Weight",typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("From", this.From);
            info.AddValue("To", this.To);
            info.AddValue("ID", this.ID);
            info.AddValue("Weight", this.Weight);
        }
        public string ReturnFormattedData()//TODO: remove this temporary solution (maybe make a generic helper method that uses reflection name space to display all fields for any class)
        {

            return "From " + this.From.ReturnFormattedData() + " TO " + this.To.ReturnFormattedData() + " Weight " + this.Weight.ToString();
        }
    }
}
