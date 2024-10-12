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
        ShiftManager.Instance.CurrentEmployee.GetComponent<EmployeeMover>().MoveRight(true);
        ShiftManager.Instance.ContinueShift(true);
    }

    void DeclineEmployee()
    {
        ShiftManager.Instance.CurrentEmployee.GetComponent<EmployeeMover>().MoveLeft(true);
        ShiftManager.Instance.ContinueShift(false);
    }
}
