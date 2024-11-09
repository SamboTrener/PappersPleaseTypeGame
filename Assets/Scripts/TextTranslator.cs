using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTranslator : MonoBehaviour
{
    TextMeshProUGUI textField;
    [SerializeField] string ru;
    [SerializeField] string en;


    private void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
        //Достаю из сохранений язык и ставлю либо ру либо инглиш
    }
}
