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
        var shiftToStart = shifts.shifts.FirstOrDefault(shift => shift.ID == SaveLoadManager.GetCurrentShiftID());
        StartCurrentShift(shiftToStart);
    }

    public void StartNextShift()
    {
        if(shifts.shifts.Count > 0)
        {
            var currentShiftID = SaveLoadManager.GetCurrentShiftID();
            for(int i = 0; i < shifts.shifts.Count; i++)
            {
                if (shifts.shifts[i].ID == currentShiftID)
                {
                    Debug.Log($"i = {i}");
                    currentShiftID = i + 1;
                    Debug.Log(currentShiftID);
                    SaveLoadManager.SetCurrentShiftID(currentShiftID);
                    StartCurrentShift(shifts.shifts[currentShiftID]);
                    break;
                }
            }
        }
        else
        {
            //Game end
        }
    }

    public void StartCurrentShift(ShiftSO shiftSO)
    {
        Debug.Log($"shift ID = {shiftSO.ID}");
        ShiftManager.Instance.StartShift(shiftSO);
    }
}
