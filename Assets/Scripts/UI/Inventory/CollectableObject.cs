using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //something que refrencia al inventario y coloque en el primer objeto de la lista un hijo al slot con el item y cambie la imagen
            Destroy(gameObject);
        }
    }
}
