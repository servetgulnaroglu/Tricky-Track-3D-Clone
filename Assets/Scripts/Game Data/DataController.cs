using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataController
{
    public static void SaveData(Data data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + ConstantValues.DATA_PATH;
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/" + ConstantValues.DATA_PATH;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();
            return data;
        }
        else
        {
            Data data = new Data();
            SaveData(data);
            return null;
        }
    }
}
