using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableController : MonoBehaviour
{
    public static Action OnButtonsDisable;
    public static Action OnButtonsEnable;
    Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        OnButtonsDisable += DisableThis;
        OnButtonsEnable += EnableThis;
    }

    private void OnDisable()
    {
        OnButtonsDisable -= DisableThis;
        OnButtonsEnable -= EnableThis;
    }

    void DisableThis()
    {
        button.interactable = false;
    }

    void EnableThis()
    {
        button.interactable = true;
    }
}
