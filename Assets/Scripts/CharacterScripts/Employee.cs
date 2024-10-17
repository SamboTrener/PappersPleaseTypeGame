using UnityEngine;

public class Employee : CommonCharacter
{
    EmployeeSO employeeSO;

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

    public void MapData(EmployeeSO employeeSO)
    {
        this.employeeSO = employeeSO;
        baseImage.sprite = employeeSO.baseSprite;
        baseImage.SetNativeSize();
    }

    protected override void Come()
    {
        DialogueManager.Instance.GetDialogueText().text = employeeSO.greeting;
        DialogueManager.Instance.GetDialogueWindow().SetActive(true);
        DocumentMenu.Instance.ShowDocument(employeeSO);
        FullDescrMenu.Instance.FillDescrMenu(employeeSO);
    }

    protected override void Leave()
    {
        DocumentMenu.Instance.HideDocument();
        DialogueManager.Instance.GetDialogueWindow().SetActive(false);
    }

    public override bool HasPermission() => employeeSO.hasPermission;
}
