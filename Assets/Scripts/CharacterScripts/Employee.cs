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
    }

    protected override void Come()
    {
        Debug.Log("COME worked");
        dialogeText.text = employeeSO.greeting;
        dialogeWindow.SetActive(true);
        DocumentMenu.Instance.ShowDocument(employeeSO);
        FullDescrMenu.Instance.FillDescrMenu(employeeSO);
    }

    protected override void Leave()
    {
        DocumentMenu.Instance.HideDocument();
        dialogeWindow.SetActive(false);
    }

    public override bool HasPermission() => employeeSO.hasPermission;
}
