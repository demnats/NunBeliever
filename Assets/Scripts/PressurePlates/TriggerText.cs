using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{

    public GameObject text;

    public void Start()
    {
        text.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            text.SetActive(true);
        }
    }
}
