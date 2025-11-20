using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstWorldLoader : MonoBehaviour
{
    public MapType mapType;

    public List<Vector2Int> mapSizes;
    public List<Vector2Int> mapOrigins;
    public Tile[] tiles;

    private void Start()
    {
        GameObject grid = new GameObject();
        grid.name = "Grid";

        grid.AddComponent<Grid>();

        Grid gridComponent = grid.GetComponent<Grid>();
        gridComponent.cellLayout = GridLayout.CellLayout.Isometric;
        //gridComponent.cellSize = new Vector3(0.32f, 0.16f, 0.32f);
        gridComponent.cellSize = new Vector3(1f, 0.5f, 1f);

        GameObject tileMap = new GameObject();
        tileMap.name = "Tile Map";

        tileMap.AddComponent<Tilemap>();
        tileMap.AddComponent<TilemapRenderer>();

        TilemapRenderer tilemapRenderer = tileMap.GetComponent<TilemapRenderer>();
        tilemapRenderer.sortOrder = TilemapRenderer.SortOrder.TopRight;

        tileMap.transform.parent = grid.transform;

        Tilemap tilemap = tileMap.GetComponent<Tilemap>();

        switch (mapType)
        {
            case MapType.Small:
                GenerateSmallMap(tilemap);
                break;

            case MapType.Medium_type1:
                GenerateMedium1Map(tilemap);
                break;

            case MapType.Medium_type2:
                GenerateMedium2Map(tilemap);
                break;

            case MapType.Medium_type3:
                GenerateMedium3Map(tilemap);
                break;

            case MapType.Big:
                GenerateBigMap(tilemap);
                break;
        }
    }

    void GenerateSmallMap(Tilemap tilemap)
    {
        Map smallMap = new Map(mapOrigins[0], mapSizes[0], tilemap);
        List<Vector3Int> coordinates = smallMap.GenerateCoordinates();
        List<Vector3Int> doors = smallMap.GenerateEntranceExit();
        smallMap.Render(tiles[0], coordinates);
        smallMap.Render(tiles[1], doors);
    }

    void GenerateMedium1Map(Tilemap tilemap)
    {
        Map medium1Map = new Map(mapOrigins[0], mapSizes[1], tilemap);
        List<Vector3Int> coordinates = medium1Map.GenerateCoordinates();
        List<Vector3Int> doors = medium1Map.GenerateEntranceExit();
        medium1Map.Render(tiles[0], coordinates);
        medium1Map.Render(tiles[1], doors);
    }

    void GenerateMedium2Map(Tilemap tilemap)
    {
        Map medium2Map = new Map(mapOrigins[0], mapSizes[2], tilemap);
        List<Vector3Int> coordinates = medium2Map.GenerateCoordinates();
        List<Vector3Int> doors = medium2Map.GenerateEntranceExit();
        medium2Map.Render(tiles[0], coordinates);
        medium2Map.Render(tiles[1], doors);
    }

    void GenerateMedium3Map(Tilemap tilemap)
    {
        Map medium3Map = new Map(mapOrigins[0], mapSizes[3], tilemap);
        List<Vector3Int> coordinates = medium3Map.GenerateCoordinates();
        List<Vector3Int> doors = medium3Map.GenerateEntranceExit();
        medium3Map.Render(tiles[0], coordinates);
        medium3Map.Render(tiles[1], doors);
    }

    void GenerateBigMap(Tilemap tilemap)
    {
        Map bigMap = new Map(mapOrigins[0], mapSizes[4], tilemap);
        List<Vector3Int> coordinates = bigMap.GenerateCoordinates();
        List<Vector3Int> doors = bigMap.GenerateEntranceExit();
        bigMap.Render(tiles[0], coordinates);
        bigMap.Render(tiles[1], doors);
    }

}
