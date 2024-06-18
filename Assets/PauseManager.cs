using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

    public void SetPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            UiManager.Instance.ShowPanelPause();
        }
        else
        {
            UiManager.Instance.HidePanelPause();
        }
    }
}
