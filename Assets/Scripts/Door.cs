using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

public class Door : MonoBehaviour
{
    private bool isOpen;
    private bool isMoving;
    public bool needsKey;

    private float movePercentage;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player can open
            if (Input.GetButton("Fire2"))
            {
                if (needsKey)
                {
                    PlayerBase pb = other.gameObject.GetComponent<PlayerBase>();
                    if (pb.Keys > 0)
                    {
                        pb.RemoveKey();
                        isOpen = true;
                        isMoving = true;
                    }
                }
                else
                {
                    isOpen = true;
                    isMoving = true;
                }
            }
        }
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, 1.0f, transform.position.z), new Vector3(transform.position.x, 3.0f, transform.position.z), movePercentage);
            movePercentage += Time.deltaTime;
            if (movePercentage > 1.0)
                isMoving = false;
        }
    }
}
