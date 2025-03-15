using System;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    protected const string ENEMY_LAYER = "Enemy";
    protected const string BOUNDARY_LAYER = "Bounds";

    [Header("CONGIF")]
    [SerializeField] LayerMask _layersToDamage;
    [SerializeField] protected float _bulletDamage = 5;

    //local vars
    private WeaponBase _parentWeapon;
    public Rigidbody2D RigidBody2D { get; private set; }
    public Action<float, EnemyBase> OnBulletHit;

    public void Initialize(WeaponBase weapon)
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        _parentWeapon = weapon;
    }

    #region GETTERS
    public float Damage => _bulletDamage;
    public LayerMask LayersToDamage => _layersToDamage;
    #endregion

    #region SETTERS
    public void Initialize(float damage)
    {
        _bulletDamage = damage;
    }
    #endregion
}
