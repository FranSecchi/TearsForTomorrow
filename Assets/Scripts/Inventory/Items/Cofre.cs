using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, Usable
{

    public void Use(ItemInfo item)
    {
        Debug.Log("llega");
        if (item.nameKey.Equals(Parameter.Str_CofreKey))
        {
            OpenCofre();
        }
    }

    private void OpenCofre()
    {
        Debug.Log("open");
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
