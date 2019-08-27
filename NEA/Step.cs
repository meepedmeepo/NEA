using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public enum Type { Move, Encounter };

public class Step//TODO: consider changing the name of this to something that makes more sense (can't be action due to delegates reserving that keyword) 
    {//TODO: maybe change this whole system as it is unclear whether or not it will work with q learning - maybe use steps to create the R matrix automatically?
        //TODO: Encounter might have to be forced in order for the q learning algorithm to be viable to implement without too much extra complication
        //TODO: Accord might not actually be needed for q learning so possibly remove it if it is unecessary
        public Type type { get; set; }
        Edge Move { get; set; }
        Encounter Encounter { get; set; }
    
    }
}