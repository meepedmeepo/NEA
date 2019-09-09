using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace NEA
{
    [Serializable]
    public abstract class Encounter : ISerializable
    {
        public int Reward { get; set; }
        public Encounter(int Reward)
        {
            this.Reward = Reward;
        }

        public virtual int RunEncounter()
        {
            return 0;
        }
        public Encounter(SerializationInfo info, StreamingContext context)
        {
            this.Reward = (int)info.GetValue("Reward", typeof(int));
            
        }
        public Encounter()
        { }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Reward", this.Reward);
         
        }
    }
}
