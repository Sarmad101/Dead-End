using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnJets : MonoBehaviour
{
    public Transform point_Left, point_Right;
    public GameObject jet_Left, jet_Right;
    void Start()
    {
        StartCoroutine(jet());
    }

    
    IEnumerator jet()
    {
        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        if (Random.Range(1, 3) == 2)
        {
            Instantiate(jet_Left, point_Left.position, point_Left.rotation);
        }
        else
        {
            Instantiate(jet_Right, point_Right.position, point_Right.rotation);
        }
        StartCoroutine(jet());
    }
}
