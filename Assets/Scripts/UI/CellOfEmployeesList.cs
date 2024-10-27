using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellOfEmployeesList : MonoBehaviour
{
    [SerializeField] Image iconField;
    [SerializeField] TextMeshProUGUI nameField;
    [SerializeField] TextMeshProUGUI ageField;
    [SerializeField] TextMeshProUGUI passIdField;

    public void MapCellInfoWithSO(EmployeeSO employeeSO)
    {
        iconField.sprite = employeeSO.baseSprite;

        if(YGManager.GetLanguageStr() == "ru")
        {
            nameField.text = $"Имя : {employeeSO.employeeNameRu}";
            ageField.text = $"Возраст : {employeeSO.age}";
            passIdField.text = $"Номер документа : {employeeSO.passID}";
        }
        else
        {
            nameField.text = $"Name : {employeeSO.employeeName}";
            ageField.text = $"Age : {employeeSO.age}";
            passIdField.text = $"Pass ID : {employeeSO.passID}";
        }
    }
}
