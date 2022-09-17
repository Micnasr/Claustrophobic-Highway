using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    [SerializeField]
    List<Material> Colors = new List<Material>();

    [SerializeField]
    Rigidbody rb;

    public GameObject Player;

    public float speed = 1f;
    void Start()
    {
        int r = Random.Range(0, Colors.Count);
        gameObject.GetComponent<Renderer>().material = Colors[r];

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //move car straight
        rb.velocity = new Vector3(-speed, 0, 0);

        float distanceFromPoint = Vector3.Distance(Player.transform.position, transform.position);
        if (distanceFromPoint > 40)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }

    }
    public void IncreaseSpeed()
    {
        speed *= 2;
    }

    //incase they spawn on each other
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
