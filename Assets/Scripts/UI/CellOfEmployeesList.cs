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

        nameField.text = $"��� : {employeeSO.employeeNameRu}";
        ageField.text = $"������� : {employeeSO.age}";
        passIdField.text = $"����� ��������� : {employeeSO.passID}";
    }
}
