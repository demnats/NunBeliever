using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : MonoBehaviour
{

    public void DisapearAfterSec(float sec)
    {
        Invoke("Disapear",sec);
    }

    private void Disapear()
    {
        gameObject.SetActive(false);
    }
}
