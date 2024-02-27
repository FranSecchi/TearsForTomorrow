using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceElevatorButton : MonoBehaviour, Usable
{
    public void Use(GameObject item)
    {
        
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_ElevBtn))
        {
            item.transform.position = transform.position;
            item.transform.parent = transform;
        }
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
