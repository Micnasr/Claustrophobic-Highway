using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{  
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    int currentLane;

    [SerializeField]
    List<GameObject> lanes = new List<GameObject>();

    [SerializeField]
    GameObject[] chunckPrefabs;

    [SerializeField]
    GameObject[] leftTrees;
    [SerializeField]
    GameObject[] rightTrees;


    AudioSource audioSource;

    public GameObject checkpointPrefab;
    public GameObject checkpointSpawner;

    public Text countDown;
    public Text distanceTravelled;

    float distanceGone;

    float distance;

    float distanceTrees;

    public float timeRemaining = 30;

    public GameObject EndUI;

    void Start()
    {
        currentLane = 2;
        transform.position = new Vector3(transform.position.x, transform.position.y, lanes[1].transform.position.z);

        audioSource = GetComponent<AudioSource>();

        distance = transform.position.x;
        distanceTrees = transform.position.x;

        EndUI.SetActive(false);
        Time.timeScale = 1;

        distanceGone = 0f;
    }


    void Update()
    {
        if (Time.timeScale != 0)
        {
            Movement();
        }
        //engineNoise
        audioSource.pitch = 5 * rb.velocity.magnitude / 30;

        Checkpoint();

        Timer();

        DistanceTravelled();

        CreateTrees();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "checkpoint")
        {
            timeRemaining = timeRemaining + 15;
        }

        if (other.tag == "enemy")
        {
            FindObjectOfType<audiomanager>().Play("Crash");
            EndScreen();
        }
    }

    void Movement()
    {
        if (Input.GetKey("up") || (Input.GetKey(KeyCode.W)))
        {
            //go forward
            rb.AddRelativeForce(Vector3.left * 12000 * Time.deltaTime);

        }
        else if (Input.GetKey("down") || (Input.GetKey(KeyCode.S)))
        {
            if (transform.position.x < 0.5)
            {
                //go backwards
                rb.AddRelativeForce(Vector3.right * 5000 * Time.deltaTime);

            } else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
           
        }
        
        if (Input.GetKeyDown("right") && (currentLane < 4) || (Input.GetKeyDown(KeyCode.D) && (currentLane < 4)))
        {
            currentLane++;
            transform.position = new Vector3(transform.position.x, transform.position.y, lanes[currentLane - 1].transform.position.z);


        }
        else if (Input.GetKeyDown("left") && (currentLane > 1) || (Input.GetKeyDown(KeyCode.A) && (currentLane > 1)))
        {
            currentLane--;
            transform.position = new Vector3(transform.position.x, transform.position.y, lanes[currentLane - 1].transform.position.z);

        }


    }

    void Checkpoint()
    {
        if (transform.position.x < (distance - 32))
        {
            distance = transform.position.x;
            Instantiate(checkpointPrefab, checkpointSpawner.transform);
        }
    }

    void CreateTrees()
    {
        if (transform.position.x < (distanceTrees - 1.5f))
        {
            int r = Random.Range(0, chunckPrefabs.Length);
            distanceTrees = transform.position.x;
            for (int i = 0; i < leftTrees.Length; i++)
            {
                Instantiate(chunckPrefabs[r], leftTrees[i].transform);
            }
            for (int i = 0; i < rightTrees.Length; i++)
            {
                Instantiate(chunckPrefabs[r], rightTrees[i].transform);
            }
            
        }
    }

    void Timer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            countDown.text = timeRemaining.ToString("0.0");
           
            if (timeRemaining < 10)
            {
                countDown.color = Color.red;
            } else
            {
                countDown.color = Color.white;
            }
           


            if (timeRemaining <= 0)
            {
                EndScreen();

            }
        }
    }

    void EndScreen()
    {
        Debug.Log("TIME");
        EndUI.SetActive(true);
        rb.velocity = new Vector3(0, 0, 0);
        Time.timeScale = 0;
    }

    void DistanceTravelled()
    {
        distanceGone = (Mathf.Abs(transform.position.x)) * 10 / 2;
        distanceTravelled.text = distanceGone.ToString("0") + " meters";

        if (transform.position.x > 0)
        {
            distanceTravelled.text = "0 meters";
        }
    }
}

