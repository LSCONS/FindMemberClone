using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCancleBtn : MonoBehaviour
{
    public GameObject optionPanel;

    public void OptionPanelCancleBtn()
    {
        AudioManager.instance.SoundPlayClick(0f);
        optionPanel.SetActive(false);
    }
}
