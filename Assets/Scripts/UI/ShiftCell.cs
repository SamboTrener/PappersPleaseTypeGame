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
        playButton = GetComponent<Button>();
        if (SaveLoadManager.IsShiftCompleted(shiftSO))
        {
            isCompletedImage.gameObject.SetActive(true);
            var completedShiftInfo = SaveLoadManager.GetCompletedShiftInfoByID(shiftSO.ID);
            switch (completedShiftInfo.MaxCompletedDifficultyLevel)
            {
                case DifficultyLevel.Easy:
                    isCompletedImage.color = new Color(174 / 255f,190 / 255f, 159 / 255f);
                    break;
                case DifficultyLevel.Medium:
                    isCompletedImage.color = new Color(192 / 255f, 195 / 255f, 115 / 255f);
                    break;
                case DifficultyLevel.Hard:
                    isCompletedImage.color = new Color(166 / 255f, 88 / 255f, 88 / 255f);
                    break;

            }

            playButton.onClick.AddListener(() => LoadSceneWithShift(shiftSO));
        }
        else if (shiftSO.ID == SaveLoadManager.GetMostHighCompletedShiftID() + 1) 
        {
            playButton.onClick.AddListener(() => LoadSceneWithShift(shiftSO));
        }
        else
        {
            playButton.interactable = false;
        }
    }

    void LoadSceneWithShift(ShiftSO shiftSO)
    {
        SaveLoadManager.SetCurrentShiftID(shiftSO.ID);
        SceneManager.LoadScene("Game");
    }
}
