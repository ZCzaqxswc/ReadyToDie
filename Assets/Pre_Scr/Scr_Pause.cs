using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Pause : MonoBehaviour
{
    public GameObject PauseAfter;
    bool PauseOnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        if(PauseOnOff)
        {
            Time.timeScale=1;
            PauseOnOff = false;
            PauseAfter.SetActive(false);
            return;
        }
        Time.timeScale=0;
        PauseAfter.SetActive(true);
        PauseOnOff = true;
    }
}
