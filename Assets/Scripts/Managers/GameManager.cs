using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] List<ShiftSO> shifts;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        ShiftManager.Instance.StartShift(shifts.FirstOrDefault());
        shifts.Remove(shifts.FirstOrDefault());

       // EmployeeMover.Instance.MoveRight(false);
    }
}
