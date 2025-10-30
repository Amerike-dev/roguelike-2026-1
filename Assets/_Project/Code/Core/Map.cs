using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public enum MapType { None, Small, Medium_type1, Medium_type2, Medium_type3, Big }

public class Map
{
    private Vector2Int _origin;
    private Vector2Int _size;
    private Tilemap _tilemap;

    public MapType mapType;

    public Map(Vector2Int origin, Vector2Int size, Tilemap tileMap)
    {
        _origin = origin;
        _size = size;
        _tilemap = tileMap;
    }

    public List<Vector3Int> GenerateCoordinates()
    {
        List<Vector3Int> coordinatesToReturn = new List<Vector3Int>();

        for (int x = _origin.x; x < _origin.x + _size.x; x++)
        {
            for (int y = _origin.y; y < _origin.y + _size.y; y++)
            {
                coordinatesToReturn.Add(new Vector3Int(x, y));
            }
        }

        return coordinatesToReturn;
    }

    public List<Vector3Int> GenerateEntranceExit()
    {
        List<Vector3Int> doorsCoordinates = new List<Vector3Int>();

        int halfSize = _size.y / 2;

        //Entrance
        doorsCoordinates.Add(new Vector3Int(0, halfSize, 0));
        doorsCoordinates.Add(new Vector3Int(0, halfSize++, 0));
        doorsCoordinates.Add(new Vector3Int(0, halfSize--, 0));

        //Exit
        doorsCoordinates.Add(new Vector3Int(_size.x - 1, halfSize, 0));
        doorsCoordinates.Add(new Vector3Int(_size.x - 1, halfSize++, 0));
        doorsCoordinates.Add(new Vector3Int(_size.x - 1, halfSize--, 0));

        return doorsCoordinates;
    }

    public void Render(Tile tile, List<Vector3Int> coordinates)
    {
        for (int i = 0; i < coordinates.Count; i++)
        {
            _tilemap.SetTile(coordinates[i], tile);
        }
    }

}
