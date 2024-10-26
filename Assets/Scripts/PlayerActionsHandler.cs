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
        SoundManager.Instance.PlayAcceptSound();
        if (GameManager.Instance.IsLastShift && ShiftManager.Instance.IsLastCharacter)
        {
            GameManager.Instance.EndGame(false);
        }
        else
        {
            ShiftManager.Instance.ContinueShiftWithPlayerActions(true);
        }
    }

    void DeclineEmployee()
    {
        SoundManager.Instance.PlayDeclineSound();
        if (GameManager.Instance.IsLastShift && ShiftManager.Instance.IsLastCharacter)
        {
            GameManager.Instance.EndGame(true);
        }
        else
        {
            ShiftManager.Instance.ContinueShiftWithPlayerActions(false);
        }
    }
}
