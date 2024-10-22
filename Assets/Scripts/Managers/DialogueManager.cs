using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

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
        validGreetings = new string[] { "����� ������!", "�� ����������� �����!", "������������ ��������!", "����� ���� �����!", "���������� �����!", "�� ��, ��� ������ ��� �����!" };
        invalidGreetings = new string[] { "����� - ��� ��� ������!","� ����� �����!","� ���� ������� ������","� ���� ��������� ������", "� ���� ������",
            "� ������", "������", "������ ������ ������", "����� ���� �� ������", "*����������������� ����������*", "������������, ������� ������!",
            "������ ����, ������!", "������ ����, �������!", "� �������, ��� � ��, � �� ���� ����������?", "� ��� ��������!",
            "� ���������, ��������!", "�. ����. ������.", "�����. ��, � ������� �� �����. �������� �����!", "������ ����", "����� �����!",
            "����� �����������!", "�� ������ �����!", "�� ������� ����� �����!", "������ ����� ����� � ���!", "� ������� ������� ���� �����.",
            "��� ����� ����� ������", "������� � ������?","� �����","���� ����, ���� ��� ������","����� ������ �����","� ���� ������ ��� �������",
            "�� ���������� �����","���������, ���������, ���������","����� �������","��� �������� ������","���� ���� � ����� �����",
            "�� �������� �����","������ �����","�� ��������� �����","������ ������� ���","�������� �� ����������","�� ���� ������� ���� ����� �� �����?",
            "�� ��� ���� �������","������� ����?","��� ������, ��� ������","�� ������ � ����","�� ����� ���","�� �� ���������, ��� ������� ���", 
            "����� �������", "���, ���������? �� �����, � ����. � ���� �� �����", "��� ����, ��� �� ���, ���� ����� �� ����" ,
            "� ��� ���� �����? ������� ���� � �����!", "� ���� ���� ��������!", "����� ��� �����!", "������ ������ � ��� ������!" };
    }

    private void Start()
    {
        nextCueButton.onClick.AddListener(() => OnNextCueButtonPressed?.Invoke());
    }

    public void ShowNextCueButton() => nextCueButton.gameObject.SetActive(true);
    public void HideNextCueButton() => nextCueButton.gameObject.SetActive(false);

    public string GetRandomInvalidGreeting() => invalidGreetings[UnityEngine.Random.Range(0, invalidGreetings.Length)];
    public string GetRandomValidGreeting() => validGreetings[UnityEngine.Random.Range(0, validGreetings.Length)];
    public string[] GetAllValidGreetings() => validGreetings;
}

