using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject   endPanel;
    public GameObject   cardObjects;
    public Text         timeTxt;
    public Text         bestScoreTxt;
    public Text         tryCountTxt;
    public Card         firstCard;
    public Card         secondCard;

    private float   remainTime;
    private bool    isCounting; // 시간 업데이트 제어를 위한 플래그
    private int     tryCount;

    public float    cardFlipDelayTime;
    public float    cardCloseDelayTime;
    public float    MoveToClearSceneDelayTime;
    public float    timeLimit;
    public int      cardCount;
    public int      selectCount;

    public void Awake()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        remainTime = timeLimit;
        isCounting = true; // 카운트 시작
        timeTxt.text = timeLimit.ToString("N2");
    }


    void Update()
    {
        if (isCounting && remainTime > 0) // isCounting이 true일 때만 시간 감소
        {
            remainTime -= Time.deltaTime;
            timeTxt.text = remainTime.ToString("N2");
        }
        else if (remainTime <= 0)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0.0f;
            timeTxt.text = "0.00";
            if (PlayerPrefs.GetInt("BestScore") == 0)
            {
                bestScoreTxt.text = "기록이 없습니다.";
            }
            else
            {
                bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString("N2");
            }
        }

        tryCount = selectCount / 2;
        tryCountTxt.text = tryCount.ToString();
    }


    public void MatchCard()
    {
        if (firstCard.index == secondCard.index)
        {
            CheckMatched();
            cardCount -= 2;

            if (cardCount == 0)
            {
                tryCount = selectCount / 2;
                SaveCurrentCount();
                isCounting = false; // 시간 카운트 멈춤
                StartCoroutine(WaitAndClearGame()); // 1초 후 씬 전환
            }
        }
        else
        {
            CheckMatched();
        }
    }


    /// <summary>
    /// 선택한 두 카드를 비교하고 매칭이 가능한지 처리하는 메서드
    /// </summary>
    public void CheckMatched()
    {
        SetActiveFalseButtonObjects();              //모든 버튼 오브젝트 비활성화
        if (firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            AudioManager.instance.SoundPlayMatchSuccess(0.5f);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            AudioManager.instance.SoundPlayMatchFailed(0.5f);
        }
        firstCard = null;
        secondCard = null;
        Invoke(nameof(SetActiveTrueButtonObjects), cardFlipDelayTime); //delay 이후 모든 버튼 오브젝트 활성화
    }


    private IEnumerator WaitAndClearGame()
    {
        yield return new WaitForSeconds(1.0f); // 1초 대기 (Time.timeScale의 영향을 받지 않음)
        ClearGameMoveScene();
    }


    private void SaveCurrentCount()
    {
        if (PlayerPrefs.GetInt("BestScore") == 0)
        {
            PlayerPrefs.SetInt("BestScore", tryCount);
            bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString("N2");
        }
        else
        {
            if (tryCount < PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", tryCount);
            }
        }
        PlayerPrefs.SetInt("CurrentScore", tryCount);
    }


    /// <summary>
    /// Button이라는 이름의 태그를 가진 모든 오브젝트를 활성화
    /// </summary>
    public void SetActiveTrueButtonObjects()
    {
        List<GameObject> buttonObject = GetButtonGameObjects(cardObjects, "Button");

        if (buttonObject.Count > 0)
        {
            for (int i = 0; i < buttonObject.Count; i++)
            {
                buttonObject[i].SetActive(true);
            }
        }
    }


    /// <summary>
    /// Button이라는 이름의 태그를 가진 모든 오브젝트를 비활성화
    /// </summary>
    public void SetActiveFalseButtonObjects()
    {
        List<GameObject> buttonObject = GetButtonGameObjects(cardObjects, "Button");

        if (buttonObject.Count > 0)
        {
            for (int i = 0; i < buttonObject.Count; i++)
            {
                buttonObject[i].SetActive(false);
            }
        }
    }


    /// <summary>
    /// 특정 오브젝트 자식들 중 특정 tag를 가진 모든 오브젝트를 List형태로 반환하는 메서드
    /// </summary>
    /// <param name="parentObject">기준을 잡고 찾을 부모 오브젝트</param>
    /// <param name="tag">찾을 tag</param>
    /// <returns>반환받는 List</returns>
    private List<GameObject> GetButtonGameObjects(GameObject parentObject, string tag)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (Transform child in parentObject.transform)
        {
            if (child.gameObject.CompareTag(tag))
            {
                result.Add(child.gameObject);
            }

            result.AddRange(GetButtonGameObjects(child.gameObject, tag));
        }
        return result;
    }


    private void ClearGameMoveScene()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
