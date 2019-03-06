using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemBase : MonoBehaviour
    {
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Item is being picked up
                OnPickup();
            }
        }

        protected void OnPickup()
        {
            Destroy(gameObject);
        }

        protected void Update()
        {
            transform.forward = _playerTransform.forward;
        }
    }
}