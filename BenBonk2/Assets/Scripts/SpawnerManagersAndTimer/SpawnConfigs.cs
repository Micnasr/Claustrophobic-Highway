using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConfigs : MonoBehaviour
{  
    [Header("Scripts")]
    [SerializeField]
    CountDownManager countDownManager;
    [Header("LanesObjects")]
    [SerializeField]
    List<Transform> lanes = new List<Transform>();
    [SerializeField]
    List<GameObject> prefabs = new List<GameObject>();
    [Header("Configs")]
    [SerializeField]
    float time = 1.5f;
    [SerializeField]
    float lessTime = .2f;
    bool readyAgain = true;
    int checkR = 0;
    void Update()
    {
        Spawnfunction();
    }

    void Spawnfunction()
    {
        if (time < .2f)
        {
            time = .2f;
        }
        int r = Random.Range(0, 4);
        int rp = Random.Range(0, prefabs.Count);
        if (readyAgain && rp != checkR)
        {
            Vector3 positionPreFab = new Vector3(lanes[r].position.x, lanes[r].position.y, lanes[r].position.z);
            Instantiate(prefabs[rp], positionPreFab, Quaternion.Euler(-90, 0, -90));
            readyAgain = false;
            checkR = r;
            StartCoroutine(WaitToSpawn(time));
        }
    }

    public void SpawnTimeCalculation()
    {
        if (time != .2f)
            time -= lessTime;

    }

    IEnumerator WaitToSpawn(float wait)
    {
        yield return new WaitForSeconds(wait);
        readyAgain = true;
    }

}
