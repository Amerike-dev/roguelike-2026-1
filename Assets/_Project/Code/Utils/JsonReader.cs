using UnityEngine;
using System.IO;

public class JsonReader
{
    public DungeonData ReadMap(string path)
    {
        string jsonPath;
        jsonPath = Path.Combine(Application.streamingAssetsPath + path);
        string json = File.ReadAllText(jsonPath);


        DungeonData data = JsonUtility.FromJson<DungeonData>(json);
        return data;
    }

    public SavedGameData ReadGame(string path)
    {
        string jsonPath;
        jsonPath = Path.Combine(Application.streamingAssetsPath + path);
        string json = File.ReadAllText(jsonPath);

        SavedGameData data = JsonUtility.FromJson<SavedGameData>(json);

        return data;
    }
}
