using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_testPotal : MonoBehaviour
{
    public GameObject Clear;
    public Animator transition;
    HGSStateMng SM;
    Scr_GM GM;
    // Start is called before the first frame update
    void Start()
    {
        GM=Clear.GetComponent<Scr_GM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            transition.SetTrigger("Close");
           Scr_StageManager.instance.ClearStage();
           col.gameObject.SetActive(false);
           gameObject.SetActive(false);
        }
    }

}
