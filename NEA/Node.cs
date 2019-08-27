using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    class Node : IContainsID
    {
        string Name { get; set; }
        public int ID { get; set; }

        public Node(int ID,string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public string ReturnFormattedData()//TODO: remove this temporary solution (maybe make a generic helper method that uses reflection name space to display all fields for any class)
        {

            return "Name: " + this.Name + " ID: " + this.ID.ToString();
        }
    }
}
