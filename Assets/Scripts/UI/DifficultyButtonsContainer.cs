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
