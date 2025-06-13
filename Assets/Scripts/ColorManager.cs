using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;

    public GameObject backonetColor;

    public GameObject backtwoColor;

    public GameObject backThreeColor;

    public GameObject backFourColor;

    public GameObject backFiveColor;

    public GameObject onClickImage;

    public int colorType = 1;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // 새로운 씬이 로드될 때 자동으로 FindUIObjects를 호출합니다.
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
        colorType = PlayerPrefs.GetInt("colorType", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
         FindUIObjects();

    }

    // Update is called once per frame
    void Update()
    {

        switch(colorType)
        {
            case 1:
            if (backonetColor != null)
                onClickImage.transform.position = backonetColor.transform.position;
            break;

            case 2:
            if (backtwoColor != null)
                onClickImage.transform.position = backtwoColor.transform.position;
            break;

            case 3:
            if (backThreeColor != null)
                onClickImage.transform.position = backThreeColor.transform.position;
            break;

            case 4:
            if (backFourColor != null)
                onClickImage.transform.position = backFourColor.transform.position;
            break;

            case 5:
            if (backFiveColor != null)
                onClickImage.transform.position = backFiveColor.transform.position;
            break;
        }
        
    }

    //OnDestroy에서 SceneManager.sceneLoaded 이벤트를 해제하여 불필요한 이벤트 호출을 방지합니다.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 로드 후 오브젝트 참조 갱신
        FindUIObjects();
    }


    private void FindUIObjects()
    {
        // Canvas에서 특정 오브젝트를 찾음
        GameObject canvas = GameObject.Find("Canvas");

        if(canvas != null)
        {
       
            
            Transform settingPanel = canvas.transform.Find("Setting Panel");

            if (settingPanel != null)
            {
                Transform cardColorSettingText = settingPanel.Find("Card Color Setting Text");
                
                if (cardColorSettingText != null)
                {
                    backonetColor = cardColorSettingText.transform.Find("Back1")?.gameObject;
                    backtwoColor = cardColorSettingText.transform.Find("Back2")?.gameObject;
                    backThreeColor = cardColorSettingText.transform.Find("Back3")?.gameObject;
                    backFourColor = cardColorSettingText.transform.Find("Back4")?.gameObject;
                    backFiveColor = cardColorSettingText.transform.Find("Back5")?.gameObject;
                    onClickImage = cardColorSettingText.transform.Find("SelectCard")?.gameObject;
                }

            }
        }  
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
