using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HidingMove : MonoBehaviour
{
   float rotationY = 0; 
   float rotationX = 0;
    float mouseSense = 10;

    // Update is called once per frame
    void Update()
    {
        rotationY = Input.GetAxis("Mouse X") * mouseSense;
        rotationX = Input.GetAxis("Mouse Y") * mouseSense * -1;

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
