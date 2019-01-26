using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject currentPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuPanel.active)
            {
                currentPanel.SetActive(false);
                menuPanel.SetActive(true);
            }
        }
    }

    public void SetCurrentPanel(GameObject panel)
    {
        currentPanel = panel;
    }
}
