using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] string[] validGreetings;
    [SerializeField] string[] invalidGreetings;

    [SerializeField] GameObject dialogueWindow;
    [SerializeField] TextMeshProUGUI dialogueText;

    public GameObject GetDialogueWindow() => dialogueWindow;
    public TextMeshProUGUI GetDialogueText() => dialogueText;

    private void Awake()
    {
        Instance = this;
    }

    public string GetRandomInvalidGreeting() => invalidGreetings[Random.Range(0, invalidGreetings.Length - 1)];
    public string GetRandomValidGreeting() => validGreetings[Random.Range(0, validGreetings.Length - 1)];
}

