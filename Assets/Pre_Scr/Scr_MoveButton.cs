using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MoveButton : MonoBehaviour
{
    GameObject PlayerChar;
    Scr_Player playerscr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( KeyCode.A))
        {
            FireDie();
        }
        if(Input.GetKeyDown( KeyCode.S))
        {
            BoomDie();
        }
        if(Input.GetKeyDown( KeyCode.D))
        {

            ReadyToDie();
            
        }



        if(!GameObject.FindWithTag("Player"))
        {
            return;
        }
        PlayerChar = GameObject.FindWithTag("Player");
        playerscr = PlayerChar.GetComponent<Scr_Player>();
        
    }

    public void LeftDown()
    {
        playerscr.InputLeft = true;
    }
    public void LeftUp()
    {
        playerscr.InputLeft = false;
    }

    public void RightDown()
    {
        playerscr.InputRight = true;
    }

    public void RightUp()
    {
        playerscr.InputRight = false;
    }
    public void JumpDown()
    {
        playerscr.InputJump = true;
    }
    public void JumpUp()
    {
        playerscr.InputJump = false;
    }
    public void FireDie()
    {
        playerscr.DieType = "fire";
    }
    public void BoomDie()
    {
        playerscr.DieType = "boom";
    }

    public void ReadyToDie()
    {
        playerscr.Die = true;
    }

    public void DieGuard()
    {
        playerscr.Die = false;
    }


}
