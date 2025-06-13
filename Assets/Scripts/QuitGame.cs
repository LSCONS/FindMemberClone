using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public GameObject settingPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            GameQuit();
    }

    public void GameQuit()
    {
        if (settingPanel.activeSelf) return;
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
