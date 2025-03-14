using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LevelProgressHUD _levelProgressHUD;
    [SerializeField] WeaponHUD _weaponHUD;
    [SerializeField] Button _pauseButton;
    void Start()
    {
        _pauseButton.onClick.RemoveAllListeners();
        _pauseButton.onClick.AddListener(PauseUI.Instance.OpenPanel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
