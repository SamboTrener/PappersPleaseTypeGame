using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FullDescrMenu : MonoBehaviour
{
    public static FullDescrMenu Instance { get; private set; }

    [SerializeField] Image photo;
    [SerializeField] TextMeshProUGUI fullDescr;
    [SerializeField] Button fullDescrButton;

    private void Awake()
    {
        Instance = this;
        fullDescrButton.onClick.AddListener(() => gameObject.SetActive(true));
        gameObject.SetActive(false);
    }

    public void FillDescrMenu(EmployeeSO employeeSO)
    {
        photo.sprite = employeeSO.baseSprite;
        fullDescr.text = employeeSO.fullDescription;
    }
}
