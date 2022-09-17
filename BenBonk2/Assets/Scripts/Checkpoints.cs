using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField]
    SpawnConfigs spawnConfigs;
    public GameObject spawnManager;
    void Start()
    {
        gameObject.transform.parent = null;
        if (spawnManager == null) 
        {
            spawnManager = GameObject.FindWithTag("spawnmanager");
            spawnConfigs = spawnManager.GetComponent<SpawnConfigs>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnConfigs.SpawnTimeCalculation();
            StartCoroutine(Callfunction());
        }
    }
    IEnumerator Callfunction()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
