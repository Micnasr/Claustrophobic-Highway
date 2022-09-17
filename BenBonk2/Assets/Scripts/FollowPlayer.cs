using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    float offset;

    void Start()
    {
        offset = transform.position.x - Player.transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(Player.transform.transform.position.x + offset, transform.position.y, Player.transform.position.z);
    }
}
