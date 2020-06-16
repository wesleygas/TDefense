// tested with unity version: 2017.2.0b4
// info: Fills tilemap with random tiles
// usage: Attach this script to empty gameobject, assign some tiles, then press play
// please make sure that you have at least version 2017.2 or the experimental 2d unity 5_5
// https://forum.unity3d.com/threads/update-july-2017.484397/

using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTiles : MonoBehaviour
{

    public Tile[] tiles;
    public GameObject Search;

    void Start()
    {

        RandomTileMap();
    }

    void RandomTileMap()
    {
        // validation
        if (tiles == null || tiles.Length < 1)
        {
            Debug.LogError("Tiles not assigned", gameObject);
            return;
        }

        gameObject.layer = 8;
        var parent = transform.parent;
        if (parent == null)
        {
            var go = new GameObject("Grid");
            go.layer = 8;
            go.AddComponent<Grid>();
            transform.SetParent(go.transform);
        }
        else
        {
            if (parent.GetComponent<Grid>() == null)
            {
                parent.gameObject.AddComponent<Grid>();
            }
        }

        TilemapRenderer tr = GetComponent<TilemapRenderer>();
        if (tr == null)
        {
            tr = gameObject.AddComponent<TilemapRenderer>();
        }

        Tilemap map = GetComponent<Tilemap>();
        if (map == null)
        {
            map = gameObject.AddComponent<Tilemap>();
        }

        // random map generation
        Vector3Int tilePos = Vector3Int.zero;
        int index = 0;
        int height = Maps.bound(1);
        int width = Maps.bound(2);

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                tilePos.y = (height / 2) - (i + 1);
                tilePos.x = j - (width / 2) - 4;

                if (Maps.maps[index, i, j] == 0)
                    map.SetTile(tilePos, tiles[0]);
            }
        }
        AstarPath.active.ScanAsync();
    }
}