using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer 연결
    public Slider bgmSlider;      // BGM 슬라이더 연결
    public Slider sfxSlider;      // SFX 슬라이더 연결

    private void Start()
    {
        // 초기 슬라이더 값 설정 (기본값: 1)
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);

        // 슬라이더 이벤트 리스너 추가
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetBGMVolume(float value)
    {
        // BGM 볼륨 설정
        if (value <= 0.01f)
        {
            audioMixer.SetFloat("BGMVolume", -80f); // 음소거
        }
        else
        {
            audioMixer.SetFloat("BGMVolume", Mathf.Log10(value) * 20);
        }

        // 값 저장
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        // SFX 볼륨 설정
        if (value <= 0.01f)
        {
            audioMixer.SetFloat("SFXVolume", -80f); // 음소거
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        }

        // 값 저장
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}