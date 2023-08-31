using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInPlayerVision : MonoBehaviour
{
    public bool Value
    {
        get
        {
            if (XRayValue)
            {
                return CheckVision();
            }
            return false;
        }
    }

    public bool XRayValue
    {
        get
        {
            _xray = CheckXRay();
            return _xray;
        }
    }

    private bool _xray = false;

    private bool CheckVision()
    {
        var delta = transform.position - Camera.main.transform.position;
        if (Physics.Raycast(Camera.main.transform.position, delta.normalized, out var hitInfo, delta.magnitude + 1))
        {
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.gameObject == gameObject)
            {
                Debug.Log("true");
                return true;
            }
        }
        Debug.Log("false");
        return false;
    }

    private bool CheckXRay()
    {
        var viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.z > 0)
        {
            if (viewportPos.x > 0 && viewportPos.y > 0 && viewportPos.x < 1 && viewportPos.y < 1)
            {
                return true;
            }
        }
        return false;
    }
}
