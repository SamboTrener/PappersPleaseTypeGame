using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EmployeeSO : ScriptableObject
{
    public Transform prefab;
    public Sprite baseSprite;

    public Sprite eyesNormal;
    public Sprite eyesAnomaly;
    public Sprite hairNormal;
    public Sprite hairAnomaly;
    //etc sprites of anomalies


    public string employeeName;
    public string passID;
    public string age;
    public string greeting;
    public bool hasPermission;
}
