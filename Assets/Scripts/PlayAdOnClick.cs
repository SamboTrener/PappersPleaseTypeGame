using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PlayAdOnClick : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ShowFullScreenAd);
    }

    void ShowFullScreenAd()
    {
        YandexGame.FullscreenShow();
    }
}
