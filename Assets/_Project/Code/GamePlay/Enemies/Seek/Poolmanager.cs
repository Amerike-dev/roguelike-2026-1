using UnityEngine;
using System.Collections.Generic;

public class Poolmanager : MonoBehaviour
{
    public static Poolmanager Instance;
    public GameObject prefab;
    public int poolSize = 30;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        Instance = this;
        CreatPool();
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
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
