using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject prefab;
    
    public GameObject shootPoint;

    // Update is called once per frame
    public void OnFire(InputValue value)
    {
        if (value.isPressed) 
        {
            //Instantiate(prefab, transform.position,transform.rotation);
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }

    }


}
