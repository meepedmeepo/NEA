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
        

        public override int RunEncounter()//TODO: Complete
        {
            Random rand = new Random();
            bool finished = false;
            while (!finished)
            {
                Enemies = CombatRound(Program.graph.Characters.Characters, Enemies, rand);
                Program.graph.Characters.Characters= CombatRound(Enemies, Program.graph.Characters.Characters, rand);//TODO: change all of the Program.graph.Characters.Character by sorting out a reference.
                if (Enemies.Count() == 0)
                {
                    return this.Reward;
                }
                else if (Program.graph.Characters.Characters.Count() == 0)
                {
                    finished = true;
                }

            }
            return QLearning.FailureReward;//TODO: add the state transition properly
        }
        public List<Character> CombatRound(List<Character> attackers, List<Character> enemies, Random rand)
        {
            for (int p = 0; p < attackers.Count(); p++)//TODO: turn this into a seperate functions???
            {
                int target = rand.Next(0, enemies.Count());
                int atk = rand.Next(0, 21);
                if (atk + attackers[p].AtkBonus >= enemies[target].AC)
                {
                    enemies[target].CurrentHP -= rand.Next(attackers[p].MinDmg, attackers[p].MaxDmg + 1);
                    if (enemies[target].CurrentHP <= 0)
                    {
                        enemies.RemoveAt(target);
                    }
                }
            }

            return enemies;
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
