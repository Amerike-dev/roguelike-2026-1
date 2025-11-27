using UnityEngine;

public class CoinDrop:MonoBehaviour
{
    public Poolmanager poolManager;

    public int minDrops = 2;
    public int maxDrops = 20;

    public GameObject cDrops;

    public CoinDrop(GameObject cDrops)
    {
        this.cDrops = cDrops;
    }

    public void GenerateDrops()
    {

        int amount = Random.Range(minDrops, maxDrops + 1);

        for (int i = 0; i < amount; i++)
        {
            GameObject drop = poolManager.GetFromPool();
            drop.SetActive(true);

            Vector3 offset = new Vector3(
                Random.Range(-0.5f, 0.5f),
                Random.Range(-0.5f, 0.5f),
                0f
            );
            drop.transform.position = cDrops.transform.position + offset;
        }
    }
}
