using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera_Interact : CameraController, Interactuable
{
    public void Interact(bool activate)
    {
        if (activate)
        {
            gm.CurrentCamera = thisCamera;
            lastCamera.enabled = false;
            thisCamera.enabled = true;
        }
        else
        {
            lastCamera.gameObject.GetComponent<Camera>().enabled = true;
            thisCamera.gameObject.GetComponent<Camera>().enabled = false;
            gm.CurrentCamera = lastCamera;
        }
    }

}
