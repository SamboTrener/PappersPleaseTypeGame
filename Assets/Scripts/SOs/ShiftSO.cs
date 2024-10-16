using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShiftSO : ScriptableObject
{
    public int ID;
    public string ShiftName;
    public int VisitersCount;
    public List<PlotCharacterSO> plotCharacters;
}
