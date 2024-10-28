using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    string[] validGreetingsRu;
    string[] invalidGreetingsRu;
    string[] validGreetings;
    string[] invalidGreetings;

    [SerializeField] GameObject dialogueWindow;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Button nextCueButton;

    public Action OnNextCueButtonPressed;

    public GameObject GetDialogueWindow() => dialogueWindow;
    public TextMeshProUGUI GetDialogueText() => dialogueText;

    private void Awake()
    {
        Instance = this;
        validGreetingsRu = new string[] { "����� ������!", "�� ����������� �����!", "������������ ��������!", "����� ���� �����!",
            "���������� �����!", "�� ��, ��� ������ ��� �����!" };

        validGreetingsRu = new string[] { "Glory to the Factory!", "Long live the Factory!", "We are mechanizing society!", 
            "The Factory will live!", "The Factory will rise!", "We are the ones who make the world a better place!" };

        invalidGreetingsRu = new string[] { "����� - ��� ��� ������!","� ����� �����!","� ���� ������� ������","� ���� ��������� ������", "� ���� ������",
            "� ������", "������", "������ ������ ������", "����� ���� �� ������", "*����������������� ����������*", "������������, ������� ������!",
            "������ ����, ������!", "������ ����, �������!", "� �������, ��� � ��, � �� ���� ����������?", "� ��� ��������!",
            "� ���������, ��������!", "�. ����. ������.", "�����. ��, � ������� �� �����. �������� �����!", "������ ����!", "����� �����!",
            "����� �����������!", "�� ������ �����!", "�� ������� ����� �����!", "������ ����� ����� � ���!", "� ������� ������� ���� �����.",
            "��� ����� ����� ������", "������� � ������?","� �����","���� ����, ���� ��� ������","����� ������ �����!","� ���� ������ ��� �������",
            "�� ���������� �����!","���������, ���������, ���������","����� �������!","��� �������� ������!","���� ���� � ����� �����!",
            "�� �������� �����!","������ �����!","�� ��������� �����!","������ ������� ���!","�������� �� ����������!","�� ���� ������� ���� ����� �� �����?",
            "�� ��� ���� �������","������� ����?","��� ������, ��� ������","�� ������ � ����!","�� ����� ���!","�� �� ���������, ��� ������� ���!", 
            "����� �������!", "���, ���������? �� �����, � ����. � ���� �� �����", "��� ����, ��� �� ���, ���� ����� �� ����" ,
            "� ��� ���� �����? ������� ���� � �����!", "� ���� ���� ��������!", "����� ��� �����!", "������ ������ � ��� ������!" };

        invalidGreetings = new string[] { "Factory is my home!", "I love the Factory!", "I want to see the Object", "I want to touch the Object", 
            "I want the Object", "I am the Object", "OBJECT", "OBJECT OBJECT OBJECT", "Let me go to the object", "*inarticulate mumbling*",
            "Hello, comrade watchman!", "Good morning, watchman!", "Good morning, human!", "I'm a human being like you, and will you let me in?", 
            "I am the employee!", "I'm an inspector, let me in!", "I.WANT.LET.IN.", "Factory! I work factory! Factory work!", "Good morning!",
            "Will be Factory!", "Glory to the Enterprice!", "We make better!", "We are the ones who make the Factory a better place!",
            "The Factory will be better off under our leadership!", "I usual worker this Factory", "I really need to get inside!",
            "Will you let me use the toilet?", "I can hear it", "The sound... the sound is comming from here", "The Factory must fall!",
            "I see a rift above the Factory", "We will soar skyward!", "Absorb absorb absorb", "Glory to the Rift!", "Slave of a filthy factory!",
            "Stay quiet in your doghouse!", "We will bring life!", "Choose life", "We will break up the factory!", "The rift will envelop the world!",
            "Blossoming cannot be stopped!", "Do you hear that whisper at night too?", "We'll meet you outside", "Do you remember me?",
            "It's coming, it's close", "You will join us!", "You are the one of us!", "You don't understand what you're storing here!",
            "Glory to the office!", "Do you have a family? Let me go to my family", "I want to work for you too!", "Short live the Factory!",
            "The Factory will be great!"
        };
    }

    private void Start()
    {
        nextCueButton.onClick.AddListener(() => OnNextCueButtonPressed?.Invoke());
    }

    public void ShowNextCueButton() => nextCueButton.gameObject.SetActive(true);
    public void HideNextCueButton() => nextCueButton.gameObject.SetActive(false);

    public string GetRandomInvalidGreeting()
    {
        if(YGManager.GetLanguageStr() == "ru")
        {
            return invalidGreetingsRu[UnityEngine.Random.Range(0, invalidGreetingsRu.Length)];
        }
        else
        {
            return invalidGreetings[UnityEngine.Random.Range(0, invalidGreetingsRu.Length)];
        }
    }

    public string GetRandomValidGreeting()
    {
        if(YGManager.GetLanguageStr() == "ru")
        {
            return validGreetingsRu[UnityEngine.Random.Range(0, validGreetingsRu.Length)];
        }
        else
        {
            return validGreetings[UnityEngine.Random.Range(0, validGreetingsRu.Length)];
        }
    }
    public string[] GetAllValidGreetings()
    {
        return YGManager.GetLanguageStr() == "ru" ? validGreetingsRu : validGreetings;
    }  
}

