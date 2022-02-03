using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponView : View
    {
        [SerializeField] Transform viewPos;
        private List<Bullet> bulletPull = new List<Bullet>();

        private void OnEnable()
        {

        }
        public void ChangeWeapon(Weapon weapon)
        {
            Debug.Log(weapon.ItemName);
        }
        public void InitBulletPull(int pullSize, Bullet prefab)
        {
            for (int i = 0; i < pullSize; i++)
            {
                GameObject instantiateBullet = Instantiate(prefab.gameObject, transform);
                instantiateBullet.SetActive(false);
                bulletPull.Add(instantiateBullet.GetComponent<Bullet>());
            }
        }
        public void DisplayFire()
        {

        }
        public void UpdateWeaponPos(Vector3 weaponPos)
        {
            viewPos.position = weaponPos;
        }
        private void OnDisable()
        {
            
        }
    }
}
