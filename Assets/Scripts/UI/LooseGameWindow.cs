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
    [SerializeField] TextMeshProUGUI looseText;

    private void Awake()
    {
        Instance = this;
        againButton.onClick.AddListener(RestartShift);
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

    public IEnumerator LooseGameWithAnimation(string message)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        GameEndAnimator.Instance.OnGameEndAnimation?.Invoke();
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);
        looseText.text = message;
    }
}
