using System;
using System.Collections.Generic;

[Serializable]
public class SaveInfo 
{
    public int currentShiftID;
    public DifficultyLevel difficultyLevel;
    public List<ShiftSaveInfo> completedShifts;

    public SaveInfo()
    {
        difficultyLevel = DifficultyLevel.Hard;
        completedShifts = new List<ShiftSaveInfo>();
    }

    public SaveInfo(int currentShiftID, DifficultyLevel difficultyLevel, List<ShiftSaveInfo> completedShifts)
    {
        this.currentShiftID = currentShiftID;
        this.difficultyLevel = difficultyLevel;
        this.completedShifts = completedShifts;
    }
}
