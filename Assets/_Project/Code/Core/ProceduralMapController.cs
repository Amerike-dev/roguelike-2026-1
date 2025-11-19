using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralMapController : MonoBehaviour
{
    public Transform playerTransform;

    public string filePath;
    public string enemiesPath;
    public DungeonData dungeonData;
    private JsonReader _reader;

    public Tile[] tiles;
    public List<Sprite> enemiesSprites;

    public List<GameObject> enemiesPrefabs;
    private void Awake()
    {
        _reader = new JsonReader();
        dungeonData = _reader.ReadMap(filePath);
    }

    void Start()
    {
        GameObject grid = new GameObject();
        grid.name = "Grid";

        grid.AddComponent<Grid>();

        Grid gridComponent = grid.GetComponent<Grid>();
        gridComponent.cellLayout = GridLayout.CellLayout.Isometric;
        gridComponent.cellSize = new Vector3(0.32f, 0.16f, 0.32f);

        GameObject tileMap = new GameObject();
        tileMap.name = "Tile Map";

        tileMap.AddComponent<Tilemap>();
        tileMap.AddComponent<TilemapRenderer>();

        tileMap.AddComponent<CompositeCollider2D>();
        tileMap.AddComponent<TilemapCollider2D>();
        tileMap.AddComponent<Rigidbody2D>();

        TilemapRenderer tilemapRenderer = tileMap.GetComponent<TilemapRenderer>();
        tilemapRenderer.sortOrder = TilemapRenderer.SortOrder.TopRight;

        Tilemap tilemap = tileMap.GetComponent<Tilemap>();

        CompositeCollider2D compositeCollider2D = tileMap.GetComponent<CompositeCollider2D>();

        TilemapCollider2D tilemapCollider2D = tileMap.GetComponent<TilemapCollider2D>();

        Rigidbody2D rigidbody2D = tileMap.GetComponent<Rigidbody2D>();

        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        tilemapCollider2D.compositeOperation = TilemapCollider2D.CompositeOperation.Flip;

        tileMap.transform.parent = grid.transform;

        //Map Generation
        MapData mapData = dungeonData.dungeons[0];

        Map map = new Map(Vector2Int.zero, new Vector2Int(mapData.size[0], mapData.size[1]), tilemap);
        List<Vector3Int> coordinates = map.GenerateCoordinates();
        map.Render(tiles[0], coordinates);

        foreach (DecorationData decoration in mapData.decorations)
        {
            foreach(LocationData location in decoration.locations)
            {
                PlaceNewTiles(location, new Vector3Int(location.positions[0], location.positions[1]), tiles[decoration.type], tilemap);
            }
        }

        EnemyGenerator enemyGenerator = new EnemyGenerator(enemiesSprites);

        foreach (EnemyData enemyData in mapData.enemies)
        {
            enemyGenerator.GenerateEnemies(enemyData.enemyType, gridComponent, enemiesPath ,enemiesSprites, enemyData.position, enemiesPrefabs, playerTransform);

        }

    }

    void PlaceNewTiles(LocationData location, Vector3Int coordinates, Tile tile, Tilemap tilemap)
    {

        switch(location.type)
        {
            case 0:

                for (int x = location.positions[0]; x < location.size + location.positions[0]; x++)
                {
                    for (int y = location.positions[1]; y < location.size + location.positions[1]; y++)
                    {
                        tilemap.SetTile(new Vector3Int(x, y), tile);
                    }
                }
                break;

            case 1:

                for (int x = location.positions[0]; x < location.size + location.positions[0]; x++)
                {
                    tilemap.SetTile(new Vector3Int(x, location.positions[1]), tile);
                }
                break;

            case 2:

                for (int y = location.positions[1]; y < location.size + location.positions[1]; y++)
                {
                    tilemap.SetTile(new Vector3Int(location.positions[0], y), tile);
                }
                break;
        }

        
    }
}
