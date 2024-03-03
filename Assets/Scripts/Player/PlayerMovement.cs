using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
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

    public EventReference stepSoundRef;
    private EventInstance stepSound;

    void Start()
    {
        _gm = GameManager.instance;
        stepSound = RuntimeManager.CreateInstance(stepSoundRef);
        agent = GetComponent<NavMeshAgent>();
        interacting = false;
        interactWith = null;
    }

    // Update is called once per frame
    void Update()
    {
        //In case player is clicking buttons, UI...
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (agent.velocity != Vector3.zero){
            stepSound.start();
            transform.eulerAngles = new Vector3(0, Quaternion.LookRotation(agent.velocity - Vector3.zero).eulerAngles.y, 0);
        }
        else{
            stepSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
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
        
        GameObject hit = hitInfo.collider.gameObject;
        dest = transform.position;
        switch (hit.layer)
        {
            case 3: //ground
                dest = hitInfo.point;
                interacting = false;
                if (interactWith != null)
                {
                    interactWith.Interact(false);
                    interactWith = null;
                }
                break;
            case 6: //interactuable
                if(!Use(hit))
                    Interact(hit);
                break;
            //case 7: //Usable
            //    Use(hit);
            //    break;
            default:
                break;
        }
        agent.SetDestination(dest);
    }

    private void Interact(GameObject hit)
    {
        interactWith = hit.GetComponent<Interactuable>();
        if (interactWith == null)
            return;
        if (interactWith.getStandPosition() != null)
        {
            dest = interactWith.getStandPosition().position;
        }
        interacting = true;
    }

    private bool Use(GameObject hit)
    {
        Usable useWith = hit.GetComponent<Usable>();
        GameObject item = Inventory.instance.GetGrabbedItem();
        if (item != null && useWith != null)
        {
            useWith = hit.GetComponent<Usable>();
            bool b = useWith.Use(item);
            if (!b)
                return false;
            PlayerAnimation.instance.Interact();
            return true;
        }
        return false;
    }
    
    private void CheckInteract()
    {
        Vector3 playerPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 destinationPosition = new Vector3(dest.x, 0f, dest.z);
        if (Vector3.Distance(playerPosition, destinationPosition) < 0.15f)
        {
            interactWith.Interact(true);
            interacting = false;
        }
    }

    void OnDisable(){
        stepSound.release();
    }
}
