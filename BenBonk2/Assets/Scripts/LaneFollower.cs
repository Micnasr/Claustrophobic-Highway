using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneFollower : MonoBehaviour
{
    public GameObject player;

    float offset;

    void Start()
    {
        offset = transform.position.x - player.transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
