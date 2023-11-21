using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab; 

    
    void OnCollisionEnter(Collision collision)
    {
        // "bullet" 레이어의 숫자 값을 얻습니다.
        int bulletLayer = LayerMask.NameToLayer("bullet");

       
        if (collision.gameObject.layer == bulletLayer)
        {
            Instantiate(particlePrefab, transform.position, transform.rotation); 
            Destroy(gameObject); 
        }
    }
}