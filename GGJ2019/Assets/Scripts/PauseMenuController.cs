using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour {

    public GameObject pauseMenu;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        } 
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.active);
        if (!pauseMenu.active)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
