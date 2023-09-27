using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class waterlose : MonoBehaviour
{
    public UnityEvent WaterLoseEvent;
    public float delay = 1f;

    private void Start()
    {
        if (WaterLoseEvent == null)
            WaterLoseEvent = new UnityEvent();

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            gameObject.AddComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            

            Invoke("InvokeWaterLoseEvent", delay);
        }
    }
    private void InvokeWaterLoseEvent()
    {
        Debug.Log("WaterLose Event Invoked!");
        WaterLoseEvent.Invoke();
    }
}