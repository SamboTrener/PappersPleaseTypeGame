using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EmployeeSO : CommonCharacterSO
{
    public Sprite[] spritesWithAnomaly;
    public string employeeNameRu;
    public List<string> anomalyNameListRu;
    public string passID;
    public int age;
    public string greeting;
    public string fullDescriptionRu;

    void Init(EmployeeSO employeeSO)
    {
        baseSprite = employeeSO.baseSprite;
        spritesWithAnomaly = employeeSO.spritesWithAnomaly;
        employeeNameRu = employeeSO.employeeNameRu;
        anomalyNameListRu = employeeSO.anomalyNameListRu;
        passID = employeeSO.passID;
        age = employeeSO.age;
        greeting = employeeSO.greeting;
        fullDescriptionRu = employeeSO.fullDescriptionRu;
        hasPermission = employeeSO.hasPermission;
    }

    public static EmployeeSO CreateInstance(EmployeeSO employeeSO)
    {
        var newEmployeeSO = CreateInstance<EmployeeSO>();
        newEmployeeSO.Init(employeeSO);
        return newEmployeeSO;
    }
}
