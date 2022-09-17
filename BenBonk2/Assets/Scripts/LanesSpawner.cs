using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesSpawner : MonoBehaviour
{

    public GameObject CarPrefab;
    [SerializeField]
    List<GameObject> lanes = new List<GameObject>();

    float timer = 1f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int r = Random.Range(0, lanes.Count);
            Instantiate(CarPrefab, lanes[r].transform);
            Debug.Log("spawned");
            timer = 1f;
        }
       
    }
}
