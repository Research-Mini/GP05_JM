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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
            Debug.Log("Lose Event Invoked!");
            LoseEvent.Invoke();
        }
    }
}