using UnityEngine;

namespace Script
{
    public class CameraJogador : MonoBehaviour
    {
        public Transform target;

        public float velocidadeDeGiro;

        public Vector3 compensado;

        private void LateUpdate()
        {
            var eixoX = Input.GetAxis("Mouse X");
            var eixoY = Input.GetAxis("Mouse Y");

            var anguloRotacaoX = Quaternion.AngleAxis(eixoX * velocidadeDeGiro, Vector3.up);
            var anguloRotacaoY = Quaternion.AngleAxis(eixoY * velocidadeDeGiro, Vector3.left);

            compensado = anguloRotacaoX * anguloRotacaoY * compensado;

            transform.position = target.position + compensado;

            target.forward = new Vector3(compensado.x, 0, compensado.z);
            transform.LookAt(target.position);
        }
    }
}