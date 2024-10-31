using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuOnButtonClick : MonoBehaviour
{
    Button button;
    [SerializeField]GameObject menuToOpen;

    private void Awake()
    {
        button = GetComponentInParent<Button>();

        button.onClick.AddListener(() => menuToOpen.SetActive(true));
    }
}
