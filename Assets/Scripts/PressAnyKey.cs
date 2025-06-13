using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    Text text;
    float alpha = 0f; // 알파값을 조절하기 위한 변수
    float speed = 2f; // 알파값 변화 속도
    float customTime = 0f; // 독립적인 시간 계산을 위한 변수

    void Start()
    {
        text = GetComponent<Text>();
        Time.timeScale = 1f;

        // 텍스트 초기화
        if (text != null)
        {
            Color color = text.color;
            color.a = 0f; // 알파값 초기화
            text.color = color;
        }

        // 알파값 조절 Coroutine 시작
        StartCoroutine(FadeInAndBlink());
    }

    IEnumerator FadeInAndBlink()
    {
        // 1초 대기
        yield return new WaitForSeconds(1f);

        // 알파값 반짝임 시작
        while (true)
        {
            customTime += Time.deltaTime * speed;

            // 알파값 계산 (0~1 범위로 변동)
            alpha = Mathf.Abs(Mathf.Sin(customTime)); // 0에서 시작하여 반짝거리도록 설정

            // 텍스트의 색상 업데이트
            if (text != null)
            {
                Color color = text.color;
                color.a = alpha;
                text.color = color;
            }

            yield return null; // 다음 프레임까지 대기
        }
    }
}
