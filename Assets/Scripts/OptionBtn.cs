using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionPanel;


    public void OptionClick()
    {
        AudioManager.instance.SoundPlayClick(0f);
        optionPanel.SetActive(true);
    }
}
