using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PotalRotation : MonoBehaviour
{
    float power;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        power -= Time.deltaTime*300;
        this.transform.rotation = Quaternion.Euler(0, 0, power);
    }
}
