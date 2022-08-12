using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Scr_IceBlock : MonoBehaviour
{
    public Tilemap iceTile;

    // Start is called before the first frame update
    void Start()
    {
        iceTile = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TileDestroy(Vector3 pos)
    {
        Vector3Int cellPos = iceTile.WorldToCell(pos);
        
        int x = cellPos.x;
        int y = cellPos.y -1;
        Vector3Int Result = new Vector3Int(x, y, 0);
        Vector3Int Result1 = new Vector3Int(x-1, y, 0);
        Vector3Int Result2 = new Vector3Int(x+1, y, 0);

        iceTile.SetTile(Result , null);
        iceTile.SetTile(Result1 , null);
        iceTile.SetTile(Result2 , null);

    }

    void OnCollisionStay2D(Collision2D col)
    {
        //if(col.gameObject.tag == "FireDie")
        //gameObject.SetActive(false);
    }
}
