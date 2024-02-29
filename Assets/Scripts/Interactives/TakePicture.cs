using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour, Usable
{
    public ItemInfo foto;
    public bool Use(GameObject item)
    {
        if (item.GetComponent<Item>()._info.nameKey.Equals(Parameter.Str_Polaroid))
        {
            SoundManager.playPhoto();
            Inventory.instance.Add(foto);
            Destroy(this);
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
