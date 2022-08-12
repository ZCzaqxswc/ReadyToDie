using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ice")
        {
            col.transform.GetComponent<Scr_IceBlock>().TileDestroy(transform.position);
        }
    }
}
