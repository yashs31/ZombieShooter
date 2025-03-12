using UnityEngine;

public class UnitStatsSO : ScriptableObject
{
    [SerializeField] protected float _health = 0;
    [SerializeField] protected float _moveSpeed = 0;

    #region GETTERS
    public float Health => _health;
    public float MoveSpeed => _moveSpeed;
    #endregion
}
