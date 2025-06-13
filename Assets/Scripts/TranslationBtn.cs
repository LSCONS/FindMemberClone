using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TranslationBtn : MonoBehaviour
{
    public string language;
    public GameObject textObject;
    public GameObject translationObject;
    private Translation translation;


    public void ClickButton()
    {
        translation = translationObject.GetComponent<Translation>();
        if (textObject.activeSelf == false)
        {
            AudioManager.instance.SoundPlayClick(0f);
            StartSceneTextManager.instance.SettingLanguage(language);

            translation.CheckToTextObject(language);

            PlayerOptionData.instance.nowLanguage = language;
            PlayerOptionData.instance.SavePlayerOptionData();
            PlayerOptionData.instance.LoadPlayerOptionData();
        }
    }
}
