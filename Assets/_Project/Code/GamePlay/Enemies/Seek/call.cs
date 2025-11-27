using UnityEngine;

public class call : MonoBehaviour
{
    public void FixedUpdate()
    {
        spawn();
    }
    public void spawn()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Poolmanager.Instance.GetFromPool();
        }
    }
}
