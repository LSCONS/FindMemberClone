using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip matchFailedClip;       //카드 매치 실행 시 실패할 경우 출력할 오디오 클립
    public AudioClip matchSuccessClip;      //카드 매치 실행 시 성공할 경우 출력할 오디오 클립
    public AudioClip cardFlipClip;          //게임 내에서 카드를 뒤집을 경우 출력할 오디오 클립
    public AudioClip clickButtonClip;       //버튼을 클릭할 경우 출력할 오디오 클립
    public AudioClip bgmClip;               //배경 음악으로 출력할 오디오 클립

    public GameObject successSoundObj;      //매치 성공 오디오소스가 담긴 오브젝트
    public GameObject failedSoundObj;       //매치 실패 오디오소스가 담긴 오브젝트
    public GameObject bgm_SoundObj;         //배경 음악 오디오소스가 담긴 오브젝트
    public GameObject clickSoundObj;        //클릭 효과음 오디오소스가 담긴 오브젝트

    private AudioSource bgmSource;
    private AudioSource failedSource;
    private AudioSource successSource;
    private AudioSource clickSource;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);     //scene이 이동하는 과정에 해당 오브젝트가 파괴되지 않도록 관리.
    }

    private void Start()
    {
        GetComponentSource();       //각 오브젝트에 있는 AudioSource컴포넌트 가져오기
        InputClipData();            //각 AudioSource컴포넌트에 해당하는 AudioClip 할당하기
        SoundPlayBGM(0f);           //배경음악 실행
    }

    private void GetComponentSource()
    {
        bgmSource = bgm_SoundObj.GetComponent<AudioSource>();
        failedSource = failedSoundObj.GetComponent<AudioSource>();
        successSource = successSoundObj.GetComponent<AudioSource>();
        clickSource = clickSoundObj.GetComponent<AudioSource>();
    }

    private void InputClipData()
    {
        bgmSource.clip = bgmClip;
        failedSource.clip = matchFailedClip;
        successSource.clip = matchSuccessClip;
        clickSource.clip = clickButtonClip;
    }


    public void SoundPlayBGM(float delayTIme)           //BGM 음악 실행
    {
        Invoke(nameof(InvokePlayBGM), delayTIme);
    }

    public void SoundPlayMatchFailed(float delayTIme)   //매치 실패 효과음 실행
    {
        Invoke(nameof(InvokePlayMatchFailed), delayTIme);
    }

    public void SoundPlayMatchSuccess(float delayTIme)  //매치 성공 효과음 실행
    {
        Invoke(nameof(InvokePlayMatchSuccess), delayTIme);
    }

    public void SoundPlayClick(float delayTIme)         //클릭 효과음 실행
    {
        Invoke(nameof(InvokePlayClick), delayTIme);
    }

    private void InvokePlayBGM()
    {
        bgmSource.Play();
    }

    private void InvokePlayMatchFailed()
    {
        failedSource.Play();
    }

    private void InvokePlayMatchSuccess()
    {
        successSource.Play();
    }

    private void InvokePlayClick()
    {
        clickSource.Play();
    }
}
