using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera_Interact : CameraController, Interactuable
{
    public Transform StandPosition;
    public Transform getStandPosition()
    {
        return StandPosition;
    }

    public void Interact(bool activate)
    {
        if(parent == null)
        {
            return;
        }
        if (activate)
        {
            gm.CurrentCamera = thisCamera;
            lastCamera.enabled = false;
            thisCamera.enabled = true;
            //lastCamera = thisCamera;
        }
        else
        {
            lastCamera.gameObject.GetComponent<Camera>().enabled = true;
            thisCamera.gameObject.GetComponent<Camera>().enabled = false;
            gm.CurrentCamera = lastCamera;
        }
    }

}
