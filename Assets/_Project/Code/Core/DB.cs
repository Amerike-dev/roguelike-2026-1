using System.IO;
using UnityEngine;

public enum playerData
{
    name
}


public class DB
{

    [SerializeField] private string _jsonString;
    private PlayerData _playerData;
    private string _location;
    
    
    public DB(string jsonLocation)
    {
        _location = jsonLocation;
        _jsonString = File.ReadAllText(_location);
        _playerData = JsonUtility.FromJson<PlayerData>(_jsonString);
  
    }

    public void Write(playerData key, string value = "value")
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
    public void Save()
    {
        File.WriteAllText(_location, JsonUtility.ToJson(_playerData));
    }


    public void Delete()
    {
        File.Delete(_location);
    }
}
