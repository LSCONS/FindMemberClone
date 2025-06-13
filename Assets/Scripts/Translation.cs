using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public GameObject KOR_textObject;
    public GameObject ENG_textObject;
    public GameObject JPN_textObject;

    public void SettingActiveFalse()
    {
        KOR_textObject.SetActive(false);
        ENG_textObject.SetActive(false);
        JPN_textObject.SetActive(false);
    }

    public void CheckToTextObject(string language)
    {
        SettingActiveFalse();
        if (language == "ENG")
        {
            ENG_textObject.SetActive(true);
        }
        else if(language == "KOR")
        {
            KOR_textObject.SetActive(true);
        }
        else if (language == "JPN")
        {
            JPN_textObject.SetActive(true);
        }
        else
        {
            Debug.Log("언어 찾기 실패");
        }
    }
}
