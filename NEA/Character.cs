using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace NEA
{
    [Serializable]
    public class Character :  ISerializable
    {
        public int AC { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int AtkBonus { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int DmgBonus { get; set; }

        public Character(int AC, int HP, int AtkBonus, int MinDmg,int MaxDmg, int DmgBonus)
        {
            this.AC = AC;
            this.MaxHP = HP;
            this.CurrentHP = HP;
            this.AtkBonus = AtkBonus;
            this.MinDmg = MinDmg;
            this.MaxDmg = MaxDmg;
            this.DmgBonus = DmgBonus;
        }
        public Character()
        {
        }
       public Character(SerializationInfo info, StreamingContext context)
        {
            this.AC = (int)info.GetValue("AC", typeof(int));
            this.MaxHP = (int)info.GetValue("MaxHP", typeof(int));
            this.CurrentHP = (int)info.GetValue("CurrentHP", typeof(int));
            this.AtkBonus = (int)info.GetValue("AtkBonus", typeof(int));
            this.MinDmg  = (int)info.GetValue("MinDmg", typeof(int));
            this.MaxDmg = (int)info.GetValue("MaxDmg", typeof(int));
            this.DmgBonus = (int)info.GetValue("DmgBonus", typeof(int));

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AC", this.AC);
            info.AddValue("MaxHP", this.MaxHP);
            info.AddValue("CurrentHP", this.CurrentHP);
            info.AddValue("AtkBonus", this.AtkBonus);
            info.AddValue("MinDmg", this.MinDmg);
            info.AddValue("MaxDmg", this.MaxDmg);
            info.AddValue("DmgBonus", this.DmgBonus);

        }

    }
}
