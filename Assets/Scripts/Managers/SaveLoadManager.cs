using System.Linq;
using YG;

public static class SaveLoadManager
{
    public static void SaveCurrentShiftToCompleted()
    {
        var shiftCompletedBefore = YandexGame.savesData.completedShifts.FirstOrDefault(shiftInfo => shiftInfo.ID == GetCurrentShiftID());
        if (shiftCompletedBefore != null)
        {
            if (shiftCompletedBefore.MaxCompletedDifficultyLevel < GetDifficultyLevel())
            {
                shiftCompletedBefore.MaxCompletedDifficultyLevel = GetDifficultyLevel();
            }
        }
        else
        {
            var shiftToSaveInfo = new ShiftSaveInfo(GetCurrentShiftID(), GetDifficultyLevel());
            YandexGame.savesData.completedShifts.Add(shiftToSaveInfo);
        }

        YandexGame.SaveProgress();
    }

    public static int GetMostHighCompletedShiftID()
    {
        if (YandexGame.savesData.completedShifts.Count > 0)
        {
            return YandexGame.savesData.completedShifts.OrderByDescending(shift => shift.ID).First().ID;
        }
        else 
        {
            return -1;  //Пока костыляем
        }
    }


    public static bool IsShiftCompleted(ShiftSO shift)
    {
        foreach (var shiftInfo in YandexGame.savesData.completedShifts)
        {
            if (shift.ID == shiftInfo.ID)
            {
                return true;
            }
        }
        return false;
    }

    public static ShiftSaveInfo GetCompletedShiftInfoByID(int id) =>
        YandexGame.savesData.completedShifts.FirstOrDefault(shiftInfo => shiftInfo.ID == id);


    public static int GetCurrentShiftID() => YandexGame.savesData.currentShiftID;

    public static void SetCurrentShiftID(int shiftID)
    {
        YandexGame.savesData.currentShiftID = shiftID;
        YandexGame.SaveProgress();
    }

    public static void SetDifficultyLevel(DifficultyLevel difficultyLevelToSave)
    {
        YandexGame.savesData.difficultyLevel = difficultyLevelToSave;
        YandexGame.SaveProgress();
    }

    public static DifficultyLevel GetDifficultyLevel() => YandexGame.savesData.difficultyLevel;
}
