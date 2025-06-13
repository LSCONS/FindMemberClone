using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearSceneTextManager : MonoBehaviour
{
    public static ClearSceneTextManager instance;

    public Text NJH_Text;               //재현님 텍스트
    public Text YGM_Text;               //근무님 텍스트
    public Text SJW_Text;               //제우님 텍스트
    public Text CBC_Text;               //병철님 텍스트
    public Text LDH_Text;               //동현님 텍스트
    public Text KHA_Text;               //현아님 텍스트

    public Text gameOverTxt;            //게임 오버 텍스트
    public Text bestRecordTxt;          //최고 기록 텍스트
    public Text currentRecordTxt;       //현재 기록 텍스트
    public Text retryTxt;               //다시 시도 텍스트

    public Text pressAnyKeyTxt;         //키 입력 유도 텍스트

    public Font fontENG;                //영어 폰트
    public Font fontKOR;                //한글 폰트
    public Font fontJPN;                //일본어 폰트

    private string nowLanguage;         //옵션에서 설정한 언어 정보

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
        SettingLanguage(PlayerOptionData.instance.nowLanguage); //설정한 언어를 기준으로 텍스트를 바꿈.
    }


    /// <summary>
    /// 설정된 언어에 따라 특정 폰트로 변환해주는 메서드
    /// </summary>
    private void SettingFont(Font font)
    {
        NJH_Text.font = font;
        YGM_Text.font = font;
        SJW_Text.font = font;
        CBC_Text.font = font;
        LDH_Text.font = font;
        KHA_Text.font = font;
        gameOverTxt.font = font;
        bestRecordTxt.font = font;
        currentRecordTxt.font = font;
        retryTxt.font = font;
        pressAnyKeyTxt.font = font;
    }


    /// <summary>
    /// 설정되어있는 언어로 모든 텍스트의 출력을 바꿔주는 메서드
    /// </summary>
    private void SettingLanguage(string language)
    {
        //nowLanguage의 언어가 셋 중 하나도 해당하지 않을 경우 현재 언어를 ENG로 변경
        nowLanguage = language;
        if (nowLanguage != "ENG" && 
            nowLanguage != "KOR" && 
            nowLanguage != "JPN")
        {
            nowLanguage = "ENG";
        }

        if (nowLanguage == "ENG")
        {
            SettingFont(fontENG);
            NJH_Text.text = "I want to create a game for 100 billion people.";
            YGM_Text.text = "I want to create a game that will last a long time in peoples memory";
            SJW_Text.text = "I want to create a game that will be nominated for GOTY";
            CBC_Text.text = "I want to create a game that brings happiness to the players";
            LDH_Text.text = "I want to create a game that we can enjoy now, remebering the memories";
            KHA_Text.text = "I want to create a game that we forget the harsh reality";

            gameOverTxt.text = "Game Over";
            bestRecordTxt.text = "Best";
            currentRecordTxt.text = "Current";
            retryTxt.text = "Play Again.";

            pressAnyKeyTxt.text = "Please click the screen";
        }
        else if (nowLanguage == "KOR")
        {
            SettingFont(fontKOR);
            NJH_Text.text = "1억명이 쓰는 게임을 만들자";
            YGM_Text.text = "사람들 기억에 오래 남을 수 있는 게임을 만들자";
            SJW_Text.text = "GOTY 후보에 올라갈 만한 게임을 만들자";
            CBC_Text.text = "유저들의 행복감을 채워주는 게임을 만들자";
            LDH_Text.text = "추억 속의 낭만을 챙기며, 지금을 즐길 게임을 만들자";
            KHA_Text.text = "힘든 현실을 잠시나마 잊을 수 있는 게임을 만들자";

            gameOverTxt.text = "게임오버";
            bestRecordTxt.text = "최고 기록";
            currentRecordTxt.text = "현재 기록";
            retryTxt.text = "다시하기";

            pressAnyKeyTxt.text = "화면을 클릭해 주세요";
        }
        else if (nowLanguage == "JPN")
        {
            SettingFont(fontJPN);
            NJH_Text.text = "一億人が楽しめるゲームを作ろう";
            YGM_Text.text = "みんなの思い出に残るゲームを作ろう";
            SJW_Text.text = "GOTYにノミネートされるゲームを作ろう";
            CBC_Text.text = "ユーザーを幸せにするゲームを作ろう";
            LDH_Text.text = "思い出を守りながら今を楽しめるゲームを作ろう";
            KHA_Text.text = "辛い堅実を忘れられるゲームを作ろう";

            gameOverTxt.text = "ゲームオーバー";
            bestRecordTxt.text = "最高記録";
            currentRecordTxt.text = "現在記録";
            retryTxt.text = "もう一度プレイ";

            pressAnyKeyTxt.text = "画面をクリックしてください";
        }
        else Debug.LogError("Failed: SettingLanguage");
    }
}
