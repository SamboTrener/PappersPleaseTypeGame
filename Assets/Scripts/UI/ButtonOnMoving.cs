using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnMoving : MonoBehaviour
{
    public static Action OnEmployeeMoving;
    public static Action OnEmployeeStopped;
    Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        OnEmployeeMoving += DisableThis;
        OnEmployeeStopped += EnableThis;
    }

    private void OnDisable()
    {
        OnEmployeeMoving -= DisableThis;
        OnEmployeeStopped -= EnableThis;
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
