using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionsHandler : MonoBehaviour
{
    [SerializeField] Button acceptButton;
    [SerializeField] Button declineButton;
    [SerializeField] Button passButton;

    private void Awake()
    {
        acceptButton.onClick.AddListener(AcceptEmployee);
        declineButton.onClick.AddListener(DeclineEmployee);
        passButton.onClick.AddListener(OpenPassWindow);
    }

    void OpenPassWindow()
    {

    }

    void AcceptEmployee()
    {
        ShiftManager.Instance.CurrentEmployee.GetComponent<EmployeeMover>().MoveRight(true);
        StartCoroutine(ShiftManager.Instance.NextEmployeeAfterWait());
    }

    void DeclineEmployee()
    {
        ShiftManager.Instance.CurrentEmployee.GetComponent<EmployeeMover>().MoveLeft(true);
        StartCoroutine(ShiftManager.Instance.NextEmployeeAfterWait());
    }
}
