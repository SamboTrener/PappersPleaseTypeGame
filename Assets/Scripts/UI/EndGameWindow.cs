using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameWindow : MonoBehaviour
{
    public static EndGameWindow Instance { get; private set; }

    [SerializeField] TextMeshProUGUI finalDescriptionText;
    [SerializeField] GameObject goodEndingObject;
    [SerializeField] GameObject badEningObject;


    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowGameEndWindow(bool isGoodEnding) 
    {
        gameObject.SetActive(true);
        if (isGoodEnding)
        {
            goodEndingObject.SetActive(true);
            finalDescriptionText.text = "������� ��������";
        }
        else
        {
            badEningObject.SetActive(true);
            finalDescriptionText.text = "������ ��������";
        }
    }

    public IEnumerator ShowGameEndWindowAfterWait(bool isGoodEnding)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        ShowGameEndWindow(isGoodEnding);
    }
}
