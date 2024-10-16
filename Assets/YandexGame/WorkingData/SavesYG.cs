
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int currentShiftID;
        public DifficultyLevel difficultyLevel;
        public List<ShiftSaveInfo> completedShifts;

        public SavesYG()
        {
            difficultyLevel = DifficultyLevel.Medium;
            completedShifts = new List<ShiftSaveInfo>();
        }
    }
}
