using UnityEngine;
using System.Collections.Generic;

public class Poolmanager : MonoBehaviour
{
    public static Poolmanager Instance { get; private set; }
    public GameObject prefab;
    public int poolSize = 50;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }
    public void CreatPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject GetFromPool()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }
}
