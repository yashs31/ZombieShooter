using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    private PlayerControls _controls;
    [SerializeField] private Transform _gunPosition;
    private WeaponBase _currentWeapon;
    private void Awake()
    {
        _controls = InputManager.Instance.Controls;
    }
    private void Start()
    {
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
}
