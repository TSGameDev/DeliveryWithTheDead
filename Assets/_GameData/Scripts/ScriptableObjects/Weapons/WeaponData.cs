using UnityEngine;

namespace TSGameDev
{
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "New Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] int damage;
        [SerializeField] int range;
        [SerializeField] int spread;
        [SerializeField] int ammo;
        [SerializeField] float reloadTime;
    }
}
