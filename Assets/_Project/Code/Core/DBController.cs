using UnityEngine;
using UnityEngine.Windows;

public class DBController : MonoBehaviour
{
    public string jsonLocation; 
    public DB db;

    private void Awake()
    {
        db = new DB(jsonLocation);
    }


}
