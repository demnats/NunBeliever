using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectsPlayer : MonoBehaviour
{
    public float walkingBobbingSpeed = 10f;
    public float bobbingAmount = 0.05f;
    public PlayerController controller;

    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(controller.moveDirection.x) > 0.1f || Mathf.Abs(controller.moveDirection.z) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            playerMoving();
        }
       else if (controller.Stamina == 0)
        {
            timer += 0.008f;
            playerMoving();
        }
        
     
    }

    void playerMoving()
    {
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z); 
    }
}
