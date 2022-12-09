using UnityEngine;

namespace TSGameDev
{
    public class Rifle : MonoBehaviour, IWeapon
    {
        [SerializeField] WeaponData weaponData;
        [SerializeField] Transform rayPoint;

        private int currentAmmo;
        public int GetAmmo() => currentAmmo;

        private float fireTimer = 0f;
        private bool canFire = true;

        private void Awake()
        {
            currentAmmo = weaponData.GetAmmo();
        }

        private void Update()
        {
            if (fireTimer > 0)
            {
                fireTimer -= 1 * Time.deltaTime;
                canFire = false;
            }
            else
            {
                fireTimer = 0f;
                canFire = true;
            }
        }

        public void Attack()
        {
            if(canFire)
            {
                fireTimer = weaponData.GetAttackBuffer();
                if(Physics.Raycast(rayPoint.position, rayPoint.forward, out RaycastHit hit, weaponData.GetRange()))
                {
                    Debug.Log("Hit Fire");
                    Debug.DrawRay(rayPoint.position, rayPoint.forward * hit.distance, Color.yellow);
                }
                else
                {
                    Debug.Log("Didnt Hit Fire");
                    Debug.DrawRay(rayPoint.position, rayPoint.forward * 1000, Color.red);
                }
            }
        }
    }
}
