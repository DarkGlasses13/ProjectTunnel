using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponView : View
    {
        public Action<int> OnGetId;

        [SerializeField] Transform _hand;
        [SerializeField] WeaponObj _pistol;
        [SerializeField] WeaponObj _uzi;

        private List<Bullet> bulletPull = new List<Bullet>();
        private List<WeaponObj> weaponPull = new List<WeaponObj>();

        private void OnEnable()
        {
            WeaponObj pistolObj = Instantiate(_pistol, _hand);
            WeaponObj uziObj = Instantiate(_uzi, _hand);
            pistolObj.gameObject.SetActive(false);
            uziObj.gameObject.SetActive(false);
            weaponPull.Add(pistolObj);
            weaponPull.Add(uziObj);
        }
        public void ChangeWeapon(Weapon weapon)
        {
            for (int i = 0; i < weaponPull.Count; i++)
            {
                weaponPull[i].gameObject.SetActive(false);
                if (i == weapon.ID)
                {
                    weaponPull[i].gameObject.SetActive(true);
                }
            }
        }
        //public void InitBulletPull(int pullSize, Bullet prefab)
        //{
        //    for (int i = 0; i < pullSize; i++)
        //    {
        //        GameObject instantiateBullet = Instantiate(prefab.gameObject, transform);
        //        instantiateBullet.SetActive(false);
        //        bulletPull.Add(instantiateBullet.GetComponent<Bullet>());
        //    }
        //}
        public void GetWeaponId(int id)
        {
            OnGetId?.Invoke(id);
        }
        private void OnDisable()
        {
            
        }
    }
}
