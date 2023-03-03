using System.Runtime.Serialization.Formatters.Binary;

namespace LOS
{
    class Serializer
    {
        public void SerializeBin(object data, string filePath)
        {
            FileStream fs;
            BinaryFormatter bf = new BinaryFormatter();
            fs = File.Create(filePath);
            bf.Serialize(fs, data);
            fs.Close();
        }

        public object DeserializeBin(string filePath)
        {
            object data = null;
            FileStream fs;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fs = File.OpenRead(filePath);
                data = (List<PositionData>) bf.Deserialize(fs);
                fs.Close();
            }
            return data;
        }
    }
}
