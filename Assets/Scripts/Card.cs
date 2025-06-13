using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int index;
    public SpriteRenderer frontimage;
    public SpriteRenderer backImage;
    public GameObject front;
    public GameObject back;
    public GameObject backBtn;
    public Button BtnCardFlip;

    private AudioSource flipSound;

    public Animator anim;
    public int colorTypeCard = 1;

    private void Start()
    {
        BtnCardFlip.onClick.AddListener(OpenCard);
        colorTypeCard = ColorManager.instance.colorType;

        switch (colorTypeCard)
        {
            case 1:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 2:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 3:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 4:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;

            case 5:
                backImage.sprite = Resources.Load<Sprite>($"Back{colorTypeCard}");
            break;
            
        }
        flipSound = GetComponent<AudioSource>();
        flipSound.clip = AudioManager.instance.cardFlipClip;
    }


    void Update()
    {
        if(transform.eulerAngles.y >= -90f && transform.eulerAngles.y <= 90f)   //카드가 뒷면
        {
            front.SetActive(false);
            back.SetActive(true);
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
        }
    }


    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", GameManager.Instance.cardCloseDelayTime);
    }


    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }


    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        backBtn.SetActive(false);
        flipSound.Play();
        GameManager.Instance.selectCount++;

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else 
        { 
            GameManager.Instance.secondCard = this;
            GameManager.Instance.MatchCard();
        }
    }


    public void CloseCard()
    {
        Invoke(nameof(CloseCardInvoke), GameManager.Instance.cardCloseDelayTime);
    }


    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        backBtn.SetActive(true);
    }


    public void Setting(int number)
    {
        index = number;
        frontimage.sprite = Resources.Load<Sprite>($"card{index}");
    }
}
