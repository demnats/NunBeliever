using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelGrab : MonoBehaviour
{
    public GameObject Head;
    public float ReleaseAdd;
    public float ReleaseDecay;

    [HideInInspector]
    public bool IsGrabbingPlayer;
    [HideInInspector]
    public float ReleaseCounter;
    private NavMeshAgent agent;
    private PlayerController m_PlayerController;
    private bool m_CanGrab = true;

    private Vector3 pos;
    private Vector3 delta;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ReleaseCounter -= ReleaseDecay * Time.deltaTime;
        ReleaseCounter = Mathf.Clamp01(ReleaseCounter);

        if (Input.GetKeyDown(KeyCode.E))
        {
            ReleaseCounter += ReleaseAdd;
        }

        if (ReleaseCounter >= 1f)
        {
            IsGrabbingPlayer = false;
            m_PlayerController.canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("player") && m_CanGrab)
        {
            m_PlayerController = other.GetComponent<PlayerController>();
            other.GetComponent<AngelGrabRelay>().AngelGrab = this;
            m_PlayerController.canMove = false;
            IsGrabbingPlayer = true;
            agent.isStopped = true;
            m_CanGrab = false;

            pos = Camera.main.transform.position;
            delta = Head.transform.position - Camera.main.transform.position;
            var lookRotation = Quaternion.LookRotation(delta.normalized);

            //m_PlayerController.playerCamera.transform.localRotation = Quaternion.Euler(lookRotation.eulerAngles.x, 0, 0);
            m_PlayerController.transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);

            //playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // up down
            //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0); // left right
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            StartCoroutine(GrabCooldown(2f));
        }
    }

    IEnumerator GrabCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        m_CanGrab = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos, pos + delta);
        Gizmos.DrawWireSphere(Camera.main.transform.position, 0.5f);
    }
}
