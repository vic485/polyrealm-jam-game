using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        // Inputs
        private float _vertical;
        private float _lookRot;
        private float _strafe;
        
        private CharacterController _controller;
        private Transform _camera;
        public GameObject body;
        public GameObject eye;
        public float lookSpeed = 5f;
        public float moveSpeed = 1f;
        

        private void Start()
        {
            _controller = body.GetComponent<CharacterController>();
            _camera = eye.transform;
        }

        private void Update()
        {
            GetInput();
            _camera.rotation = Quaternion.Lerp(_camera.rotation, body.transform.rotation, Time.deltaTime * 20f); //Lerp so that the jerkiness of 30 updates per second doesn't make the game feel like 30FPS on a 60+hz monitor
            _camera.position = Vector3.Lerp(_camera.position, body.transform.position, Time.deltaTime * 20f); //Same here
        }

        private void FixedUpdate()
        {
            var v = body.transform.forward * _vertical;
            var h = body.transform.right * _strafe;
            var moveDir = (v + h).normalized;
            var speed = moveSpeed * Time.fixedDeltaTime;
            _controller.Move(moveDir * speed);
            
            var yRot = body.transform.rotation.eulerAngles.y;
            yRot += _lookRot * lookSpeed * Time.fixedDeltaTime;
            body.transform.rotation = Quaternion.Euler(0f, yRot, 0f);
        }

        private void GetInput()
        {
            _vertical = Input.GetAxisRaw("Vertical");
            _lookRot = Input.GetAxisRaw("Horizontal");
            _strafe = Input.GetAxisRaw("Strafing");
        }
    }
}
