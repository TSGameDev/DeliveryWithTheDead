using UnityEngine;
using UnityEngine.Rendering.UI;

namespace TSGameDev
{
    public class Rifle : MonoBehaviour, IWeapon
    {
        [SerializeField] GameObject bullet;
        [SerializeField] WeaponData weaponData;
        [SerializeField] Transform firePoint;

        private int currentAmmo;

        public int GetAmmo() => currentAmmo;

        public void Attack()
        {
            Debug.Log(firePoint.position);
            Debug.Log(firePoint.localPosition);
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}
