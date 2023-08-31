using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDisplay : MonoBehaviour
{
    public RectTransform Fill;
    public GameObject PanelParent;

    private AngelGrabRelay m_GrabRelay;

    private void Awake()
    {
        m_GrabRelay = GameObject.FindWithTag("player").GetComponent<AngelGrabRelay>();
    }

    private void Update()
    {
        if (m_GrabRelay.AngelGrab != null)
        {
            if (m_GrabRelay.AngelGrab.IsGrabbingPlayer)
            {
                PanelParent.SetActive(true);
                Fill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100f * m_GrabRelay.AngelGrab.ReleaseCounter);
            } 
            else
            {
                PanelParent.SetActive(false);
            }
        }
    }
}
