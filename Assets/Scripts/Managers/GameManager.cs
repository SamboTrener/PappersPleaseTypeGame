using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] ShiftListSO shifts;
    [SerializeField] float standartTimeToWait;

    public DifficultyLevel DifficultyLevel { get; private set; }

    public float StandartTimeToWait => standartTimeToWait;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DifficultyLevel = SaveLoadManager.GetDifficultyLevel();
        StartCurrentShift(SaveLoadManager.GetCurrentShift());
    }

    public void StartNextShift()
    {
        if(shifts.shifts.Count > 0)
        {
            var currentShift = SaveLoadManager.GetCurrentShift();
            StartCurrentShift(shifts.shifts.FirstOrDefault(shift => shift.ShiftName == currentShift.ShiftName));
        }
        else
        {
            //Game end
        }
    }

    public void StartCurrentShift(ShiftSO shiftSO)
    {
        ShiftManager.Instance.StartShift(shiftSO);
    }
}
