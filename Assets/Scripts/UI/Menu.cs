using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ClosePanel(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
