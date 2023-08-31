using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DoorLocktext : MonoBehaviour
{
    private KeyPickup keyPickup;
    private DoorController doorController;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        doorController = GetComponentInParent<DoorController>();
        keyPickup = FindObjectOfType<KeyPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyPickup.OwnedKeys.Contains(doorController.ID)) { Object.SetActive(false); }
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TextFade(0,1));
    }
    void OnTriggerExit(Collider other)
    {

        StartCoroutine(TextFade(1,0));
    }
    IEnumerator TextFade(float start, float end)
    {
        float duration = 2f; //Fade out over 2 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(start, end, currentTime / duration);
            text.color = new Color(255, 255, 255, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
   
}
