using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;

    public string nowLanguage;

    public GameObject TranslationObject;

    public Text startBtnTxt;
    public Text optionBtnTxt;

    public Text topTitleTxt;
    public Text middleTitleTxt;
    public Text bottomTitleTxt;

    public Text settingTitleTxt;
    public Text settingAudioTxt;
    public Text settingEffectTxt;
    public Text settingCardColorTxt;
    public Text settingLanguageTxt;

    public Text NJH_Text;
    public Text YGM_Text;
    public Text SJW_Text;
    public Text CBC_Text;
    public Text LDH_Text;
    public Text KHA_Text;

    //public Text gameOutBtnTxt;

    public Font fontENG;
    public Font fontKOR;
    public Font fontJPN;

    private void Awake()
    {
        if(instance == null)
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
        nowLanguage = PlayerPrefs.GetString("PlayerLanguage", "ENG");       //추후 플레이어가 저장한 언어가 있다면 가져옴. 없으면 "ENG"로 반환
        SettingLanguage(nowLanguage);
        TranslationObject.GetComponent<Translation>().CheckToTextObject(nowLanguage);
    }

    public void SettingLanguage(string language)
    {
        nowLanguage = language;
        //nowLanguage의 언어가 셋 중 하나도 해당하지 않을 경우 현재 언어를 ENG로 변경
        if (nowLanguage != "ENG" &&  nowLanguage != "KOR" && nowLanguage != "JPN")  
        {
            nowLanguage = "ENG";
        }
        Debug.Log("현재 언어: " +  nowLanguage);
        if(nowLanguage == "ENG")
        {
            SettingFont(fontENG);
            startBtnTxt.text = "Start";
            //gameOutBtnTxt.text = "Exit";
            optionBtnTxt.text = "Option";
            topTitleTxt.text = "Introduce Our Selves";
            middleTitleTxt.text = "FLIPPING\nCARD GAME";
            bottomTitleTxt.text = "Unity 7th class 12 group";
            settingTitleTxt.text = "Setting";
            settingAudioTxt.text = "Background Sound";
            settingEffectTxt.text = "Effect Sound";
            settingCardColorTxt.text = "Card Color Change";
            settingLanguageTxt.text = "Language Setting";
        }
        else if (nowLanguage == "KOR")
        {
            SettingFont(fontKOR);
            startBtnTxt.text = "시작하기";
            //gameOutBtnTxt.text = "게임종료";
            optionBtnTxt.text = "옵션";
            topTitleTxt.text = "아이엠 그라운드";
            middleTitleTxt.text = "카드\n뒤집기!";
            bottomTitleTxt.text = "Unity 7기 12조";
            settingTitleTxt.text = "세팅";
            settingAudioTxt.text = "배경음";
            settingEffectTxt.text = "효과음";
            settingCardColorTxt.text = "카드 색상 설정";
            settingLanguageTxt.text = "언어 설정";
        }
        else if (nowLanguage == "JPN")
        {
            SettingFont(fontJPN);
            startBtnTxt.text = "スタート";
            //gameOutBtnTxt.text = "終了";
            optionBtnTxt.text = "設定";
            topTitleTxt.text = "たのしい！なかよし！";
            middleTitleTxt.text = "自己紹介\nかるた";
            bottomTitleTxt.text = "Unity 7期生 12組";
            settingTitleTxt.text = "設定";
            settingAudioTxt.text = "背景音楽";
            settingEffectTxt.text = "効果音";
            settingCardColorTxt.text = "カードの色の変更";
            settingLanguageTxt.text = "言語設定";

        }
        else
        {
            Console.WriteLine("언어 확인 오류");
        }
    }

    private void SettingFont(Font font)
    {
        startBtnTxt.font = font;
        optionBtnTxt.font = font;
        //gameOutBtnTxt.font = font;
        topTitleTxt.font = font;
        middleTitleTxt.font = font;
        bottomTitleTxt.font = font;
        settingTitleTxt.font = font;
        settingAudioTxt.font = font;
        settingEffectTxt.font = font;
        settingCardColorTxt.font = font;
        settingLanguageTxt.font = font;
    }


}
