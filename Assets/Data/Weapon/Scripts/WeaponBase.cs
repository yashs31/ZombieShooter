using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] protected WeaponStatsSO _weaponStats;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] private int _poolSize;

    [Header("PREFABS")]
    [SerializeField] protected BulletBase _bulletPrefab;

    //local vars
    protected int _magazineSize;
    protected float _reloadTime;
    protected float _fireRate;
    protected float _bulletSpeed;
    private bool _isReloading;
    private bool _canFire;
    private int _currentAmmo;
    private float _bulletDamage;
    private List<BulletBase> _inActiveBullets = new List<BulletBase>();
    private AudioSource _audioSource;
    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            BulletBase bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            bullet.Initialize(this);
            bullet.gameObject.SetActive(false);
            _inActiveBullets.Add(bullet);
        }
        _audioSource = GetComponent<AudioSource>();
    }


    public virtual void Init()
    {
        _magazineSize = _weaponStats.MagazineSize;
        _reloadTime = _weaponStats.ReloadTime;
        _fireRate = _weaponStats.FireRate;
        _bulletSpeed = _weaponStats.BulletSpeed;
        _bulletDamage = _weaponStats.BulletDamage;
        _currentAmmo = _magazineSize;
        _canFire = true;
        UpdateAmmoHUD();
    }

    public bool AttemptFire(bool direction)
    {
        if (_isReloading || !_canFire || _currentAmmo <= 0)
            return false;
        try
        {
            StartCoroutine(FireCooldown());
            Shoot(direction);
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

    private IEnumerator FireCooldown()
    {
        _canFire = false;
        yield return new WaitForSeconds(_fireRate);
        _canFire = true;
    }

    private void Shoot(bool isFacingRight)
    {
        _audioSource.PlayOneShot(AudioManager.Instance.playerSFX.ShootSFX);
        _currentAmmo--;
        // Instantiate Bullet
        UpdateAmmoHUD();
        BulletBase bullet = GetPooledBullet();
        if (bullet == null)
        {
            Debug.Log("Pool size not enough");
            return;
        }
        bullet.Initialize(_bulletDamage);
        float _direction = 1;
        if (isFacingRight)
            _direction = 1;
        else
            _direction = -1;
        bullet.transform.position = _firePoint.transform.position;
        bullet.RigidBody2D.velocity = _firePoint.right * _bulletSpeed * _direction;

        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        ToggleReloadUI();
        yield return new WaitForSeconds(_reloadTime);
        _currentAmmo = _magazineSize;
        _isReloading = false;
        UpdateAmmoHUD();
        ToggleReloadUI();
    }

    private void ToggleReloadUI()
    {
        Events.ReloadToggled?.Invoke(_isReloading);
    }

    #region GETTERS

    private BulletBase GetPooledBullet()
    {
        foreach (BulletBase bullet in _inActiveBullets)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }
        return null;

    }

    private void UpdateAmmoHUD()
    {
        Events.UpdateAmmoCount?.Invoke(_currentAmmo, _magazineSize);
    }
    #endregion
}

