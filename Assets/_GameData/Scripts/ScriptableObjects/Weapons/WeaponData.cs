using UnityEngine;

namespace TSGameDev
{
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "New Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] int damage;
        [SerializeField] int spread;
        [SerializeField] int ammo;
        [SerializeField] float range;
        [SerializeField] float reloadTime;
        [SerializeField] float fireBuffer;

        public int GetAmmo() => ammo;
        public float GetAttackBuffer() => fireBuffer;
        public float GetRange() => range;
    }
}
