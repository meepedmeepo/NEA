using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    class Edge
    {
        Node From { get; set; }
        Node To { get; set; }
        float Weight { get; set; }
        public Edge(Node From, Node To,float Weight)
        {
            this.From = From;
            this.To = To;
            this.Weight = Weight;
        }
        public string ReturnFormattedData()//TODO: remove this temporary solution (maybe make a generic helper method that uses reflection name space to display all fields for any class)
        {

            return "From " + this.From.ReturnFormattedData() + " TO " + this.To.ReturnFormattedData() + " Weight " + this.Weight.ToString();
        }
    }
}
