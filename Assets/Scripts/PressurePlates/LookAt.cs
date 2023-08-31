using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject secretPaper;

    void Update()
    {
        if (secretPaper)
        {
            print("hi"); 
            transform.LookAt(player.transform);
        }

    }
}
