using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    [SerializeField]
    GameObject[] chunckPrefabs;

    private void Awake()
    {
        CreateTrees();
    }
    void CreateTrees()
    {
        for (float i = 7; i > -1000; i -= 1.5f)
        {
            int r = Random.Range(0, chunckPrefabs.Length);
            Vector3 position = new Vector3(i, transform.position.y, transform.position.z);
            Instantiate(chunckPrefabs[r], position, Quaternion.identity);
        }
    }

    
}
