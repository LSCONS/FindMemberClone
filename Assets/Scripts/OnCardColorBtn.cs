using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCardColorBtn : MonoBehaviour
{

    public void OnClickOne()
    {
        AudioManager.instance.SoundPlayClick(0f);
        ColorManager.instance.colorType = 1;
        PlayerPrefs.SetInt("colorType", 1);
    }
    public void OnClickTwo()
    {
        AudioManager.instance.SoundPlayClick(0f);
        ColorManager.instance.colorType = 2;
        PlayerPrefs.SetInt("colorType", 2);
    }

    public void OnClickThree()
    {
        AudioManager.instance.SoundPlayClick(0f);
        ColorManager.instance.colorType = 3;
        PlayerPrefs.SetInt("colorType", 3);
    }

    public void OnClickFour()
    {
        AudioManager.instance.SoundPlayClick(0f);
        ColorManager.instance.colorType = 4;
        PlayerPrefs.SetInt("colorType", 4);
    }

    public void OnClickFive()
    {
        AudioManager.instance.SoundPlayClick(0f);
        ColorManager.instance.colorType = 5;
    }

}
