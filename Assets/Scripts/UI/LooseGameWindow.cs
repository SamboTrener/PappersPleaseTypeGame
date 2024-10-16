using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LooseGameWindow : MonoBehaviour
{
    public static LooseGameWindow Instance { get; private set; }

    [SerializeField] Button againButton;
    [SerializeField] Button backToMenuButton;
    [SerializeField] TextMeshProUGUI looseText;

    private void Awake()
    {
        Instance = this;
        againButton.onClick.AddListener(RestartShift);
        backToMenuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        gameObject.SetActive(false);
    }

    void RestartShift()
    {
        SceneManager.LoadScene("Game");
        gameObject.SetActive(false);
    }

    public IEnumerator LooseGameWithMessageAfterWait(string message)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        gameObject.SetActive(true);
        looseText.text = message;
    }
}
