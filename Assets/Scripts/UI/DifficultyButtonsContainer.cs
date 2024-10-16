using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonsContainer : MonoBehaviour
{
    [SerializeField] Button easyButton;
    [SerializeField] Button mediumButton;
    [SerializeField] Button hardButton;

    private void Awake()
    {
        easyButton.onClick.AddListener(() => ChooseDifficulty(DifficultyLevel.Easy, easyButton));
        mediumButton.onClick.AddListener(() => ChooseDifficulty(DifficultyLevel.Medium, mediumButton));
        hardButton.onClick.AddListener(() => ChooseDifficulty(DifficultyLevel.Hard, hardButton));
        DisableChoosenDifficultyButton();
    }

    void DisableChoosenDifficultyButton()
    {
        var currentDifficulty = SaveLoadManager.GetDifficultyLevel();

        switch (currentDifficulty) 
        {
            case DifficultyLevel.Easy:
                easyButton.interactable = false;
                break;
            case DifficultyLevel.Medium:
                mediumButton.interactable = false;
                break;
            case DifficultyLevel.Hard:
                hardButton.interactable = false;
                break;
        }
    }

    void ChooseDifficulty(DifficultyLevel difficultyLevel, Button button)
    {
        RefreshButtons();
        button.interactable = false;
        SaveLoadManager.SetDifficultyLevel(difficultyLevel);
    }

    void RefreshButtons()
    {
        easyButton.interactable = true;
        mediumButton.interactable = true;
        hardButton.interactable = true;
    }
}
