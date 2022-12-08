using UnityEngine;

namespace TSGameDev
{
    [CreateAssetMenu(fileName = "New Bullet Data", menuName = "New Bullet Data")]
    public class BulletData : ScriptableObject
    {
        [SerializeField] float bulletSpeed;
        [SerializeField] float bulletDistance;

        public float GetSpeed() => bulletSpeed;
        public float GetDistance() => bulletDistance;
    }
}
