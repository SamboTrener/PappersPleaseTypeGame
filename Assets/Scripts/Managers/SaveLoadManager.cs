using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager 
{
    static ShiftSO currentShiftName;
    static DifficultyLevel difficultyLevel;

    public static ShiftSO GetCurrentShift() => currentShiftName;

    public static void SetCurrentShiftName(ShiftSO shift)
    {
        currentShiftName = shift;
        //Yg.SaveProgress();
    }

    public static void SetDifficultyLevel(DifficultyLevel difficultyLevelToSave)
    {
        difficultyLevel = difficultyLevelToSave;
        //Yg.SaveProgress();
    }

    public static DifficultyLevel GetDifficultyLevel() => difficultyLevel;
}
