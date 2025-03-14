using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDBSO", menuName = "ScriptableObjects/Weapon/WeaponDBSO")]
public class WeaponDBSO : ScriptableObject
{
    [SerializeField] private List<WeaponDetails> _weapons;

    #region GETTERS
    public List<WeaponDetails> Weapons => _weapons;
    public WeaponDetails GetWeaponDetails(WeaponType typeOfWeapon)
    {
        WeaponDetails currentWeapon = _weapons.Find(x => x.WeaponType == typeOfWeapon);
        if (currentWeapon == null)
        {
            Debug.LogError("Null Weapon returned by game manager");
            return null;
        }
        GameObject go = Instantiate(currentWeapon.WeaponPrefab.gameObject);
        return currentWeapon;
    }
    public WeaponDetails GetWeaponByID(int id)
    {
        WeaponDetails currentWeapon = _weapons.Find(x => x.ID == id);
        if (currentWeapon == null)
        {
            Debug.LogError("Null Weapon returned by game manager");
            return null;
        }
        return currentWeapon;
    }
    #endregion
}

[System.Serializable]
public class WeaponDetails
{
    [SerializeField] int _id;
    [SerializeField] protected Sprite _displaySprite;
    [SerializeField] WeaponType _weaponType;
    [SerializeField] GameObject _weaponPrefab;
    [SerializeField] WeaponStatsSO _statSO;

    public int ID => _id;
    public WeaponType WeaponType => _weaponType;
    public GameObject WeaponPrefab => _weaponPrefab;
    public WeaponStatsSO Stats => _statSO;
    public Sprite Sprite => _displaySprite;

}
