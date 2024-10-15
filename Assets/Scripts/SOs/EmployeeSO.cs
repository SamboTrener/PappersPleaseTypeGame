using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EmployeeSO : CommonCharacterSO
{
    public Sprite[] spritesWithAnomaly;
    public string employeeName;
    public List<string> anomalyNameList;
    public string passID;
    public int age;
    public string greeting;
    public string fullDescription;

    void Init(EmployeeSO employeeSO)
    {
        baseSprite = employeeSO.baseSprite;
        spritesWithAnomaly = employeeSO.spritesWithAnomaly;
        employeeName = employeeSO.employeeName;
        anomalyNameList = employeeSO.anomalyNameList;
        passID = employeeSO.passID;
        age = employeeSO.age;
        greeting = employeeSO.greeting;
        fullDescription = employeeSO.fullDescription;
        hasPermission = employeeSO.hasPermission;
    }

    public static EmployeeSO CreateInstance(EmployeeSO employeeSO)
    {
        var newEmployeeSO = CreateInstance<EmployeeSO>();
        newEmployeeSO.Init(employeeSO);
        return newEmployeeSO;
    }
}
