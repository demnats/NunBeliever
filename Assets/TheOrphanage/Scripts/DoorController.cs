using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float autoCloseTime;
    [SerializeField] internal int ID = -1;
    [SerializeField] private bool isBlocked;

    private bool m_isOpen;
    private bool m_openedByNun;
    private bool m_isHovering;
    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the nun gets in range, open the door and start autoclose coroutine
        if (other.CompareTag("Nun"))
        {
            if (!m_isOpen)
            {
                SetOpen(true);
                m_openedByNun = true;
                StartCoroutine(AutoCloseDoor());
            }
        }
    }

    IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(autoCloseTime);
        // if the door was opened or closed while waiting for auto close, dont auto close the door
        if (m_openedByNun)
            SetOpen(false);
    }

    public void SetOpen(bool open)
    {
        // Prevent autoclose when the player interacts with the door
        m_openedByNun = false;
        m_isOpen = open;
        m_animator.SetBool("is_open", open);
    }

    public void ToggleDoor()
    {
        if (m_isOpen)
            SetOpen(false);
        else
            SetOpen(true);
    }

    public void OnInteract(List<int> keys)
    {
        if (isBlocked)
            return;

        // Only require key if door is locked
        if (ID == -1 || keys.Contains(ID))
            ToggleDoor();
    }
}
