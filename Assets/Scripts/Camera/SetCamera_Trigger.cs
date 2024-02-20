using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera_Trigger : CameraController
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.CurrentCamera = thisCamera;
            lastCamera.enabled = false;
            thisCamera.enabled = true;
            lastCamera = thisCamera;
        }
    }
    private void OnDrawGizmos()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + boxCollider.center, transform.localScale);
    }
}
