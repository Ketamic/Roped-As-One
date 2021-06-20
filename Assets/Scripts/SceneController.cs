using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Canvas pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown(KeyCode.LeftBracket))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if(Input.GetKeyDown(KeyCode.RightBracket))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.enabled == false)
            {
                Time.timeScale = 0;
                pauseMenu.enabled = true;
            } else if(pauseMenu.enabled == true)
            {
                pauseMenu.enabled = false;
                Time.timeScale = 1;
            }
        }
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 0;
        pauseMenu.enabled = true;
    }
}
