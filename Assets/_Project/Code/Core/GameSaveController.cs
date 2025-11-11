using System;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveController : MonoBehaviour
{
    public Button newRun;
    public Button contRun;
    public Button option;
    public Button credits;
    public SavedGameData gameData;
    private JsonReader _reader;
    private JsonWriter _writer;
    
    private const string CurrentGameFileName = "current_game.json";
    private const string BackupGameFileName = "backup_game.json";

    private SavedGameData GetDefaultGameData()
    {
        return new SavedGameData
        {
            game = new GameData
            {
                started = DateTime.Now.ToString(),
                routes = new RouteData[] 
                {
                    new RouteData { name = "starting", status = "not finished", discoveries = new DiscoveriesData[0] }
                }
            }
        };
    }
    
    void Awake()
    {
        Debug.Log("La ruta de Persistent Data es: " + Application.persistentDataPath);
        _reader = new JsonReader();
        gameData = _reader.ReadGame(CurrentGameFileName);
        
        if (gameData.game == null)
        {
            Debug.Log("No se encontró partida guardada, creando archivo");
            gameData = GetDefaultGameData();
            
            _writer = new JsonWriter();
            _writer.RewriteJson(CurrentGameFileName, gameData);
            
            contRun.gameObject.SetActive(false); 
        }
        else
        {
            Debug.Log("Si se encontro partida guardada, boton encendido");
            contRun.gameObject.SetActive(true);
        }
        
        ConfigureMenuNavigation();
        newRun.onClick.RemoveAllListeners();
        newRun.onClick.AddListener(NewRun);
    }


    public void NewRun()
    {
        string currentPath = CurrentGameFileName;
        string backupPath = BackupGameFileName;
        
        string fullCurrentPath = Path.Combine(Application.persistentDataPath, currentPath);
        string fullBackupPath = Path.Combine(Application.persistentDataPath, backupPath);
        
        if (File.Exists(fullCurrentPath))
        {
            if (File.Exists(fullBackupPath)) File.Delete(fullBackupPath);
            
            File.Move(fullCurrentPath, fullBackupPath);
        }
        
        gameData = GetDefaultGameData();
        _writer = new JsonWriter();
        _writer.RewriteJson(currentPath, gameData);
    }
    
    private void ConfigureMenuNavigation()
{
    Navigation navNewRun = newRun.navigation;
    navNewRun.mode = Navigation.Mode.Explicit;
    navNewRun.selectOnUp = credits;
    navNewRun.selectOnDown = contRun; 
    newRun.navigation = navNewRun;
    
    Navigation navContRun = contRun.navigation;
    navContRun.mode = Navigation.Mode.Explicit;
    navContRun.selectOnUp = newRun;
    navContRun.selectOnDown = option;
    contRun.navigation = navContRun;
    
    Navigation navOption = option.navigation;
    navOption.mode = Navigation.Mode.Explicit;
    navOption.selectOnUp = contRun;
    navOption.selectOnDown = credits;
    option.navigation = navOption;
    
    Navigation navCredits = credits.navigation;
    navCredits.mode = Navigation.Mode.Explicit;
    navCredits.selectOnUp = option;
    navCredits.selectOnDown = newRun;
    credits.navigation = navCredits;
    
    if (!contRun.gameObject.activeSelf)
    {
        Navigation navNewRunAdjusted = newRun.navigation;
        navNewRunAdjusted.selectOnDown = option;
        newRun.navigation = navNewRunAdjusted;
        
        Navigation navOptionAdjusted = option.navigation;
        navOptionAdjusted.selectOnUp = newRun;
        option.navigation = navOptionAdjusted;
    }
}
}
