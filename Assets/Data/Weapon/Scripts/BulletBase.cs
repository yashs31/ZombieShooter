using System;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    protected const string ENEMY_LAYER = "Enemy";
    [SerializeField] LayerMask _layersToDamage;
    [SerializeField] protected float _bulletDamage = 5;
    public Action<float, EnemyBase> OnBulletHit;
    public Rigidbody2D RigidBody2D { get; private set; }

    protected void Initialize()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    #region GETTERS
    public float Damage => _bulletDamage;
    public LayerMask LayersToDamage => _layersToDamage;
    #endregion
}
