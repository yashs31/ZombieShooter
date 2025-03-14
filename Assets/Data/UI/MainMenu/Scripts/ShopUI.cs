using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GunStatCard[] _statCard;
    [SerializeField] Button _closeButton;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _overlay;
    public static ShopUI Instance;
    private void Awake()
    {
        // Singleton Behaviour
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Init()
    {
        _closeButton.onClick.RemoveAllListeners();
        _closeButton.onClick.AddListener(ClosePanel);

        WeaponDBSO weaponDB = GameManager.Instance.WeaponDB;
        for (int i = 0; i < _statCard.Length; i++)
        {
            GunStatCard _currentCard = _statCard[i];
            _currentCard.gameObject.SetActive(true);
            if (i < weaponDB.Weapons.Count)
            {
                WeaponDetails currentWeapon = weaponDB.Weapons[i];
                _currentCard.Init(currentWeapon);
            }
            else
            {
                _currentCard.gameObject.SetActive(false);
            }
        }
    }

    public void OpenPanel()
    {
        _animator.SetBool("isOpen", true);
        _overlay.SetActive(true);
        Init();
    }
    public void ClosePanel()
    {
        _animator.SetBool("isOpen", false);
        _overlay.SetActive(false);
    }
}
