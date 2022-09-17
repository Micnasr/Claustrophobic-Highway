using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICarAI : MonoBehaviour
{
    [SerializeField]
    List<Material> Colors = new List<Material>();

    public GameObject body;

    public float speed = 2f;
    void Start()
    {
        int r = Random.Range(0, Colors.Count);
        body.GetComponent<Renderer>().material = Colors[r];
        gameObject.transform.parent = null;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + speed * Time.deltaTime);
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }


}
