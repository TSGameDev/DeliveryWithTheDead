using UnityEngine;

namespace TSGameDev
{
    public class Rifle : MonoBehaviour, IWeapon
    {
        [SerializeField] GameObject bullet;
        [SerializeField] WeaponData weaponData;

        private int currentAmmo;

        public int GetAmmo() => currentAmmo;

        public void Attack()
        {

        }
    }
}
