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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            Debug.Log("Win Event Invoked!");
            WinEvent.Invoke();
        }
    }
}
