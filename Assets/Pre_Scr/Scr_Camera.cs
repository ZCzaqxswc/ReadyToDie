using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Camera : MonoBehaviour
{
    public Transform Target;
    public GameObject ObjTarget;
    public Vector2 Offset;
    public float XMin , XMax , YMin , YMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player"))
        {
            ObjTarget = GameObject.FindWithTag("Player");
            Target = ObjTarget.transform;
            transform.position = new Vector3(
                                             Mathf.Clamp(Target.position.x, XMin, XMax),
                                             Mathf.Clamp(Target.position.y, YMin, YMax),
                                             -2.5f);
        }
        else if(!GameObject.FindWithTag("Player"))
        {
            return;
            //ObjTarget = GameObject.FindWithTag("Reset");
            //Target = ObjTarget.transform;
            //transform.position = new Vector3(Target.position.x ,Target.position.y , -2);
        }
        
    }
}
