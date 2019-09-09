using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace NEA
{
    [Serializable]
    public class CombatEncounter : Encounter,ISerializable
    {
        public List<Character> Enemies { get; set; }

        public override void RunEncounter()//TODO: Complete
        {
            Party party = Program.graph.Characters;
            bool isFinished = false;
            while (!isFinished)
            {
                foreach (Character c in party.Characters)
                {

                }
                foreach (Character e in this.Enemies)
                {

                }
            }
        }
        public CombatEncounter(int Reward,List<Character> Enemies) : base(Reward)
        {
            this.Enemies = Enemies;
        }
        public CombatEncounter(int Reward) : base(Reward)
        {
            this.Enemies = new List<Character>();
        }
        public CombatEncounter(SerializationInfo info, StreamingContext context)
        {
            this.Reward = (int)info.GetValue("Reward", typeof(int));
            this.Enemies = (List<Character>)info.GetValue("Enemies", typeof(List<Character>));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Enemies", this.Enemies);
            base.GetObjectData( info, context);


        }
        public void KillCharacter()//TODO: Complete this
        {

        }
    }
}
