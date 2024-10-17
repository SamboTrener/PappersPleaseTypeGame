using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] ShiftListSO shifts;
    [SerializeField] float standartTimeToWait;

    public DifficultyLevel DifficultyLevel { get; private set; }

    public float StandartTimeToWait => standartTimeToWait;

    public bool IsLastShift { get; private set; } = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DifficultyLevel = SaveLoadManager.GetDifficultyLevel();
        var shiftToStart = shifts.shifts.FirstOrDefault(shift => shift.ID == SaveLoadManager.GetCurrentShiftID());
        StartCurrentShift(shiftToStart);
    }

    public void StartNextShift()
    {
        if(shifts.shifts.Count > 1) //Все смены обычные до последней 
        {
            var currentShiftID = SaveLoadManager.GetCurrentShiftID();
            for(int i = 0; i < shifts.shifts.Count; i++)
            {
                if (shifts.shifts[i].ID == currentShiftID)
                {
                    currentShiftID = i + 1;
                    SaveLoadManager.SetCurrentShiftID(currentShiftID);
                    StartCurrentShift(shifts.shifts[currentShiftID]);
                    break;
                }
            }
        }
        else
        {
            IsLastShift = true;
        }
    }

    public void StartCurrentShift(ShiftSO shiftSO)
    {
        ShiftManager.Instance.StartShift(shiftSO);
    }
}
