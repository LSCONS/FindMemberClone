using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject cardPref;
    public GameObject parentObject;

    void Start()
    {
        SettingCard();
    }


    /// <summary>
    /// 24장의 카드를 4 X 6의 크기로 배치하는 메서드
    /// </summary>
    private void SettingCard()
    {
        int[] arr = new int[24];

        for (int i = 0; i < 24; i++)
        {
            arr[i] = i % 12;
        }

        arr = arr.OrderBy(x => Random.Range(0f, 11f)).ToArray();
        GameManager.Instance.cardCount = arr.Length;

        for (int i = 0; i < 24; i++)
        {
            float x = i % 4 * 1.2f - 1.8f;
            float y = i / 4 * 1.4f - 4.0f;

            GameObject go = Instantiate(cardPref, new Vector3(x, y, 0), Quaternion.identity, parentObject.transform);

            go.GetComponent<Card>().Setting(arr[i]);
        }
    }
}
