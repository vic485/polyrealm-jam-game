using UnityEngine;

namespace Controller
{
    public class PlayerBase : MonoBehaviour
    {
        public float Health { get; protected set; } = 100f;
        public float CloseAttack { get; protected set; } = 10f;
        public float RangeAttack { get; protected set; } = 50f;
        public float MagicAttack { get; protected set; } = 25f;
        public float Armor { get; private set; } = 0f;

        public void Attack(float damage)
        {
            Health -= Mathf.Min(damage - Armor, 0f);
            
            // TODO: Die when health falls below 0
        }
    }
}
