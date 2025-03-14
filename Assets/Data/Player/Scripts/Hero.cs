using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private UnitStatsSO _unitStats;
    [SerializeField] Animator _animator;
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private ProgressBar _healthIndicatorUI;
    //local vars
    private PlayerControls _controls;
    private WeaponBase _currentWeapon;
    protected float _currentHealth;
    protected bool _isImmune;

    //States
    public HeroBaseState _currentState;
    public HeroIdleState _idleState = new HeroIdleState();
    public HeroHurtState _hurtState = new HeroHurtState();
    private void Awake()
    {
        _controls = InputManager.Instance.Controls;
        _currentHealth = _unitStats.Health;
    }

    private void Start()
    {
        Events.PlayerHit += TakeDamage;
        _healthIndicatorUI.ConfigureSlider(0, _unitStats.Health, false, "");
        _healthIndicatorUI.SetInitialSliderValue(_currentHealth);
        _currentState = _idleState;
        _currentState.EnterState(this);
        GameManager.Instance.SetPlayer(this);
        _currentWeapon = Instantiate(GameManager.Instance.CurrentWeaponObject, _gunPosition, true).GetComponent<WeaponBase>();
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
    #region Input Actions
    private void AssignInputActions()
    {
        _controls.Player.Move.performed += Move;
        _controls.Player.Fire.performed += Fire;
    }
    private void DeAssignInputActions()
    {
        _controls.Player.Move.performed -= Move;
        _controls.Player.Fire.performed -= Fire;
    }

    private void Move(InputAction.CallbackContext context)
    {
        //bool isPressed = context.ReadValue<float>() > 0;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (_currentWeapon.AttemptFire())
        {

        }
    }

    #endregion

    #region STATE MACHINE
    public void SwitchState(HeroBaseState newState)
    {
        if (_currentState == newState) return;

        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    protected void IAmHit(float damage, BaseUnit unit)
    {
        if (_isImmune)
            return;
        if (this != unit)
            return;
        _isImmune = true;
        _currentHealth -= damage;
        _healthIndicatorUI.ChangeUIValue(_currentHealth);
        SwitchState(_hurtState);
    }

    #region GETTERS
    public Animator Animator => _animator;
    public UnitStatsSO UnitStats => _unitStats;
    #endregion

    #endregion

    #region DAMAGE
    private void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {

        }
        _healthIndicatorUI.ChangeUIValue(_currentHealth);

    }
    #endregion
}
