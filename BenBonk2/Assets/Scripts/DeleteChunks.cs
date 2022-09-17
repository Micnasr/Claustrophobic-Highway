using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteChunks : MonoBehaviour
{
    [SerializeField]
    float distance;
    Vector3 target;
    GameObject targetGameObject;
    void Start()
    {
        if (targetGameObject == null)
            targetGameObject = GameObject.FindWithTag("Player");
        target = targetGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        distance = target.x - gameObject.transform.position.x ;
        if ((distance * -1) < 40)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
