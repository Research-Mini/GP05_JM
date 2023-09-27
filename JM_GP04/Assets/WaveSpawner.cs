using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    private void Awake()
    {
        var winBaseCollider = FindObjectOfType<WinBaseCollider>();
        if (winBaseCollider != null)
        {
            winBaseCollider.WinEvent.AddListener(ChangeWin);
        }
        else
        {
            Debug.LogError("WinBaseCollider instance not found!");
        }

        var loseBaseCollider = FindObjectOfType<LoseBaseCollider>();
        if (loseBaseCollider != null)
        {
            loseBaseCollider.LoseEvent.AddListener(ChangeLose);
        }
        else
        {
            Debug.LogError("LoseBaseCollider instance not found!");
        }
        var waterlosecollider = FindObjectOfType<waterlose>();
        if (waterlosecollider != null)
        {
            waterlosecollider.WaterLoseEvent.AddListener(ChangeLose);
        }
        else
        {
            Debug.LogError("waterlosecollider instance not found!");
        }
    }

    private void ChangeWin()
    {
        SceneManager.LoadScene("WinScene");
    }

    private void ChangeLose()
    {
       
        SceneManager.LoadScene("LoseScene");
    }



    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, delay);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
        
        

    }

    // Update is called once per frame
    void Spawn()
    {
        turn();
        Instantiate(prefab, transform.position+RandomSpawnPosition(), transform.rotation);
    }

    void EndSpawner()
    {
        CancelInvoke();
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 random = Vector3.zero;

        random.x = UnityEngine.Random.Range(-10, 10);
        random.z = UnityEngine.Random.Range(-10, 10);
        return random;
    }
    private void turn()
    {
        var euler = transform.eulerAngles;
        euler.y = Random.Range(0.0f, 360.0f);
        transform.eulerAngles = euler;
    }

    

 
}
