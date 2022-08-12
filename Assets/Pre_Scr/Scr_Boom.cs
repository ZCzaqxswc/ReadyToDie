using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Boom : MonoBehaviour
{
    public float Timer;
    Rigidbody2D Boom;
    float power;
    // Start is called before the first frame update
    void Start()
    {
        Boom = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        power -= Time.deltaTime*300;
        this.transform.rotation = Quaternion.Euler(0, 0, power);
        Timer += Time.deltaTime;
        if(Timer> 0.2f)
        {
            Boom.velocity = new Vector2(0f , 0f);
            StartCoroutine(Del());
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Destroy")
        {
            col.transform.GetComponent<Scr_DestroyTile>().TileDestroy(transform.position);
        }
    }


    IEnumerator Del()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
