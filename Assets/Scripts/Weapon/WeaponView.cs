
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponView : View
    {
        public Action<int> OnGetId;

        [SerializeField] Transform _hand;

        private WeaponObj _previoslyWeaponModel;
        //private List<Bullet> bulletPull = new List<Bullet>();

        private void OnEnable()
        {

        }
        public void ChangeWeapon(Weapon weapon)
        {
            WeaponObj model = Instantiate(weapon.Model, _hand);
            if (_previoslyWeaponModel == null)
            {
                _previoslyWeaponModel = model;
            }
            else
            {
                Destroy(_previoslyWeaponModel.gameObject);
                _previoslyWeaponModel = model;
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
