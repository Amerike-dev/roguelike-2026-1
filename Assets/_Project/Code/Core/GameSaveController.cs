using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveController : MonoBehaviour
{
    public Button newRun;
    public Button contRun;
    public string filePath;
    public SavedGameData gameData;
    private JsonReader _reader;
    private JsonWriter _writer;

    void Awake()
    {
        _reader = new JsonReader();
        gameData = _reader.ReadGame(filePath);

        if (gameData.game.started == string.Empty)
        {
            gameData.game.started = DateTime.Now.ToString();
            NewRun();
        }
        else
        {
            contRun.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    public void NewRun()
    {
        _writer = new JsonWriter();
        _writer.RewriteJson(filePath, gameData);
    }
}
