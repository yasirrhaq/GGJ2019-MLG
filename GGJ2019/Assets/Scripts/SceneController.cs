using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void LoadScene(string level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Byeee");
    }
}
