using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour {

    public GameObject[] panels;
    public GameObject currentPanel;

    public GameObject nextObj;
    public GameObject prevObj;

    int index;

    private void OnEnable()
    {
        index = 0;
        ActivePanel();
    }

    public void Next()
    {
        if (index < panels.Length-1)
        {
            index++;
            ActivePanel();
            if (index >= panels.Length - 1)
            {
                nextObj.SetActive(false);
            }
            prevObj.SetActive(true);
        }
    }

    public void Prev()
    {
        if (index > 0)
        {
            index--;
            ActivePanel();
            if (index <= 0)
            {
                prevObj.SetActive(false);
            }
            nextObj.SetActive(true);
        }
    }


    public void ActivePanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        panels[index].SetActive(true);

        currentPanel = panels[index];
    }
}
