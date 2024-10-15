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
    }

    protected override void Come()
    {
        dialogeWindow.SetActive(true);
        StartCoroutine(GetAllCuesWithPauses());
        ButtonInteractableController.OnButtonsDisable?.Invoke();
    }

    protected override void Leave()
    {
        dialogeWindow.SetActive(false);
    }

    IEnumerator GetAllCuesWithPauses()
    {
        for(int i = 0; i < plotCharacterSO.cueArray.Length; i++)
        {
            dialogeText.text = plotCharacterSO.cueArray[i];
            yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        }
        ShiftManager.Instance.MoveCurrentCharacter(!plotCharacterSO.isFromLeft);
        ShiftManager.Instance.ContinueShift();
    }

    public override bool HasPermission() => plotCharacterSO.hasPermission;
}
