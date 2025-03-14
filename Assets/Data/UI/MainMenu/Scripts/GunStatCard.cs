using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunStatCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] _statTitle;
    [SerializeField] Button _equipButton;
    [SerializeField] Image _weaponSprite;
    private WeaponDetails _associatedWeapon;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(WeaponDetails so)
    {
        int counter = 0;
        _associatedWeapon = so;
        if (GameManager.Instance.CurrentWeaponID == _associatedWeapon.ID)
        {
            _equipButton.GetComponent<Image>().color = Color.black;
        }
        else
        {
            _equipButton.GetComponent<Image>().color = Color.white;
        }
        _weaponSprite.sprite = so.Sprite;
        foreach (WeaponStat stat in Enum.GetValues(typeof(WeaponStat)))
        {
            TextMeshProUGUI _currentStat = _statTitle[counter];
            if (counter < Enum.GetValues(typeof(WeaponStat)).Length)
            {
                _currentStat.gameObject.SetActive(true);
                switch (stat)
                {
                    case WeaponStat.MAG:
                        _currentStat.text = "Mag Size = " + so.Stats.MagazineSize; break;
                    case WeaponStat.RELOAD:
                        _currentStat.text = "Reload (T) = " + so.Stats.ReloadTime; break;
                    case WeaponStat.FRATE:
                        _currentStat.text = "Fire Rate  = " + so.Stats.FireRate; break;
                    case WeaponStat.SPEED:
                        _currentStat.text = "Bullet Speed = " + so.Stats.BulletSpeed; break;
                }
            }
            else
            {
                _currentStat.gameObject.SetActive(false);
            }
            counter += 1;
        }

        _equipButton.onClick.RemoveAllListeners();
        _equipButton.onClick.AddListener(EquipGun);
    }

    private void EquipGun()
    {
        GameManager.Instance.SetCurrentWeaponID(_associatedWeapon.ID);
        ShopUI.Instance.Init();
    }
}
