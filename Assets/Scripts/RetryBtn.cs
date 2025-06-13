using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    public void Retry()
    {
        AudioManager.instance.SoundPlayClick(0f);
        SceneManager.LoadScene("StartScene");
    }
}