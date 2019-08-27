using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace NEA
{
    public static class XmlHandler
    {
        public static void SerializeGeneric<T>(T ObjToSerialize, string path)
        {
            using (Stream fs = new FileStream(@path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, ObjToSerialize);
            }
        }

        public static T DeserializeGeneric<T>(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            object obj = null;
            using (FileStream fs = File.OpenRead(@path))
            {
                obj = (T)deserializer.Deserialize(fs);
            }
            T objToDeserialize = (T)obj;
            return objToDeserialize;
        }
    }
}
