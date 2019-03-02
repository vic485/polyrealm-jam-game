using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Base enemy for handling movement and stuff.
    /// Actual enemies should inherit from this
    /// </summary>
    public class EnemyBase : MonoBehaviour
    {
        public float handToHandDmg;
        public float rangedDmg;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
        }

        private void Update()
        {
            // Act as a billboard
            transform.rotation = Quaternion.Euler(0f, _playerTransform.rotation.eulerAngles.y, 0f);
            
            // TODO: Move towards player
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // TODO: Deal handToHandDmg
            }
        }
    }
}
