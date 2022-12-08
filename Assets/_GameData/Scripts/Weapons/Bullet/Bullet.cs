using UnityEngine;

namespace TSGameDev
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] BulletData bulletData;

        private Rigidbody rb;

        private float spawnPosZ;

        private void Awake()
        {
            spawnPosZ = transform.position.z;
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(Vector3.forward * bulletData.GetSpeed());
        }

        private void Update()
        {
            float disDiff = transform.position.z - spawnPosZ;
            if (disDiff > bulletData.GetDistance())
                DestroyObj();
        }

        private void DestroyObj() => Destroy(gameObject);

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider.name);
            DestroyObj();
        }
    }
}
