using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraController : MonoBehaviour
{
    public Camera thisCamera;
    protected static Camera lastCamera;
    protected GameManager gm;
    protected Transform parent;
    private void Start()
    {
        if (lastCamera == null) lastCamera = Camera.main;
        thisCamera.enabled = thisCamera.gameObject.CompareTag("MainCamera");
        gm = GameManager.instance;
        gm.CurrentCamera = thisCamera;
        parent = thisCamera.transform.parent;
    }
}
