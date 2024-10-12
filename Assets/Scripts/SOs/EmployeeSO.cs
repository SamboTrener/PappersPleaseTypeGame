using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EmployeeSO : ScriptableObject
{
    public Sprite baseSprite;
    public Sprite spriteWithAnomalyFirst;
    public Sprite spriteWithAnomalySecond;
    public string employeeName;
    public string passID;
    public string age;
    public string greeting;
    public string fullDescription;
    public bool hasPermission;
}
