using System.Collections;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponStatsSO _weaponStats;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected BulletBase _bulletPrefab;
    protected int _magazineSize;
    protected float _reloadTime;
    protected float _fireRate;
    protected float _bulletSpeed;
    private bool _isReloading;
    private bool _canFire;
    private int _currentAmmo;

    #region GETTERS
    #endregion

    public virtual void Init()
    {

        _magazineSize = _weaponStats.MagazineSize;
        _reloadTime = _weaponStats.ReloadTime;
        _fireRate = _weaponStats.FireRate;
        _bulletSpeed = _weaponStats.BulletSpeed;

        _currentAmmo = _magazineSize;
        _canFire = true;
    }

    public bool AttemptFire()
    {
        if (_isReloading || !_canFire || _currentAmmo <= 0)
            return false;

        StartCoroutine(FireCooldown());
        Shoot();
        return true;
    }

    private IEnumerator FireCooldown()
    {
        _canFire = false;
        yield return new WaitForSeconds(_fireRate);
        _canFire = true;
    }

    private void Shoot()
    {
        _currentAmmo--;
        // Instantiate Bullet

        BulletBase bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.RigidBody2D.velocity = _firePoint.right * _bulletSpeed;

        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _currentAmmo = _magazineSize;
        _isReloading = false;
    }
}

