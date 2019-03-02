using UnityEngine;

namespace Controller
{
    public class PlayerBase : MonoBehaviour
    {
        public float Health { get; private set; }

        public void Attack(float damage)
        {
            Health -= damage;
        }
    }
}
