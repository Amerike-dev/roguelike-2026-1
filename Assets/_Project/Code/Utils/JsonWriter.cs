using UnityEngine;
using System.IO;

public class JsonWriter
{
    public void RewriteJson(string path, SavedGameData save)
    {
        string jsonPath;
        jsonPath = Path.Combine(Application.streamingAssetsPath + path);

        string json = JsonUtility.ToJson(save, true);

        File.WriteAllText(jsonPath, json);
    }
}
