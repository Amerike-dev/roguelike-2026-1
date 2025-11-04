using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralMapController : MonoBehaviour
{
    public string filePath;
    public DungeonData dungeonData;
    private JsonReader _reader;

    public Tile[] tiles;

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

        TilemapRenderer tilemapRenderer = tileMap.GetComponent<TilemapRenderer>();
        tilemapRenderer.sortOrder = TilemapRenderer.SortOrder.TopRight;

        tileMap.transform.parent = grid.transform;

        Tilemap tilemap = tileMap.GetComponent<Tilemap>();

        MapData mapData = dungeonData.dungeons[0];

        Map map = new Map(Vector2Int.zero, new Vector2Int(mapData.size, mapData.size), tilemap);
        List<Vector3Int> coordinates = map.GenerateCoordinates();
        map.Render(tiles[0], coordinates);

        foreach (DecorationData decoration in mapData.decorations)
        {
            PlaceNewTiles(new Vector3Int(decoration.position[0], decoration.position[1]), tiles[1], tilemap);
        }
    }

    void PlaceNewTiles(Vector3Int coordinates, Tile tile, Tilemap tilemap)
    {
        tilemap.SetTile(coordinates, tile);
    }
}
