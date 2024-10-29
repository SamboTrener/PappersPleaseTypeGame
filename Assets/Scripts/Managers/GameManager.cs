using System.Collections;
using System.Linq;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] ShiftListSO shifts;
    [SerializeField] float standartTimeToWait;

    public DifficultyLevel DifficultyLevel { get; private set; }

    public float StandartTimeToWait => standartTimeToWait;

    public bool IsLastShift { get; private set; } = false;

    int lastShiftID;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        YandexGame.StopTheGameEvent += PauseGame;
        YandexGame.StartTheGameEvent += ContinueGame;
    }

    private void Start()
    {
        lastShiftID = shifts.shifts.Last().ID;
        DifficultyLevel = SaveLoadManager.GetDifficultyLevel();
        var shiftToStart = shifts.shifts.FirstOrDefault(shift => shift.ID == SaveLoadManager.GetCurrentShiftID());
        StartCurrentShift(shiftToStart);
    }

    public void StartNextShift()
    {
        SetIsLastShift();
        var currentShiftID = SaveLoadManager.GetCurrentShiftID();
        YGManager.SendEndShiftMetrica(currentShiftID, SaveLoadManager.GetDifficultyLevel());
        for (int i = 0; i < shifts.shifts.Count; i++)
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

    public void StartCurrentShift(ShiftSO shiftSO)
    {
        SetIsLastShift();
        ShiftManager.Instance.StartShift(shiftSO);
    }

    void SetIsLastShift()
    {
        if (lastShiftID == SaveLoadManager.GetCurrentShiftID())
        {
            IsLastShift = true;
            Debug.Log("isLastShift = true");
        }
    }

    public void EndGame(bool isFactoryEnding)
    {
        YGManager.SendEndGameMetrica(isFactoryEnding);
        if (!isFactoryEnding)
        {
            var brokenEmployeeSos = EmployeeManager.Instance.GetAllEmployeeSOsWithBrokenSprite();
            StartCoroutine(CharacterSpawner.Instance.EndGameWithSpawnAllAnomalied(brokenEmployeeSos));
        }
        else
        {
            IronCurtain.Instance.OnIronCurtainDown?.Invoke();
            ShiftManager.Instance.MoveCurrentCharacter(false);
            StartCoroutine(EndGameWindow.Instance.ShowGameEndWindowAfterWait(true));
        }
        SaveLoadManager.SaveCurrentShiftToCompleted();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        SoundManager.Instance.PauseSounds();
        MusicManager.Instance.PauseMusic();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.UnPauseSounds();
        MusicManager.Instance.UnPauseMusic();
    }
}
