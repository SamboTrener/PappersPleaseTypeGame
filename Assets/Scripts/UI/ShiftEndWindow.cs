using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShiftEndWindow : MonoBehaviour
{
    public static ShiftEndWindow Instance { get; private set; }

    [SerializeField] TextMeshProUGUI monstersKilledStatistic;
    [SerializeField] TextMeshProUGUI employeeAcceptedStatistic;
    [SerializeField] Button goNextButton;

    private void Awake()
    {
        Instance = this;
        goNextButton.onClick.AddListener(StartNextShift);
        gameObject.SetActive(false);
    }

    public IEnumerator ShowShiftEndWindowAfterWait(int monstersKilled, int employeeAccepted)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        if(YGManager.GetLanguageStr() == "ru")
        {
            monstersKilledStatistic.text = $"Вторженцев ликвидировано : {monstersKilled}";
            employeeAcceptedStatistic.text = $"Сотрудников пропущено : {employeeAccepted}";
        }
        else
        {
            monstersKilledStatistic.text = $"Intruders eliminated  : {monstersKilled}";
            employeeAcceptedStatistic.text = $"Employees passed : {employeeAccepted}";
        }
        gameObject.SetActive(true);
    }

    void StartNextShift()
    {
        GameManager.Instance.StartNextShift();
        gameObject.SetActive(false);
    }
}
