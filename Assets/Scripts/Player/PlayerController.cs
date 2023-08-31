using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    /* This script manages the movement of the player using the
     * character controller.
     */
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float gravity = 9.8f;
    /*public LookAtInterect lookAt;*/

    public Camera playerCamera;

    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public float Stamina = 100f;
    public float maxStamina = 100f;

    CharacterController characterController;

    float rotationX = 0;

    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = (Input.GetKey(KeyCode.LeftShift) && Stamina > 0);

        //Stamina will deplete while running
        if (isRunning) { Stamina--; }

        //when not running the stamina will regen to MaxStamina
        if (!isRunning && Stamina < maxStamina)
        {
            StartCoroutine(RegenerateStamina());
        }

        //stops all CoRoutines in this script
        else if (Stamina == maxStamina)
        {
            StopAllCoroutines();
        }

        //speed of the player
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;



        // Move the controller
        if (characterController.enabled)
            characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            //gravity for falling
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // up down
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0); // left right
        }
    }
    private IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(8f);

        while (Stamina < maxStamina)
        {
            Stamina += maxStamina / 100;
            yield return new WaitForSeconds(0.1f);
        }

    }

}
