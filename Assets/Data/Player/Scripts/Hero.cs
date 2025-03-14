using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private UnitStatsSO _unitStats;
    [SerializeField] Animator _animator;
    [SerializeField] private Transform _gunPosition;

    private float _horizontal;
    private bool _isFacingRight;
    //local vars
    private PlayerControls _controls;
    private WeaponBase _currentWeapon;
    protected float _currentHealth;
    protected bool _isImmune;
    public Rigidbody2D RigidBody { get; private set; }
    //States
    public HeroBaseState _currentState;

    public HeroIdleState _idleState = new HeroIdleState();
    public HeroHurtState _hurtState = new HeroHurtState();
    public HeroDeathState _deathState = new HeroDeathState();
    public HeroWalkState _walkState = new HeroWalkState();
    private void Awake()
    {
        _controls = InputManager.Instance.Controls;
        _currentHealth = _unitStats.Health;
        RigidBody = GetComponent<Rigidbody2D>();
        _isFacingRight = true;
    }

    private void Start()
    {
        Events.PlayerHit += TakeDamage;
        _currentState = _idleState;
        _currentState.EnterState(this);
        GameManager.Instance.SetPlayer(this);
        _currentWeapon = Instantiate(GameManager.Instance.CurrentWeaponObject, _gunPosition, true).GetComponent<WeaponBase>();
        Events.UpdateHealthUI?.Invoke(_currentHealth);
    }

    private void OnEnable()
    {
        AssignInputActions();
    }

    private void OnDisable()
    {
        DeAssignInputActions();
        Events.PlayerHit -= TakeDamage;
    }

    private void Update()
    {
        RigidBody.velocity = new Vector2(_horizontal * _unitStats.MoveSpeed, 0);
    }
    #region Input Actions
    private void AssignInputActions()
    {
        _controls.Player.Move.performed += Move;
        _controls.Player.Move.canceled += Idle;
        _controls.Player.Fire.performed += Fire;
    }
    private void DeAssignInputActions()
    {
        _controls.Player.Move.performed -= Move;
        _controls.Player.Move.canceled -= Idle;
        _controls.Player.Fire.performed -= Fire;
    }

    private void Move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
        SwitchState(_walkState);
        if (_horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            _gunPosition.transform.localScale = new Vector3(-1, 1, 1);
            _isFacingRight = false;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            _gunPosition.transform.localScale = new Vector3(1, 1, 1);
            _isFacingRight = true;
        }
    }
    private void Idle(InputAction.CallbackContext context)
    {
        SwitchState(_idleState);
        _horizontal = 0;
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("IsFiring");
        if (_currentWeapon.AttemptFire(_isFacingRight))
        {

        }
    }

    #endregion

    #region STATE MACHINE
    public void SwitchState(HeroBaseState newState)
    {
        if (_currentState == _deathState)
            return;
        if (_currentState == newState) return;

        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    #region GETTERS
    public Animator Animator => _animator;
    public UnitStatsSO UnitStats => _unitStats;
    public WeaponBase Weapon => _currentWeapon;
    #endregion

    #endregion

    #region DAMAGE
    private void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Events.GameEnd?.Invoke();
        }
        Events.UpdateHealthUI?.Invoke(_currentHealth);


    }
    #endregion
}
