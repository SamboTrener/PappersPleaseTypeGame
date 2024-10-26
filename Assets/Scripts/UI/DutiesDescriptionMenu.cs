using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DutiesDescriptionMenu : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Transform unavailableDutyPrefab;
    [SerializeField] Transform mediumLevelDutie;
    [SerializeField] Transform hardLevelDutie;

    private void Awake()
    {
        button.onClick.AddListener(OpenMenu);

        if(SaveLoadManager.GetDifficultyLevel() == DifficultyLevel.Easy)
        {
            Instantiate(unavailableDutyPrefab, mediumLevelDutie);
            Instantiate(unavailableDutyPrefab, hardLevelDutie);
        }
        else if(SaveLoadManager.GetDifficultyLevel() == DifficultyLevel.Medium)
        {
            Instantiate(unavailableDutyPrefab, hardLevelDutie);
        }

        gameObject.SetActive(false);
    }

    void OpenMenu()
    {
        SoundManager.Instance.PlayPaperSound(button.gameObject.transform.position);
        gameObject.SetActive(true);
    }
}
