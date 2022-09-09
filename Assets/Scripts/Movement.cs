using UnityEngine;

namespace DefaultNamespace
{

    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        public float maxSpeed = 2f, rotateSpeed = 0.75f;

        private float _vertMove, _horMove;

        private Rigidbody _rb;

        private Transform _hull;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _hull = transform.GetChild(0);
        }

        private void FixedUpdate()
        {
            MoveTank();
            MoveFire();
        }

        private void MoveTank()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");
            
            if (moveHorizontal > 0)
            { 
                transform.Rotate(Vector3.up * rotateSpeed);
            }
            else if (moveHorizontal < 0)
            { 
                transform.Rotate(Vector3.down * rotateSpeed);
            }

            if (moveVertical > 0)
            {
                _rb.AddForce(transform.forward * maxSpeed, ForceMode.Impulse);
                _hull.localRotation = Quaternion.Slerp(_hull.localRotation, Quaternion.Euler(-93.8f,  0, 0), Time.deltaTime * 2f);
            }
            else if (moveVertical < 0)
            {
                _rb.AddForce(-transform.forward * maxSpeed, ForceMode.Impulse);
                _hull.localRotation = Quaternion.Slerp(_hull.localRotation, Quaternion.Euler(-83.8f,0, 0), Time.deltaTime * 2f);
            }
            else if (moveVertical == 0)
            {
                _hull.localRotation = Quaternion.Slerp(_hull.localRotation, Quaternion.Euler(-88.8f,  0, 0), Time.deltaTime * 4f);
            }
            
            var magnitude = _rb.velocity.magnitude;
            if (magnitude >= maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * maxSpeed;
            }
        }

        private void MoveFire()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _rb.AddForce(-transform.forward * 2f, ForceMode.Impulse);
                _hull.localRotation = Quaternion.Slerp(_hull.localRotation, Quaternion.Euler(-83.8f,0, 0), Time.deltaTime * 25f);
            }
        }
    }
}
