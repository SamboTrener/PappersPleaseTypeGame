using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
    [SerializeField] Button startGameButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        GameManager.Instance.StartGame();
        gameObject.SetActive(false);
    }
}
