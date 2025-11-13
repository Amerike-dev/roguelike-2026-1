using UnityEngine;

public class Death
{
    private GameObject _enemy;

    public Death(GameObject enemy)
    {
        this._enemy = enemy;
    }
    public void Die()
    {
        _enemy.SetActive(false);
    }
    public void DropItems()
    {

    }
}
