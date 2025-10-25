using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class DBController : MonoBehaviour
{
    public string jsonLocation; 
    public DB db;
    public TMP_InputField playerName;
    public TextMeshProUGUI nameDisplay;
    public Button saveButton;
    
    private void Awake()
    {
        db = new DB(jsonLocation);
    }

    private void Start()
    {
        playerName.onValueChanged.AddListener(ChangeName);
        nameDisplay.text = "name: " + db.Read(playerData.name);
    }

    public void ChangeName(string name)
    {
        db.Write(playerData.name, name);
        nameDisplay.text = "name: " + db.Read(playerData.name);
    }

    public void SaveName()
    {
        db.Save();
    }

}
