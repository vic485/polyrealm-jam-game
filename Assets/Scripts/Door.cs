using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

public class Door : MonoBehaviour
{
    private bool _isOpen;
    private bool isMoving;
    public bool needsKey;

    private float movePercentage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Player can open
            if (Input.GetButton("Fire2") && !_isOpen)
            {
                if (needsKey)
                {
                    var pb = other.gameObject.GetComponent<PlayerBase>();
                    if (pb.Keys > 0)
                    {
                        pb.RemoveKey();
                        _isOpen = true;
                        isMoving = true;
                    }
                }
                else
                {
                    _isOpen = true;
                    isMoving = true;
                }
            }
        }
    }

    void Update()
    {
        if (isMoving)
        {
            var pos = transform.position;
            transform.position = Vector3.Lerp(new Vector3(pos.x, 1.0f, pos.z), new Vector3(pos.x, 3.0f, pos.z), movePercentage);
            movePercentage += Time.deltaTime;
            if (movePercentage > 1.0)
                isMoving = false;
        }
    }
}
