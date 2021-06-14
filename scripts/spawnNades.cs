using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNades : MonoBehaviour
{
    public Transform point1, point2;
    public GameObject nade;
    void Start()
    {
        StartCoroutine(nad());
      
    }
    IEnumerator nad()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 10f));
        if (GameObject.FindGameObjectWithTag("nade") == null)
        {

            Vector2 spawner = new Vector2(Random.Range(12.6f, -12.6f), 17.66f);
            Instantiate(nade, spawner, nade.transform.rotation);
        }
        StartCoroutine(nad());

    }
  
}
