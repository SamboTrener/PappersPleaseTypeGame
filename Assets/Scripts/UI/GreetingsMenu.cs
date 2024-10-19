using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GreetingsMenu : MonoBehaviour
{
    public static GreetingsMenu Instance { get; private set; }

    [SerializeField] Button openGreetingsMenuButton;
    [SerializeField] TextMeshProUGUI allowedGreetingsText;

    private void Awake()
    {
        Instance = this;
        openGreetingsMenuButton.onClick.AddListener(() => gameObject.SetActive(true));
    }

    private void Start()
    {
        WriteAllowedGreetings();
        gameObject.SetActive(false);
    }

    void WriteAllowedGreetings()
    {
        var greetings = DialogueManager.Instance.GetAllValidGreetings();
        for(int i = 0; i < greetings.Length; i++)
        {
            allowedGreetingsText.text += $"{greetings[i]}\n";
        }
    }
}
