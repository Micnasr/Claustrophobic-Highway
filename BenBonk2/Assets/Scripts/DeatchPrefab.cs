using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeatchPrefab : MonoBehaviour
{
    
    void Start()
    {
       
        gameObject.transform.parent = null;
        StartCoroutine(Death());

        
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
