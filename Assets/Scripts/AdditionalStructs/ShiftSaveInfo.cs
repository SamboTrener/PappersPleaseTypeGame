using System;

[Serializable]
public class ShiftSaveInfo
{
    public ShiftSaveInfo(int ID, DifficultyLevel difficultyLevel)
    {
        this.ID = ID;
        this.MaxCompletedDifficultyLevel = difficultyLevel;
    }

    public int ID;
    public DifficultyLevel MaxCompletedDifficultyLevel;
}
