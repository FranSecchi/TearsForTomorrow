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
    private GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _gm = GameManager.instance;
        interacting = false;
        interactWith = null;
    }

    // Update is called once per frame
    void Update()
    {
        //In case player is clicking buttons, UI...
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        MouseInput();
    }

    private void MouseInput()
    {
        if(interacting)
            CheckInteract();
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = _gm.CurrentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                HandleClick(hitInfo);
            }
        }
    }

    private void HandleClick(RaycastHit hitInfo)
    {
        if (interactWith != null)
        {
            //interactWith.Interact(false);
            interactWith = null;
        }
        GameObject hit = hitInfo.collider.gameObject;
        dest = transform.position;
        switch (hit.layer)
        {
            case 3: //ground
                dest = hitInfo.point;
                interacting = false;
                interactWith = null;
                break;
            case 6: //interactuable
                interactWith = hit.GetComponent<Interactuable>();
                if(interactWith.getStandPosition() != null)
                    dest = interactWith.getStandPosition().position;
                interacting = true;
                break;
            default:
                break;
        }
        agent.SetDestination(dest);
    }
    private void CheckInteract()
    {
        if (Vector3.Distance(transform.position, dest) < 0.15f)
        {
            interactWith.Interact(true);
            interacting = false;
        }
    }
}
