using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    [SerializeField] private PlayerControls _playerControls;
    [SerializeField] private WeaponDBSO _weaponDB;
    private int _currentWeaponID;
    private Hero _player;
    private void Awake()
    {
        _currentWeaponID = 1;
        // Singleton Behaviour
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region GETTERS
    public WeaponDBSO WeaponDB => _weaponDB;
    public PlayerControls PlayerControls => _playerControls;
    public Hero Player => _player;
    public int CurrentWeaponID => _currentWeaponID;

    public GameObject CurrentWeaponObject
    {
        get
        {
            if (_currentWeaponID == 0)
                return _weaponDB.GetWeaponByID(1).WeaponPrefab;
            else
            {
                return _weaponDB.GetWeaponByID(_currentWeaponID).WeaponPrefab;
            }
        }
    }

    #endregion

    public void TogglePause()
    {
        if (Time.timeScale == 0)
            ResumeGame();
        else
            PauseGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    #region SETTERS
    public void SetPlayer(Hero hero) => _player = hero;
    public void SetCurrentWeaponID(int id) => _currentWeaponID = id;
    #endregion
}
