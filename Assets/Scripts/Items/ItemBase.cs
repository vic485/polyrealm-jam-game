using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

namespace Items
{
    public class ItemBase : MonoBehaviour
    {
        protected Transform _playerTransform;
        protected GameObject _playerObject;
        protected PlayerBase _playerBase;

        protected void Start()
        {
            _playerObject = GameObject.FindWithTag("Player");
            _playerTransform = _playerObject.transform;
            _playerBase = _playerObject.GetComponent<PlayerBase>();
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Item is being picked up
                OnPickup();
            }
        }

        protected virtual void OnPickup()
        {
            Destroy(gameObject);
        }

        protected void Update()
        {
            transform.forward = _playerTransform.forward;
        }
    }
}