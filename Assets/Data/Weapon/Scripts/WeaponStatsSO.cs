using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStatsSO", menuName = "ScriptableObjects/Weapon/WeaponStatsSO")]
public class WeaponStatsSO : ScriptableObject
{
    [SerializeField] protected WeaponType Type;
    [SerializeField] protected int _magazineSize = 0;
    [SerializeField] protected float _reloadTime = 0;
    [SerializeField] protected float _fireRate = 0;
    [SerializeField] protected float _bulletSpeed = 0;

    #region GETTERS
    public int MagazineSize => _magazineSize;
    public float ReloadTime => _reloadTime;
    public float FireRate => _fireRate;
    public float BulletSpeed => _bulletSpeed;
    public WeaponType WeaponType => Type;
    #endregion
}

public enum WeaponType
{
    PISTOL = 0,
    SMG = 1,
    RIFLE = 2
}

public enum WeaponStat
{
    MAG, RELOAD, FRATE, SPEED
}
