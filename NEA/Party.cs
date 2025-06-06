﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace NEA
{
    [Serializable]
    public class Party : ISerializable//TODO: change the name of party to agent as it will become the machine learning agent?
    {
        public List<Character> Characters { get; set; }
        public Node CurrentNode { get; set; }
        List<Step> MoveList { get; set; }//TODO: sort out this class and possibly remove most of it or merge it with q learning class
        public Party(List<Character> Characters)
        {
            this.Characters = Characters;
            this.MoveList = new List<Step>();
        }
        public Party()
        {
            this.Characters = new List<Character>();
            this.MoveList = new List<Step>();
        }

        public Party (SerializationInfo info, StreamingContext context)
        {
            this.CurrentNode = (Node)info.GetValue("CurrentNode", typeof(Node));
            this.Characters = (List<Character>)info.GetValue("Characters", typeof(List<Character>));
            this.MoveList = new List<Step>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CurrentNode", this.CurrentNode);
            info.AddValue("Characters", this.Characters);

        }
        public void Move(Edge edge)//TODO: remove this unused code???
        {
            this.MoveList.Add(new Step(edge, 0));

        }
        public int GetMissingHealth()
        {
            int totalMissing = 0;
            foreach (Character c in Characters)
            {
                totalMissing += (c.MaxHP - c.CurrentHP);
            }
            return totalMissing;
        }

    }
}
