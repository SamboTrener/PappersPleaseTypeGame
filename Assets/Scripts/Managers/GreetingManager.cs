using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreetingManager : MonoBehaviour
{
    public static GreetingManager Instance { get; private set; }

    [SerializeField] string[] validGreetings;
    [SerializeField] string[] invalidGreetings;

    private void Awake()
    {
        Instance = this;
    }

    public string GetRandomInvalidGreeting() => invalidGreetings[Random.Range(0, invalidGreetings.Length - 1)];
    public string GetRandomValidGreeting() => validGreetings[Random.Range(0, validGreetings.Length - 1)];
}

