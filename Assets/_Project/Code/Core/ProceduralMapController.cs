using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;


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

    List<MapData> sequence = new List<MapData>();

    public int totalRooms;
    public bool shopAppeared = false;
    public float normalRate = 0.5f;
    public float shopRate = 0.5f;
    
    private void Awake()
    {
        _reader = new JsonReader();
        dungeonData = _reader.ReadMap(filePath);
    }

    void Start()
    {
        totalRooms = Random.Range(6, 9);

        GenerateMapSequence(dungeonData.dungeons.ToList());

        Debug.Log("Sequence: [" + string.Join(", ", sequence.Select(m => m.type)) + "]");
        
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

        TilemapRenderer tilemapRenderer = tileMap.GetComponent<TilemapRenderer>();
        tilemapRenderer.sortOrder = TilemapRenderer.SortOrder.TopRight;

        tileMap.transform.parent = grid.transform;

        Tilemap tilemap = tileMap.GetComponent<Tilemap>();

        //Map Generation
        MapData mapData = dungeonData.dungeons[0];

        Map map = new Map(Vector2Int.zero, new Vector2Int(mapData.size[0], mapData.size[1]), tilemap);
        List<Vector3Int> coordinates = map.GenerateCoordinates();
        map.Render(tiles[0], coordinates);

        foreach (DecorationData decoration in mapData.decorations)
        {
            foreach (LocationData location in decoration.locations)
            {
                PlaceNewTiles(location, new Vector3Int(location.positions[0], location.positions[1]),
                    tiles[decoration.type], tilemap);
            }
        }

        EnemyGenerator enemyGenerator = new EnemyGenerator(enemiesSprites);

        foreach (EnemyData enemyData in mapData.enemies)
        {
            enemyGenerator.GenerateEnemies(enemyData.enemyType, gridComponent, enemiesPath, enemiesSprites,
                enemyData.position, enemiesPrefabs, playerTransform);

        }

    }

    void PlaceNewTiles(LocationData location, Vector3Int coordinates, Tile tile, Tilemap tilemap)
    {

        switch (location.type)
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
    
    private List<MapData> GenerateMapSequence(List<MapData> allMaps)
    {
        sequence.Clear();
        shopAppeared = false;
        
        MapData firstNormal = allMaps.Find(m => m.type == "normal");
        sequence.Add(firstNormal);
        
        for (int i = 1; i < totalRooms - 1; i++)
        {
            float rate = Random.value;
            MapData mapToAdd = null;

            if (!shopAppeared && rate < shopRate)
            {
                mapToAdd = allMaps.Find(m => m.type == "shop");
                shopAppeared = true;
            }
            else
            {
                mapToAdd = allMaps.Find(m => m.type == "normal");
            }

            sequence.Add(mapToAdd);
        }
        
        if (!shopAppeared)
        {
            int randomIndex = Random.Range(1, totalRooms - 1);
            sequence[randomIndex] = allMaps.Find(m => m.type == "shop");
            shopAppeared = true;
        }
        
        MapData boss = allMaps.Find(m => m.type == "boss");
        sequence.Add(boss);

        return sequence;
    }



}
    
    