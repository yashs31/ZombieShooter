using UnityEngine;

[CreateAssetMenu(fileName = "ZombieStatsSO", menuName = "ScriptableObjects/BaseUnit/ZombieStatsSO")]
public class ZombieStatsSO : UnitStatsSO
{
    [Tooltip("Damage to deal when attacking")]
    [SerializeField] private float _damage;

    #region GETTERS
    public float Damage => _damage;
    #endregion
}
