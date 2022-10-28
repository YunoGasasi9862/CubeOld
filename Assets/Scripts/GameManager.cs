using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool isOver = false;
    [SerializeField] GameObject gameoverScreen;

    private void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Time.timeScale = 1;
           
            Restart();
        }
    }
  
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }

   public void pause()
    {
        Time.timeScale = 0;
        Instantiate(gameoverScreen, transform.position, Quaternion.identity);
       
    }
}
