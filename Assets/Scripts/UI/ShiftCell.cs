using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShiftCell : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI shiftName;
    [SerializeField] Image isCompletedImage;
    Button playButton;

    public void MapShiftParameters(ShiftSO shiftSO)
    {
        shiftName.text = shiftSO.ShiftName;
        if (shiftSO.isCompleted)
        {
            isCompletedImage.gameObject.SetActive(true);
        }
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(() => LoadSceneWithShift(shiftSO));
    }

    void LoadSceneWithShift(ShiftSO shiftSO)
    {
        SaveLoadManager.SetCurrentShiftName(shiftSO);
        SceneManager.LoadScene("Game");
    }
}
