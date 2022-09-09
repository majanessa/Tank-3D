using UnityEngine;

namespace DefaultNamespace
{
    public class Gun : MonoBehaviour
    {
        public Camera tankCam;

        public float speed = 0.5f;
        
        public float up = 0;
        public float down = 0;
        public float left = 0;
        public float right = 0;

        private void Update()
        {
            if (Input.GetAxis("Mouse Y") > 0)
            {
                if (up < 20)
                {
                    gameObject.transform.Rotate(-speed, 0, 0);              
                    up++;
                    down = -up;
                }
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                if (down < 10)
                {
                    gameObject.transform.Rotate(speed, 0, 0);                
                    down++;
                    up =- down;
                }
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                if (left < 20)
                {
                    gameObject.transform.Rotate(0, -speed, 0, Space.World);
                    left++;
                    right = -left;
                }
                else
                {
                    tankCam.transform.Rotate(0, -speed, 0, Space.World);
                }
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                if (right < 10)
                {
                    gameObject.transform.Rotate(0, speed, 0, Space.World);              
                    right++;
                    left = -right;
                }
                else
                {
                    tankCam.transform.Rotate(0, speed, 0, Space.World);
                }
            }
        }
    }
}
