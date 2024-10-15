using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] List<ShiftSO> shifts;
    [SerializeField] float standartTimeToWait;

    public DifficultyLevel DifficultyLevel { get; private set; }

    public float StandartTimeToWait => standartTimeToWait;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame(DifficultyLevel difficultyLevel)
    {
        DifficultyLevel = difficultyLevel;
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
