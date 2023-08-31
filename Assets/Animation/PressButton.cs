using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    public UnityEvent pressE;
    public void Press()
    {
        pressE.Invoke();
    }
}
