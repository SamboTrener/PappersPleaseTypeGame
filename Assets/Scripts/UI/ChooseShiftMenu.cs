using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseShiftMenu : MonoBehaviour
{
    [SerializeField] Transform cellPrefab;
    [SerializeField] ShiftListSO shiftListContainer;

    private void Awake()
    {
        foreach(var shift in shiftListContainer.shifts)
        {
            var cellGO = Instantiate(cellPrefab, transform);
            var cell = cellGO.GetComponent<ShiftCell>();
            cell.MapShiftParameters(shift);
        }
    }
}
