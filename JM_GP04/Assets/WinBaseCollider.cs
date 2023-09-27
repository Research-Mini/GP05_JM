using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinBaseCollider : MonoBehaviour
{
    public UnityEvent WinEvent;

    private void Start()
    {
        if (WinEvent == null)
            WinEvent = new UnityEvent();
       
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        // Rigidbody 컴포넌트 추가
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

            WinEvent.Invoke();
        }
    }
}