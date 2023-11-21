using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab; 

    
    void OnCollisionEnter(Collision collision)
    {
        // "bullet" ���̾��� ���� ���� ����ϴ�.
        int bulletLayer = LayerMask.NameToLayer("bullet");

       
        if (collision.gameObject.layer == bulletLayer)
        {
            Instantiate(particlePrefab, transform.position, transform.rotation); 
            Destroy(gameObject); 
        }
    }
}