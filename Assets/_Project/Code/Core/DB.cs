using UnityEngine;

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
    public void Write()
    {

    }
    public void Read() 
    {
        
    }
    public void Update()
    {

    }

    public void Delete()
    {

    }
}
