using System.IO;
using UnityEngine;

public enum playerData
{
    name
}
public class DB 
{

    private TextAsset _jsonFilePlayer;
    private PlayerData _playerData;
    
    
    public DB(TextAsset _playerJson)
    {
        _jsonFilePlayer = _playerJson;
        string _jsonString = _jsonFilePlayer.text;
        _playerData = JsonUtility.FromJson<PlayerData>( _jsonString );
    }

    public void Write(playerData key, string value)
    {
        switch (key)
        {
            case playerData.name:
            {
                _playerData.name = value;
                return;
            }
        }
    }

    public string Read(playerData key)
    {
        string data = key switch
        {
            playerData.name => _playerData.name,
            _ => null
        };
        return data;
    }
    public void Update()
    {
        
    }


    public void Delete()
    {
        
    }
}
