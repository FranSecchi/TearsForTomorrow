using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent agent;
    private bool interacting;
    private Interactuable interactWith;
    private Vector3 dest;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        interacting = false;
        interactWith = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (interacting)
        {
            CheckInteract();
        }
        else
            MouseInput();
    }

    private void CheckInteract()
    {
        Debug.Log("interacting");
        if (Vector3.Distance(transform.position, dest) < 0.1f)
        {
            Debug.Log("in pos");
            interactWith.Interact(true);
            interacting = false;
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(interactWith != null)
            {
                interactWith.Interact(false);
                interactWith = null;
            }
            if(Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                GameObject hit = hitInfo.collider.gameObject;
                Debug.Log(hit);
                dest = transform.position;
                switch (hit.layer)
                {
                    case 3:
                        dest = hitInfo.point;
                        break;
                    case 6:
                        dest = hit.transform.GetChild(0).position;
                        interacting = true;
                        interactWith = hit.GetComponent<Interactuable>();
                        break;
                    default:
                        break;
                }
                agent.SetDestination(dest);
            }
        }
    }
}
