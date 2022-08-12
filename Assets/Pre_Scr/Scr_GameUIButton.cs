using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_GameUIButton : MonoBehaviour
{
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale=1;
    }
    public void GoLobby()
    {
        Time.timeScale=1;
        StartCoroutine(GoToLobby());
        //SceneManager.LoadScene("2_LobbyScene");
    }

    IEnumerator GoToLobby()
    {
        transition.SetTrigger("Close");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("2_LobbyScene");
    }
}
