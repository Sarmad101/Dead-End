using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=10f;
    public GameObject mesile;
    void Start()
    {
        StartCoroutine(fire());

    }
    IEnumerator fire()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        Instantiate(mesile, transform.position, mesile.transform.rotation);
        StartCoroutine(fire());
    }
}
