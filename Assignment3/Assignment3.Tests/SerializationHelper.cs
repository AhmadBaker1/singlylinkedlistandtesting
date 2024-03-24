using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment3.Utility
{
    public static class SerializationHelper
    {
        public static void Serialize<T>(SLL<T> data, string fileName)
        {
            using (FileStream stream = File.Create(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
            }
        }

        public static SLL<T> Deserialize<T>(string fileName)
        {
            using (FileStream stream = File.OpenRead(fileName))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (SLL<T>)formatter.Deserialize(stream);
            }
        }
    }
}
