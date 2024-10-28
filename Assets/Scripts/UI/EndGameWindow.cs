using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameWindow : MonoBehaviour
{
    public static EndGameWindow Instance { get; private set; }

    [SerializeField] TextMeshProUGUI textContainer;
    [SerializeField] Image imageContainer;
    [SerializeField] Sprite[] factoryEndingSprites;
    [SerializeField] Sprite[] riftEndingSprites;
    [SerializeField] Button nextButton;
    [SerializeField] TextMeshProUGUI nextButtonText;

    string[] endingText;
    Sprite[] endingSprites;

    int iter;
    bool isFactoryEnding;


    private void Awake()
    {
        Instance = this;
        nextButton.onClick.AddListener(ShowNextEndingInfo);
        gameObject.SetActive(false);
    }

    public void ShowGameEndWindow(bool isFactoryEnding)
    {
        SoundManager.Instance.PlayGameEndSoundLooped();
        MusicManager.Instance.StopMusic();
        this.isFactoryEnding = isFactoryEnding;
        iter = -1;
        FillEndingData(isFactoryEnding);
        gameObject.SetActive(true);
        ShowNextEndingInfo();
    }

    void ShowNextEndingInfo()
    {
        ++iter;
        if (iter >= endingSprites.Length - 1 || iter >= endingText.Length - 1)
        {
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
            if (YGManager.GetLanguageStr() == "ru")
            {
                nextButtonText.text = isFactoryEnding ? "����� ������!" : "����� �������!";
            }
            else
            {
                nextButtonText.text = isFactoryEnding ? "Glory to the Factory!" : "Glory to the Rift!";
            }
        }
        textContainer.text = endingText[iter];
        imageContainer.sprite = endingSprites[iter];
    }

    void FillEndingData(bool isFactoryEnding)
    {
        if (YGManager.GetLanguageStr() == "ru")
        {
            if (isFactoryEnding)
            {
                endingText = new string[]
                {
                    "�� ������������� ������������� �������� ������������� ���������� ��� � ���������� ������� �������. " +
                    "����� ����������, ��� � ����� ��������  �� ������ �� ���� ������� � ��������������� ��������. " +
                    "����� ����� ����������, ������� ������, ��������� �� (((���))), ���������� ���������� �� �����.",
                    "�� ���������� ������ ����� ����� ����� � ��������� ���� ���������� ������� ������� ������� " +
                    "��� ������ ��������� ������������� ���������� ������.",
                    "�����, � ���� �������, ���� ������������ ������ �������� � ��������� ���� ������������ � ���������� ����� ���������",
                    "����� ������� ���������� ����������� ���, �������� �� ������� �������� � ���������� �������. " +
                    "��������������� ����� ����� �������� � ���, ��� ������������ ������ ���������� ������ ������������� ��� �������� " +
                    "����� �� ����������� ��������� � ������� �������� �����.",
                    "�� ����� ����������� �������� ���� ���� ���������� �������. " +
                    "�� ����� � ����������� �������� ��������, �� ���������� ������ ������ ��� ��������� �������� ��������� �� " +
                    "������� ������ ������� � 14 ������.",
                    "� ������� �� ���� ������ �� ����� ������, ����������� ��������� ��� ���������� ������ ���� ����� ����� �������. " +
                    "�� ��� ������ �������, ��� ��������� ���� ��� ������� � �������� ������� ����������� �����. " +
                    "�� ����� ����������� � ���������� �������� ������. �� ���� ��������� ����� �� ��������� ����� �������� ����� �� ����������������. " +
                    "����� ������!"
                };
                endingSprites = factoryEndingSprites;
            }
            else
            {
                endingText = new string[] { };
                endingSprites = riftEndingSprites;
            }
        }
        else
        {
            if (isFactoryEnding)
            {
                endingText = new string[] { };
                endingSprites = factoryEndingSprites;
            }
            else
            {
                endingText = new string[] { };
                endingSprites = riftEndingSprites;
            }
        }
    }

    public IEnumerator ShowGameEndWindowAfterWait(bool isGoodEnding)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        ShowGameEndWindow(isGoodEnding);
    }
}
