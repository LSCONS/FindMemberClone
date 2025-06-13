using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptionData : MonoBehaviour
{
    public static PlayerOptionData instance;

    public string nowLanguage;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
        
        LoadPlayerOptionData();
    }


    public void LoadPlayerOptionData()
    {
        nowLanguage = PlayerPrefs.GetString("Language", "ENG");
    }

    public void SavePlayerOptionData()
    {
        PlayerPrefs.SetString("Language", nowLanguage);
    }
}
