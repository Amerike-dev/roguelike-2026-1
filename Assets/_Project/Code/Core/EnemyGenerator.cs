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

    public void GenerateEnemies(int id, Grid grid, string path, List<Sprite> sprites, int[] positions, List<GameObject> enemiesPrefabs, Transform playerTransform)
    {
        //Crear enemigo
        GameObject enemyprefab = enemiesPrefabs[id];
        GameObject enemy = GameObject.Instantiate(enemyprefab);

        //Leer Json
        SpriteRenderer spriteRenderer = enemy.GetComponent<SpriteRenderer>();

        JsonReader jsonReader = new JsonReader();

        ListEnemyData data = jsonReader.ReadEnemies(path);

        //Encontrar enemigo en Json
        var foundEnemy = data.enemies.FirstOrDefault(e => e.id == id);
        if (foundEnemy != null)
        {
            //Cambiar nombre
            enemy.name = foundEnemy.name;
        }

        //Cambiar Sprite
        spriteRenderer.sprite = sprites[id];

        //Setear al jugador como objetivo
        EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        enemyBehaviour.target = playerTransform;

        //Se acomoda al enemigo dentro del grid y se ajusta su escala
        Vector3Int enemyPos = new Vector3Int(positions[0], positions[1]);
        Vector3 worldPosition = grid.CellToWorld(enemyPos);
        enemy.transform.position = worldPosition;
        enemy.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

}
