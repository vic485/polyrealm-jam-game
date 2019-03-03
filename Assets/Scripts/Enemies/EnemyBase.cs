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
            //transform.rotation = Quaternion.Euler(0f, _playerTransform.rotation.eulerAngles.y, 0f);
            transform.forward = _playerTransform.forward; //This is faster than the above method, and will result in the same effect, because our player doesn't rotate around any other axis than Y
            //transform.LookAt(_playerTransform); //But this is hopefully better, because otherwise if you turn the camera the enemy's shadow will change and it looks really weird. EDIT: not better lol
            
            // TODO: Move towards player
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // TODO: Deal handToHandDmg
                // TODO: Add a cooldown to the above function, so the player doesn't die almost instantly lol
            }
        }
    }
}
