using UnityEngine;

public class BaseUnit
{
    [SerializeField] private UnitStatsSO _unitStats;

    #region GETTERS
    public UnitStatsSO UnitStats => _unitStats;
    #endregion
}
