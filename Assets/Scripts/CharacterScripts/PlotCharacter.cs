using System.Collections;
using UnityEngine;

public class PlotCharacter : CommonCharacter
{
    PlotCharacterSO plotCharacterSO;

    private void OnEnable()
    {
        CharacterMover.OnCharacterStopped += Come;
        CharacterMover.OnCharacterStartMove += Leave;
    }

    private void OnDisable()
    {
        CharacterMover.OnCharacterStopped -= Come;
        CharacterMover.OnCharacterStartMove -= Leave;
    }

    public void MapData(PlotCharacterSO plotCharacterSO)
    {
        this.plotCharacterSO = plotCharacterSO;
        baseImage.sprite = plotCharacterSO.baseSprite;
        baseImage.SetNativeSize();
    }

    protected override void Come()
    {
        DialogueManager.Instance.GetDialogueWindow().SetActive(true);

        
        if (GameManager.Instance.IsLastShift && ShiftManager.Instance.IsLastCharacter)
        {
            Debug.Log("Last plot character moving");
            PrepareForFinalDesicion();
        }
        else
        {
            Debug.Log("plot character moving");
            StartCoroutine(GetAllCuesWithPauses());
            ButtonInteractableController.OnButtonsDisable?.Invoke();
        }
    }

    protected override void Leave()
    {
        DialogueManager.Instance.GetDialogueWindow().SetActive(false);
    }

    void PrepareForFinalDesicion()
    {
        DialogueManager.Instance.GetDialogueText().text = plotCharacterSO.cueArray[0];
    }

    IEnumerator GetAllCuesWithPauses()
    {
        for (int i = 0; i < plotCharacterSO.cueArray.Length; i++)
        {
            DialogueManager.Instance.GetDialogueText().text = plotCharacterSO.cueArray[i];
            yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        }
        ShiftManager.Instance.MoveCurrentCharacter(!plotCharacterSO.isFromLeft);
        ShiftManager.Instance.ContinueShift();
    }

    public override bool HasPermission() => plotCharacterSO.hasPermission;
}
