using System.Collections;
using UnityEngine;

public class PlotCharacter : CommonCharacter
{
    PlotCharacterSO plotCharacterSO;
    int currentCue = -1;

    private void OnEnable()
    {
        CharacterMover.OnCharacterStopped += Come;
        CharacterMover.OnCharacterStartMove += Leave;
        DialogueManager.Instance.OnNextCueButtonPressed += GetNextCue;
    }

    private void OnDisable()
    {
        CharacterMover.OnCharacterStopped -= Come;
        CharacterMover.OnCharacterStartMove -= Leave;
        DialogueManager.Instance.OnNextCueButtonPressed -= GetNextCue;
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
        DialogueManager.Instance.ShowNextCueButton();
        
        if (GameManager.Instance.IsLastShift && ShiftManager.Instance.IsLastCharacter)
        {
            PrepareForFinalDesicion();
        }
        else
        {
            GetNextCue();
            ButtonInteractableController.OnButtonsDisable?.Invoke();
        }
    }

    protected override void Leave()
    {
        DialogueManager.Instance.HideNextCueButton();
        DialogueManager.Instance.GetDialogueWindow().SetActive(false);
    }

    void PrepareForFinalDesicion()
    {
        FullDescrMenu.Instance.FillDescrMenuWithEmptiness();
        var sounds = GetComponent<CharacterSounds>();
        sounds.enabled = false;
        if(YGManager.GetLanguageStr() == "ru")
        {
            DialogueManager.Instance.GetDialogueText().text = plotCharacterSO.cueArray[0];
        }
        else
        {
            DialogueManager.Instance.GetDialogueText().text = plotCharacterSO.cueArrayEn[0];
        }
        DialogueManager.Instance.HideNextCueButton();
    }

    void GetNextCue()
    {
        var cueArrayLen = YGManager.GetLanguageStr() == "ru" ? plotCharacterSO.cueArray.Length : plotCharacterSO.cueArrayEn.Length;
        if (currentCue >= cueArrayLen - 1)
        {
            ShiftManager.Instance.MoveCurrentCharacter(!plotCharacterSO.isFromLeft);
            ShiftManager.Instance.ContinueShift();
        }
        else
        {
            currentCue++;
            if(YGManager.GetLanguageStr() == "ru")
            {
                DialogueManager.Instance.GetDialogueText().text = plotCharacterSO.cueArray[currentCue];
            }
            else
            {
                DialogueManager.Instance.GetDialogueText().text = plotCharacterSO.cueArrayEn[currentCue];
            }
        }
    }

    public override bool HasPermission() => plotCharacterSO.hasPermission;
    public override void Move(bool shouldMoveRight)
    {
        if (shouldMoveRight)
        {
            gameObject.GetComponent<CharacterMover>().MoveRight(true);
        }
        else
        {
            gameObject.GetComponent<CharacterMover>().MoveLeft(true);
        }
    }
}
