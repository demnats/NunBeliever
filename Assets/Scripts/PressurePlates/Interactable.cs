using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    public UnityEvent interact;

    public virtual void Interact()
    {
        interact.Invoke();
    }

}
