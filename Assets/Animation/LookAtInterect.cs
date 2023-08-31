using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtInterect : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private int range = 3;
    
    private void Update()
    {

        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.yellow);
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }

}
