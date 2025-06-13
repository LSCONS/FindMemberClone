using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBackground : MonoBehaviour
{
    public Sprite KOR_BackGround;
    public Sprite ENG_BackGround;
    public Sprite JPN_BackGround;


    private void Start()
    {
        string nowLanguage = PlayerOptionData.instance.nowLanguage;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (nowLanguage == "ENG")
        {
            spriteRenderer.sprite = ENG_BackGround;
        }
        else if (nowLanguage == "KOR")
        {
            spriteRenderer.sprite = KOR_BackGround;
        }
        else if (nowLanguage == "JPN")
        {
            spriteRenderer.sprite = JPN_BackGround;
        }
    }
}
