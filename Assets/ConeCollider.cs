using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class ConeCollider : MonoBehaviour
{
    public float Radius;
    public float Length;

    public MeshCollider Collider;

    public bool Colliding;
    public Collider Other;

    private void OnValidate()
    {
        var newScale = transform.localScale;
        newScale.x = Radius;
        newScale.y = Radius;
        newScale.z = Length / 2f;
        transform.localScale = newScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        Colliding = true;
        Other = other;
    }

    private void OnTriggerStay(Collider other)
    {
        Other = other;
    }

    private void OnTriggerExit(Collider other)
    {
        Other = null;
        Colliding = false;
    }
}
