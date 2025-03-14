using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //config
    [Header("CONFIG")]
    [SerializeField] protected ZombieStatsSO _statsSO;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _runAttackStartDistance = 2f;
    [SerializeField] protected float _standAttackRange = 2f;

    [Header("UI REFS")]
    [SerializeField] ProgressBar _healthIndicatorUI;

    //states
    public EnemyBaseState _currentState;
    public EnemyWalkState _walkState = new EnemyWalkState();
    public EnemyAttackState _attackState = new EnemyAttackState();
    public EnemyDeadState _deadState = new EnemyDeadState();
    public EnemyHurtState _hurtState = new EnemyHurtState();

    //local vars
    public Rigidbody2D RigidBody2D { get; private set; }
    protected int _enemyLayer;
    private float _currentHealth;
    private bool _isImmune;

    protected virtual void Awake()
    {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        RigidBody2D = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        _currentHealth = _statsSO.Health;
        GameManager.Instance.BulletHit += IAmHit;

        //configure the health ui
        _healthIndicatorUI.ConfigureSlider(0, _statsSO.Health, false, "");
        _healthIndicatorUI.SetInitialSliderValue(_statsSO.Health, "100%");

        //set initial state
        _currentState = _walkState;
        _currentState.EnterState(this);
    }

    protected virtual void Update()
    {
        if (_currentState != null)
            _currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        if (_currentState == newState) return;

        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    /// <summary>
    /// make enemy stop walking
    /// </summary>
    public void StopWalk()
    {
        RigidBody2D.velocity = Vector2.zero;
    }
    /// <summary>
    /// make enemy start walking
    /// </summary>
    public void StartWalk()
    {
        RigidBody2D.velocity = -transform.right * MoveSpeed;
    }
    public void PreDeath()
    {
        Destroy(GetComponent<CapsuleCollider2D>());
    }
    public void PostDeath()
    {
        Destroy(this.gameObject);
    }


    /// <summary>
    /// When hit by projectile
    /// </summary>
    /// <param name="damage"> damage to deal</param>
    /// <param name="enemy">enemy ref?</param>
    protected void IAmHit(float damage, EnemyBase enemy)
    {
        if (_isImmune)
            return;
        if (enemy != this)
            return;
        _isImmune = true;
        _currentHealth -= damage;
        _healthIndicatorUI.ChangeUIValue(_currentHealth);
        SwitchState(_hurtState);
    }

    /// <summary>
    /// set immunity to not take continuous damage
    /// </summary>
    /// <param name="value"></param>
    public void SetImmunity(bool value)
    {
        _isImmune = value;
    }

    #region GETTERS
    public float CurrentHealth => _currentHealth;
    public Animator Animator => _animator;
    public float MoveSpeed => _statsSO.MoveSpeed;
    #endregion

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(transform.position, -Vector2.right * _runAttackStartDistance, Color.yellow);
        //Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), -Vector2.right * _standAttackRange, Color.red);
    }
}
