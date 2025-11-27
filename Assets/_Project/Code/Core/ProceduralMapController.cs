using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using System;


public class ProceduralMapController : MonoBehaviour
{

    public enum Orientation { North, South, East }

    public Transform playerTransform;

    public string filePath;
    public string enemiesPath;
    public DungeonData dungeonData;
    private JsonReader _reader;

    public Tile[] tiles;
    public List<Sprite> enemiesSprites;

    public List<GameObject> enemiesPrefabs;

    public List<MapData> sequence = new List<MapData>();

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
        totalRooms = UnityEngine.Random.Range(6, 9);

        GenerateMapSequence(dungeonData.dungeons.ToList());

        Debug.Log("Sequence: [" + string.Join(", ", sequence.Select(m => m.type)) + "]");

        GameObject grid = new GameObject();
        grid.name = "Grid";

        grid.AddComponent<Grid>();

        Grid gridComponent = grid.GetComponent<Grid>();
        gridComponent.cellLayout = GridLayout.CellLayout.Isometric;
        gridComponent.cellSize = new Vector3(1f, 0.5f, 1f);

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
        Vector3Int origin = Vector3Int.zero;
        List<Vector3Int> origins = new List<Vector3Int>();
        List<int> mapsOrientations = new List<int>();

        foreach (MapData mapData in sequence)
        {
            int mapOrientation = UnityEngine.Random.Range(0, 1);
            //origin = GetOrientation(mapOrientation, new Vector3Int(mapData.size[0], mapData.size[1], 0), origin);

            if (mapData.type == "normal")
            {
                MapData normal = dungeonData.dungeons[0];
                origin = GetOrientation(mapOrientation, new Vector3Int(normal.size[0], normal.size[1], 0), origin);
                GenerateMap(normal, origin, tilemap, gridComponent);
            }
            else if (mapData.type == "shop")
            {
                //Bug. Se aleja del origen
                MapData shop = dungeonData.dungeons[1];
                origin = GetOrientation(mapOrientation, new Vector3Int(shop.size[0], shop.size[1], 0), origin);
                GenerateMap(shop, origin, tilemap, gridComponent);
            }
            else if (mapData.type == "boss")
            {
                //Bug. Se aleja del origen
                MapData boss = dungeonData.dungeons[2];
                origin = GetOrientation(mapOrientation, new Vector3Int(boss.size[0], boss.size[1], 0), origin);
                GenerateMap(boss, origin, tilemap, gridComponent);
            }
            else
            {
                Debug.Log("no tengo mapa");
            }
            //origin = new Vector3Int(origin.x + mapData.size[0], (origin.y + mapData.size[1]) / 2, 0);
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
            float rate = UnityEngine.Random.value;
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
            int randomIndex = UnityEngine.Random.Range(1, totalRooms - 1);
            sequence[randomIndex] = allMaps.Find(m => m.type == "shop");
            shopAppeared = true;
        }

        MapData boss = allMaps.Find(m => m.type == "boss");
        sequence.Add(boss);

        return sequence;
    }


    // agregar Vector3Int origin que se va a asignar al map.
    public void GenerateMap(MapData mapData, Vector3Int origin, Tilemap tilemap, Grid gridComponent)
    {
        Map map = new Map(new Vector2Int(origin.x, origin.y), new Vector2Int(mapData.size[0], mapData.size[1]), tilemap);
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


    private Vector3Int GetOrientation(int orientationFinal, Vector3Int size, Vector3Int oldOrigin)
    {
        Vector3Int newOrigin = Vector3Int.zero;

        switch (orientationFinal)
        {
            case 0:

                newOrigin = new Vector3Int(oldOrigin.x + size.x / 2, oldOrigin.y + size.y, 0);
                break;

            case 2:

                newOrigin = new Vector3Int(oldOrigin.x + size.x / 2, oldOrigin.y - size.y, 0);
                break;

            case 1:

                newOrigin = new Vector3Int(oldOrigin.x + size.x, oldOrigin.y + size.y / 2, 0);
                break;
        }

        return newOrigin;
    }

}

