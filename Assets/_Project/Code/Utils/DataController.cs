using UnityEngine;

public class DataController : MonoBehaviour
{
    public string path;

    JsonReader reader;

    private void Start()
    {
        reader = new JsonReader();

        reader.ReadMap(path);
    }
}
