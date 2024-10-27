using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public static ShiftManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI textOnShiftStart;
   
    List<PlotCharacterSO> plotCharacters;
    int monstersKilled;
    int employeeAccepted;
    List<EmployeeSO> employeeSOs;
    CommonCharacter currentCharacter;
    int currentCharacterNumber = 0;

    public bool IsLastCharacter { get; private set; } = false;

    private void Awake()
    {
        Instance = this;
    }

    public void StartShift(ShiftSO shift)
    {
        employeeSOs = EmployeeManager.Instance.GetDailyListOfEmployees(shift.VisitersCount);

        plotCharacters = new List<PlotCharacterSO>(shift.plotCharacters);

        if(YGManager.GetLanguageStr() == "ru")
        {
            StartCoroutine(ShowTextForSeconds(shift.ShiftNameRu));
        }
        else
        {
            StartCoroutine(ShowTextForSeconds(shift.ShiftName));
        }


        if (TryGetPlotCharacter(out PlotCharacterSO plotCharacterSO))
        {
            StartCoroutine(StartPlotActionAfterWait(plotCharacterSO));
        }
        else
        {
            StartCoroutine(NextEmployeeAfterWait());
        }
    }

    public void ContinueShiftWithPlayerActions(bool isPreviousAccepted)
    {
        MoveCurrentCharacter(isPreviousAccepted);
        if (isPreviousAccepted != currentCharacter.HasPermission())
        {
            if (isPreviousAccepted == true)
            {
                if(YGManager.GetLanguageStr() == "ru")
                {
                    StartCoroutine(LooseGameWindow.Instance.LooseGameWithAnimation("Вы провалились, пропустив одного из (((них))). \"Объект\" вышел из под контроля." +
                                                                                    "Остаётся только гадать, какие ужасные последствия это за собой повлечет"));
                }
                else
                {
                    StartCoroutine(LooseGameWindow.Instance.LooseGameWithAnimation("You failed by letting one of (((them))) in. The \"Object\" is out of control." +
                                        "We can only guess what terrible consequences this will entail"));
                }
            }
            else
            {
                IronCurtain.Instance.OnIronCurtainDown?.Invoke();
                currentCharacter.StopPlayingSound();
                if(YGManager.GetLanguageStr() == "ru")
                {
                    StartCoroutine(LooseGameWindow.Instance.LooseGameWithMessageAfterWait("Вы проявили излишнюю подозрительность и ликвидировали сотрудника Завода."
                                                    + " В конце смены вас встретила всенародная милиция. Завтра вы будете осуждены за убийство и подрывную деятельность. Слава Заводу!"));
                }
                else
                {
                    StartCoroutine(LooseGameWindow.Instance.LooseGameWithMessageAfterWait("You showed excessive suspicion and eliminated an employee of the Factory." + 
                        " At the end of the shift, you were met by the national police. Tomorrow you will be convicted of murder and subversion. Glory to the Factory!"));
                }
            }
            return;
        }
        else
        {
            if (isPreviousAccepted == true)
            {
                employeeAccepted++;
            }
            else
            {
                IronCurtain.Instance.OnIronCurtainDown?.Invoke();
                currentCharacter.StopPlayingSound();
                monstersKilled++;
            }
        }
        ContinueShift();
    }


    public void ContinueShift()
    {
        if (employeeSOs.Count > 0)
        {
            currentCharacterNumber++;
            if (TryGetPlotCharacter(out PlotCharacterSO plotCharacterSO))
            {
                if (plotCharacterSO == plotCharacters.Last())
                {
                    IsLastCharacter = true;
                }
                StartCoroutine(StartPlotActionAfterWait(plotCharacterSO));
            }
            else
            {
                StartCoroutine(NextEmployeeAfterWait());
            }
        }
        else
        {
            CompleteShift();
        }
    }

    void CompleteShift()
    {
        SaveLoadManager.SaveCurrentShiftToCompleted();
        currentCharacterNumber = 0;
        StartCoroutine(ShiftEndWindow.Instance.ShowShiftEndWindowAfterWait(monstersKilled, employeeAccepted));
        monstersKilled = 0;
        employeeAccepted = 0;
    }

    public void CompleteShiftTemp() => CompleteShift();

    bool TryGetPlotCharacter(out PlotCharacterSO outPlotCharacter)
    {
        foreach (var plotCharacter in plotCharacters)
        {
            if (plotCharacter.orderOfComming == currentCharacterNumber)
            {
                outPlotCharacter = plotCharacter;
                return true;
            }
        }
        outPlotCharacter = null;
        return false;
    }

    IEnumerator StartPlotActionAfterWait(PlotCharacterSO plotCharacterSO)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        currentCharacter = CharacterSpawner.Instance.SpawnPlotCharacterWithSO(plotCharacterSO);
    }

    public void MoveCurrentCharacter(bool shouldMoveRight)
    {
        currentCharacter.Move(shouldMoveRight);
    }

    void NextEmployee()
    {
        var next = employeeSOs.FirstOrDefault();
        employeeSOs.Remove(next);
        currentCharacter = CharacterSpawner.Instance.SpawnEmployeeWithSO(next, false);
    }

    IEnumerator NextEmployeeAfterWait()
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait); 
        NextEmployee();
    }

    IEnumerator ShowTextForSeconds(string shiftName)
    {
        ButtonInteractableController.OnButtonsDisable?.Invoke();
        textOnShiftStart.text = shiftName;
        textOnShiftStart.gameObject.SetActive(true);
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        textOnShiftStart.gameObject.SetActive(false);
        ButtonInteractableController.OnButtonsEnable?.Invoke();
    }
}
