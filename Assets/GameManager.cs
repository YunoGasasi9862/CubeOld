using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool isOver = false;

   public void GameOver()
    {
        if(!isOver)
        {
            Invoke("Restart", 0.5f);
            isOver = true;

        }
    }

    void Restart()
    {

        SceneManager.LoadScene("GameOver");
    }
}
