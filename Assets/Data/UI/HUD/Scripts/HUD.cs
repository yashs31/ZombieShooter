using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LevelProgressHUD _levelProgressHUD;
    [SerializeField] Button _pauseButton;
    [SerializeField] WeaponHUD _weaponHUD;
    void Start()
    {
        _pauseButton.onClick.RemoveAllListeners();
        _pauseButton.onClick.AddListener(GameManager.Instance.TogglePause);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
