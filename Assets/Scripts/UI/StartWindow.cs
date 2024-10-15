using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
    [SerializeField] Button easyStartButton;
    [SerializeField] Button mediumStartButton;
    [SerializeField] Button hardStartButton;

    private void Start()
    {
        easyStartButton.onClick.AddListener(() => StartGame(DifficultyLevel.Easy));
        mediumStartButton.onClick.AddListener(() => StartGame(DifficultyLevel.Medium));
        hardStartButton.onClick.AddListener(() => StartGame(DifficultyLevel.Hard));
    }

    void StartGame(DifficultyLevel difficultyLevel)
    {
        GameManager.Instance.StartGame(difficultyLevel);
        gameObject.SetActive(false);
    }
}
