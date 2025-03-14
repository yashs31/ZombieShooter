using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] Image _imageToReload;
    [SerializeField] Image _gunImage;
    [SerializeField] private float _flickerSpeed = 1.5f; // Speed of flickering
    [SerializeField] ProgressBar _healthBar;
    private bool _isFlickering = false;
    void Start()
    {
        Events.UpdateAmmoCount += UpdateAmmo;
        Events.ReloadToggled += ReloadStatus;
        Events.UpdateHealthUI += UpdateHealth;
        int currentWeapon = GameManager.Instance.CurrentWeaponID;
        _gunImage.sprite = GameManager.Instance.WeaponDB.GetWeaponByID(currentWeapon).Sprite;
    }

    private void OnDisable()
    {
        Events.UpdateAmmoCount -= UpdateAmmo;
        Events.ReloadToggled -= ReloadStatus;
        Events.UpdateHealthUI -= UpdateHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateAmmo(int current, int max)
    {
        _ammoText.text = current + " / " + max;
    }
    private void UpdateHealth(float current)
    {
        _healthBar.ChangeUIValue(current);
    }
    private void ReloadStatus(bool reloading)
    {
        if (reloading)
            StartFlicker();
        else
            StopFlicker();
    }
    public void StartFlicker()
    {
        if (!_isFlickering)
        {
            _isFlickering = true;
            StartCoroutine(Flicker());
        }
    }

    public void StopFlicker()
    {
        _isFlickering = false;
    }

    private IEnumerator Flicker()
    {
        while (_isFlickering)
        {
            float alpha = Mathf.PingPong(Time.unscaledTime * _flickerSpeed, 1);
            _imageToReload.color = new Color(_imageToReload.color.r, _imageToReload.color.g, _imageToReload.color.b, alpha);
            yield return null;
        }

        _imageToReload.color = new Color(_imageToReload.color.r, _imageToReload.color.g, _imageToReload.color.b, 1); // Reset alpha
    }
}
