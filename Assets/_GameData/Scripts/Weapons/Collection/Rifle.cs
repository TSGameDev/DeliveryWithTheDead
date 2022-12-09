using UnityEngine;

namespace TSGameDev
{
    public class Rifle : MonoBehaviour, IWeapon
    {
        [SerializeField] WeaponData weaponData;
        Transform rayPoint;

        private int currentAmmo;
        public int GetAmmo() => currentAmmo;

        private float fireTimer = 0f;
        private bool canFire = true;

        private void Awake()
        {
            currentAmmo = weaponData.GetAmmo();
            rayPoint = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log(rayPoint.name);
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
                if(Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out RaycastHit hit, weaponData.GetRange()))
                {
                    Debug.Log("Hit Fire");
                    Debug.DrawRay(rayPoint.position, rayPoint.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                else
                {
                    Debug.Log("Didnt Hit Fire");
                    Debug.DrawRay(rayPoint.position, rayPoint.TransformDirection(Vector3.forward) * 1000, Color.red);
                }
            }
        }
    }
}
