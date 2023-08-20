using UnityEngine;

namespace Script
{
    public class MovimentoJogador : MonoBehaviour
    {
        public float speed = 5.5f;

        public float forcaPulo = 1;

        public float forcaGravidade = 5;

        public Rigidbody rb;

        private void FixedUpdate()
        {
            rb.AddForce(Physics.gravity * ((forcaGravidade - 1) * rb.mass));
            var velocity = -1 * (speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * velocity;
            }

            if (Input.GetKey(KeyCode.A))
            {
                var vecDir = Quaternion.Euler(0, -90, 0) * transform.forward;
                transform.position += vecDir * velocity;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += transform.forward * (velocity * -1);
            }

            if (Input.GetKey(KeyCode.D))
            {
                var vecDir = Quaternion.Euler(0, 90, 0) * transform.forward;
                transform.position += vecDir * velocity;
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * forcaPulo, ForceMode.Impulse);
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            Cursor.lockState = hasFocus ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}