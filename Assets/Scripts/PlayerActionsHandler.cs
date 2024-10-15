using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionsHandler : MonoBehaviour
{
    [SerializeField] Button acceptButton;
    [SerializeField] Button declineButton;

    private void Awake()
    {
        acceptButton.onClick.AddListener(AcceptEmployee);
        declineButton.onClick.AddListener(DeclineEmployee);
    }

    void AcceptEmployee()
    {
        ShiftManager.Instance.ContinueShiftWithPlayerActions(true);
    }

    void DeclineEmployee()
    {
        ShiftManager.Instance.ContinueShiftWithPlayerActions(false);
    }
}
