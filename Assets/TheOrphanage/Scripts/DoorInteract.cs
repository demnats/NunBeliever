using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private float interactionRange;

    private bool pressed;

    private void Update()
    {
        // Cache input so we can raycast more consistently inside of FixedUpdate
        if (Input.GetKeyDown(KeyCode.E))
            pressed = true;
    }

    private void FixedUpdate()
    {
        if (pressed)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, interactionRange, LayerMask.GetMask("Door")))
            {
                if (hitInfo.collider.CompareTag("Door"))
                {
                    hitInfo.collider.SendMessageUpwards("OnInteract", GetComponent<KeyPickup>().OwnedKeys);
                }
            }
        }
        pressed = false;
    }
}

