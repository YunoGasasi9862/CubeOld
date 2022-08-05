using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    bool isOver = false;
    public Text Over;
    private void Start()
    {
        Over = GameObject.Find("Canvas/Panel/GameOver").GetComponent<Text>(); //OMG THIS WORKED!!!!
    }

    public void GameOver()
    {
        if(!isOver)
        {

            Over.gameObject.SetActive(true);
    
             Invoke("Restart", 1f);
            isOver = true;

        }
    }
    void Restart()
    {
        Over.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
}
