using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    public int timePassed = 0;
    bool canCount = true;
    void Update()
    {
        if (canCount)
        {
            canCount = false;
            StartCoroutine(count());
        }
    }
    IEnumerator count()
    {
        yield return new WaitForSeconds(1);
        timePassed += 1;
        canCount = true;
    }
}
