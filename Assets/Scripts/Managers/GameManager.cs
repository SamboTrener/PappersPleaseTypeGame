using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] List<ShiftSO> shifts;
    [SerializeField] float standartTimeToWait;

    public float StandartTimeToWait => standartTimeToWait;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        StartFirstShiftFromList();
    }

    public void StartNextShift()
    {
        shifts.Remove(shifts.First());
        if(shifts.Count > 0)
        {
            StartFirstShiftFromList();
        }
        else
        {
            //Game end
        }
    }

    public void StartFirstShiftFromList()
    {
        ShiftManager.Instance.StartShift(shifts.FirstOrDefault());
    }
}
