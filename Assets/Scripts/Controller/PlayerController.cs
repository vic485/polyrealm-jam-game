using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _controller;
        public float lookSpeed = 9f;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _controller.Move(new Vector3(0f, 0f, Input.GetAxis("Vertical")));
            var yRot = transform.rotation.eulerAngles.y;
            yRot += Input.GetAxis("Horizontal") * lookSpeed;
            transform.rotation = Quaternion.Euler(0f, yRot, 0f);
        }
    }
}
