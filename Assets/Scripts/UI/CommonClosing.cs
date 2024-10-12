using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonClosing : MonoBehaviour
{
    [SerializeField] Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(CloseMenu);
    }

    private void OnEnable()
    {
        closeButton.gameObject.SetActive(true);
    }

    void CloseMenu()
    {
        closeButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
