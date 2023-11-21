using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseBaseCollider : MonoBehaviour
{
    public UnityEvent LoseEvent;

    private void Start()
    {
        if (LoseEvent == null)
            LoseEvent = new UnityEvent();

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
        if (other.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            Debug.Log("Lose Event Invoked!");
            LoseEvent.Invoke();
        }
    }
}