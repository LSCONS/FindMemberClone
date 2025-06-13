using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameoverPanel : MonoBehaviour
{
    public GameObject gameoverPanel;
    public GameObject pressAnyKeyText;

    public Text currentTimeText;
    public Text bestTimeText;


    void Start()
    {
        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && gameoverPanel != null && !gameoverPanel.activeSelf)
        {
            gameoverPanel.SetActive(true);
            pressAnyKeyText.SetActive(false);

            bestTimeText.text = PlayerPrefs.GetInt("BestScore").ToString();
            currentTimeText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        }
    }
}