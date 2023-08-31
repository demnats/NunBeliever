using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void OnHoverChanged(bool isHovering)
    {
        // Set the animator to change the text
        m_animator.SetBool("is_visible", isHovering);
    }
}
