using System.IO;
using System.Linq;
using UnityEngine;

public static class SaveLoadManager
{
    static readonly string fileName = "saveInfo.json";
    static readonly string saveDataPath = Application.persistentDataPath + "/" + fileName;

    static SaveInfo saveInfo;

    static SaveLoadManager()
    {
        if(File.Exists(saveDataPath))
        {
            var sr = new StreamReader(saveDataPath);
            string json = sr.ReadToEnd();
            sr.Close();
            saveInfo = JsonUtility.FromJson<SaveInfo>(json);
        }
        else
        {
            saveInfo = new SaveInfo();
            string json = JsonUtility.ToJson(saveInfo);
            var sw = new StreamWriter(saveDataPath);
            sw.WriteLine(json);
            sw.Close();
        }
    }

    public static void SaveCurrentShiftToCompleted()
    {
        var shiftCompletedBefore = saveInfo.completedShifts.FirstOrDefault(shiftInfo => shiftInfo.ID == GetCurrentShiftID());

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
            saveInfo.completedShifts.Add(shiftToSaveInfo);
        }

        RewriteSave();
    }

    public static int GetMostHighCompletedShiftID()
    {
        if (saveInfo.completedShifts.Count > 0)
        {
            return saveInfo.completedShifts.OrderByDescending(shift => shift.ID).First().ID;
        }
        else 
        {
            return -1;  
        }
    }


    public static bool IsShiftCompleted(ShiftSO shift)
    {
        foreach (var shiftInfo in saveInfo.completedShifts)
        {
            if (shift.ID == shiftInfo.ID)
            {
                return true;
            }
        }
        return false;
    }

    public static ShiftSaveInfo GetCompletedShiftInfoByID(int id)
    {
        return saveInfo.completedShifts.FirstOrDefault(shiftInfo => shiftInfo.ID == id);
    }


    public static int GetCurrentShiftID()
    {
        return saveInfo.currentShiftID;
    }

    public static void SetCurrentShiftID(int shiftID)
    {
        saveInfo.currentShiftID = shiftID;

        RewriteSave();
    }

    public static void SetDifficultyLevel(DifficultyLevel difficultyLevelToSave)
    {
        saveInfo.difficultyLevel = difficultyLevelToSave;

        RewriteSave();
    }

    public static DifficultyLevel GetDifficultyLevel()
    {
        return saveInfo.difficultyLevel;
    }

    
    static void RewriteSave()
    {
        string json = JsonUtility.ToJson(saveInfo);
        var sw = new StreamWriter(saveDataPath);
        sw.WriteLine(json);
        sw.Close();
        saveInfo = JsonUtility.FromJson<SaveInfo>(json);
    }
}
