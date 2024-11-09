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

        nameField.text = $"Имя : {employeeSO.employeeNameRu}";
        ageField.text = $"Возраст : {employeeSO.age}";
        passIdField.text = $"Номер документа : {employeeSO.passID}";
    }
}
