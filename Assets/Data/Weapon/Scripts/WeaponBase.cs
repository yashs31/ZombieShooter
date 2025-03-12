using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponStatsSO _weaponStats;
    protected int _magazineSize;
    protected float _reloadTime;
    protected float _fireRate;
    protected float _bulletSpeed;

    #region GETTERS
    #endregion

    public virtual void Init()
    {

        _magazineSize = _weaponStats.MagazineSize;
        _reloadTime = _weaponStats.ReloadTime;
        _fireRate = _weaponStats.FireRate;
        _bulletSpeed = _weaponStats.BulletSpeed;
    }
}

