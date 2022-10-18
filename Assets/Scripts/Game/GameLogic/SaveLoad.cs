using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
    public static void SaveDeckData(DeckData deckData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tinyPocketDungeon";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, deckData);
        stream.Close();
    }

    public static DeckData LoadDeckData()
    {
        string path = Application.persistentDataPath + "/tinyPocketDungeon";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DeckData data = formatter.Deserialize(stream) as DeckData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Error: Save file not found in " + path);
            return null;
        }
    }
}
