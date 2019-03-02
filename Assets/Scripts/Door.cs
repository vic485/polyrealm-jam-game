using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen;
    private bool isMoving;

    private float movePercentage;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player can open
            if (Input.GetButton("Fire2"))
            {
                isOpen = true;
                isMoving = true;
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
