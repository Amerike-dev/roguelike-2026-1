using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator
{
    public List<Sprite> enemiesSprites;

    public EnemyGenerator(List<Sprite> sprites)
    {
        enemiesSprites = sprites;
    }

    public void GenerateEnemies(int id, Grid grid, string path, List<Sprite> sprites, int[] positions)
    {
        GameObject enemy = new GameObject();
        SpriteRenderer spriteRenderer = enemy.AddComponent<SpriteRenderer>();

        JsonReader jsonReader = new JsonReader();

        ListEnemyData data = jsonReader.ReadEnemies(path);

        var foundEnemy = data.enemies.FirstOrDefault(e => e.id == id);
        if (foundEnemy != null)
        {
            enemy.name = foundEnemy.name;
            
        }
        spriteRenderer.sprite = sprites[id];

        Vector3Int enemyPos = new Vector3Int(positions[0], positions[1]);
        Vector3 worldPosition = grid.CellToWorld(enemyPos);
        enemy.transform.position = worldPosition;
        enemy.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

}
