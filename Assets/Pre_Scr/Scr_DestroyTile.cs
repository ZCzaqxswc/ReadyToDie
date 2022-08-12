using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Scr_DestroyTile : MonoBehaviour
{
    public Tilemap DestroyTile;
    // Start is called before the first frame update
    void Start()
    {
        DestroyTile = GetComponent<Tilemap>();
    }

    public void TileDestroy(Vector3 pos)
    {
        Vector3Int cellPos = DestroyTile.WorldToCell(pos);
        
        int x = cellPos.x;
        int y = cellPos.y;
        Vector3Int Result = new Vector3Int(x, y, 0);
        //Vector3Int Result1 = new Vector3Int(x-1, y, 0);
        //Vector3Int Result2 = new Vector3Int(x+1, y, 0);

        DestroyTile.SetTile(Result , null);
        //DestroyTile.SetTile(Result1 , null);
        //DestroyTile.SetTile(Result2 , null);

    }
}
