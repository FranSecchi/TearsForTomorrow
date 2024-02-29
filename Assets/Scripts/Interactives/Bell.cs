using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour,Interactuable
{
    public GameObject position;
    public Transform getStandPosition()
    {
        return position.transform;
    }
    public void Interact(bool activate)
    {
        SoundManager.playBell();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
