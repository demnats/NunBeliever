using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMechanic : MonoBehaviour
{

    float range = 4f;
    Camera cam;
    Camera mainCamera;
    public static bool hiding;
    GameObject hidingSpot;
    public float mouseSense = 5;

    float rotationX = 0;
    float rotationY = 0;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private bool m_isHovering;
    private bool pressed;

    PlayerController playerController;

    private void Start()
    {
        hiding = false;
        mainCamera = Camera.main;
        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            pressed = true;

        if (hiding) playerController.canMove = false;

    }

    private void FixedUpdate()
    {
        ChechForColliders();
        pressed = false;
    }

    public void ChechForColliders()
    {
        LayerMask mask = LayerMask.GetMask("Hiding");
        RaycastHit hit;

        if (Camera.main != null)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range, mask))
            {
                hidingSpot = hit.transform.gameObject; // hidingspot are the objects that are hit by the raycast 
                if (pressed) // pressing E disables the main camera
                {

                    if (hidingSpot != null)
                    {
                        // setting cam variable to the hiding camera.
                        if (hidingSpot.CompareTag("Bed"))
                            cam = hidingSpot.GetComponentInChildren<Camera>();
                        else
                            cam = hidingSpot.transform.parent.GetComponentInChildren<Camera>();

                        if (cam != null) // enabling the hiding cam.
                        {
                            mainCamera.enabled = false;
                            cam.enabled = true;
                            hiding = true;
                        }
                    }
                }

                if (!m_isHovering)
                {
                    m_isHovering = true;
                    hidingSpot.SendMessageUpwards("OnHoverChanged", m_isHovering);
                }
                return;
            }
            else
            {
                if (m_isHovering)
                {
                    m_isHovering = false;
                    hidingSpot.SendMessageUpwards("OnHoverChanged", m_isHovering);
                }
            }

            hiding = false;
        }
        else if (pressed && Camera.main == null)
        {
            cam.enabled = false;
            mainCamera.enabled = true;
            hiding = false;
            playerController.canMove = true;

        }
        else if (Camera.main == null)
        {
            MoveHidingCamera();
        }
    }

    private void MoveHidingCamera()
    {
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY += -Input.GetAxis("Mouse X") * lookSpeed;
        cam.transform.localRotation = Quaternion.Euler(rotationX, -rotationY, 0);
    }
}

