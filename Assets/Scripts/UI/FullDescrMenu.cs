using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FullDescrMenu : MonoBehaviour
{
    public static FullDescrMenu Instance { get; private set; }

    [SerializeField] TextMeshProUGUI fullDescr;
    [SerializeField] Button fullDescrButton;

    private void Awake()
    {
        Instance = this;
        fullDescrButton.onClick.AddListener(OpenFullDescrMenu);
        gameObject.SetActive(false);
    }

    void OpenFullDescrMenu()
    {
        SoundManager.Instance.PlayPaperSound(fullDescrButton.gameObject.transform.position);
        gameObject.SetActive(true);
    }

    public void FillDescrMenu(EmployeeSO employeeSO)
    {
        fullDescr.text = employeeSO.fullDescription;
    }
}
