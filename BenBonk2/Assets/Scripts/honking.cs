using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honking : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Honk if you are too close to them [front]
            FindObjectOfType<audiomanager>().Play("Honking");
        }
        
    }
}
