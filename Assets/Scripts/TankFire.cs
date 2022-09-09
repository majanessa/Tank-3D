using UnityEngine;

namespace DefaultNamespace
{
    public class TankFire : MonoBehaviour
    {
        // Объект Cannonball, присвоить значение в untiy панели
        public GameObject firePrefab;
        // Скорость ядра может быть назначена на панели единства
        public float shellSpeed = 25f;
        // Позиция запуска, пустой объект, который мы разместили
        public Transform _firePosition;

        public ParticleSystem shootEffect;

        // Update is called once per frame
        void Update()
        {
            // Если вы нажмете настраиваемую кнопку
            if (Input.GetButtonDown("Fire1"))
            {
                shootEffect.Play();
                // Инициализируем экземпляр оболочки
                GameObject fireInstance =
                    Instantiate(firePrefab, _firePosition.position, _firePosition.rotation);
                // Запускаем оболочку, задаем твердому компоненту оболочки скорость и направление
                fireInstance.GetComponent<Rigidbody>().velocity = fireInstance.transform.forward * shellSpeed;
            }
        }
    }
}
