using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

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
                data = bf.Deserialize(fs);
                fs.Close();
            }
            return data;
        }

        public void SerializeJSON(BasicData data, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllTextAsync(filePath, jsonString);
        }

        public object DeserializeJSON(string filePath)
        {
            BasicData dataReturn = null;

            if (File.Exists(filePath))
            {
                string str = ReadChars(filePath, 4);
                if (!str.StartsWith("null"))
                {
                    string jsonString = File.ReadAllText(filePath);
                    dataReturn = JsonSerializer.Deserialize<BasicData>(jsonString);
                }
            }
            return dataReturn;
        }
        public static string ReadChars(string filename, int count)
        {
            using (var stream = File.OpenRead(filename))
            using (var reader = new StreamReader(stream))
            {
                char[] buffer = new char[count];
                int n = reader.ReadBlock(buffer, 0, count);

                char[] result = new char[n];

                Array.Copy(buffer, result, n);

                string str = "";
                foreach (char c in result)
                {
                    str.Append(c);
                }
                return str;
            }
        }
    }
}
