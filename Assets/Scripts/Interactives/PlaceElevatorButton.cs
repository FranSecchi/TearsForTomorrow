using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceElevatorButton : MonoBehaviour, Usable
{
    public bool Use(GameObject item)
    {
        
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_ElevBtn))
        {
            item.transform.position = transform.position;
            item.transform.forward = transform.forward;
            item.transform.parent = transform;
            item.GetComponent<Item>().InteractPanel.SetActive(false);
            Destroy(item.GetComponent<Item>());
            ElevatorDoors ed = item.GetComponent<ElevatorDoors>();
            ed.enabled = true;
            return true;
        }
        return false;
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
