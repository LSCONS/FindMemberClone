using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneTextManager : MonoBehaviour
{
    public Text tryCount;

    public static MainSceneTextManager instance;

    public string nowLanguage;

    public Font fontENG;
    public Font fontKOR;
    public Font fontJPN;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SettingLanguage(PlayerOptionData.instance.nowLanguage);
    }
    private void SettingFont(Font font)
    {
        tryCount.font = font;
    }

    public void SettingLanguage(string language)
    {
        nowLanguage = language;
        //nowLanguage의 언어가 셋 중 하나도 해당하지 않을 경우 현재 언어를 ENG로 변경
        if (nowLanguage != "ENG" && nowLanguage != "KOR" && nowLanguage != "JPN")
        {
            nowLanguage = "ENG";
        }


        if (nowLanguage == "ENG")
        {
            SettingFont(fontENG);
            tryCount.text = "Try Count";
        }
        else if (nowLanguage == "KOR")
        {
            SettingFont(fontKOR);
            tryCount.text = "시도 횟수";

        }
        else if (nowLanguage == "JPN")
        {
            SettingFont(fontJPN);
            tryCount.text = "試行回数";

        }
        else
        {
            Console.WriteLine("언어 확인 오류");
        }
    }

}
