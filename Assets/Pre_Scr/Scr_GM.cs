using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_GM : MonoBehaviour
{
    public GameObject Player;
    public int Life;
    public Text LifeText;
    public float ReviveTimer;
    Transform Revive;
    GameObject[] LifeCount;

    public GameObject EndButton;
    public GameObject EndButton1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] LifeCount = GameObject.FindGameObjectsWithTag("LifeCount");
        Life = LifeCount.Length;
        LifeText.text= "Life : "+Life;
        Revive = GameObject.FindWithTag("Reset").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindWithTag("Player"))
        {
            ReviveTimer += Time.deltaTime;
            if(ReviveTimer > 3)
            {
                RevivePlayer();
                ReviveTimer =0;
            }
            
        }
        Revive = GameObject.FindWithTag("Reset").transform;
    }

    void RevivePlayer()
    {
        if(Life > 0)
        {
            GameObject User = Instantiate(Player,Revive.position,transform.rotation);
            Life--;
            LifeText.text= "Life : "+Life;
        }
        else
        {
            EndButton.SetActive(true);
            EndButton1.SetActive(false);
            return;
        }
    }
}
