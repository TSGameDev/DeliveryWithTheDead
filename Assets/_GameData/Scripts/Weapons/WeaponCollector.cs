using TSGameDev.Core.Controls;
using UnityEngine;

namespace TSGameDev
{
    public class WeaponCollector : MonoBehaviour
    {
        [SerializeField] GameObject weapon;
        [SerializeField] GameObject playerWeapon;
        [SerializeField] GameObject weaponHolder;

        private void Awake()
        {
            if (weapon != null)
                Instantiate(weapon, weaponHolder.transform);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider.name);
            if(collision.collider.CompareTag("Player"))
            {
                Player player = collision.collider.GetComponent<Player>();
                if (player.GetPlayerData().activeWeapon != playerWeapon.GetComponent<IWeapon>())
                    player.SetWeapon(playerWeapon);
            }
        }
    }
}
