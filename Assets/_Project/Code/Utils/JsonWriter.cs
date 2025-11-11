using UnityEngine;
using System.IO;

public class JsonWriter
{
    public void RewriteJson(string path, SavedGameData save)
    {
        string jsonPath = Path.Combine(Application.persistentDataPath, path);

        string json = JsonUtility.ToJson(save, true);
        Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));

        File.WriteAllText(jsonPath, json);
    }
}
