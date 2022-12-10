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
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            //GameObject instance = Instantiate(bullet, Vector3.zero, firePoint.rotation);
            //instance.transform.position = firePoint.position;
        }
    }
}
