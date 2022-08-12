using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 한번만 실행 해도 올라가요^^
        transform.DOMove(Vector3.up, 5.0f);
        transform.DOScale(Vector3.one, 5.0f);
        transform.DORotate(Vector3.forward, 5.0f);

        Material mat = GetComponent<MeshRenderer>().material;
        mat.DOColor(Color.cyan,5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
