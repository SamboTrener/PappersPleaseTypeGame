using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button continueButton;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OpenPauseWindow);
        continueButton.onClick.AddListener(ClosePauseWindow);
        gameObject.SetActive(false);
    }

    void OpenPauseWindow()
    {
        GameManager.Instance.PauseGame();
        pauseButton.interactable = false;
        gameObject.SetActive(true);
    }

    void ClosePauseWindow()
    {
        GameManager.Instance.ContinueGame();
        pauseButton.interactable = true;
        gameObject.SetActive(false);
    }
}
