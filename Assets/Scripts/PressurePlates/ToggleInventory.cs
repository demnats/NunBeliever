using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryUI;
    private GameObject inventoryExplain;

    private bool visable = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            visable = !visable;
            inventoryUI.SetActive(visable);
            inventoryExplain.SetActive(visable);
        }
    }
}
