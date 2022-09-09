using UnityEngine;

namespace DefaultNamespace
{
    public class Shell : MonoBehaviour
    {
        // Эффект взрыва
        public GameObject boomPrefab;
        
        public float radius = 5f;
        public float power = 1f;

        // Обнаружение триггера
        void OnTriggerEnter(Collider other)
        {
            // Уничтожаем саму оболочку
            Destroy(gameObject);
            // Создаем эффект взрыва в положении и направлении триггера
            GameObject explosion = Instantiate(boomPrefab, transform.position, transform.rotation);
            Vector3 explosionPos = explosion.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3f);
            }
        }
    }
}
