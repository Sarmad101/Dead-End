using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mescile : MonoBehaviour
{
    public GameObject explosion;
    

   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "mesile")
        {

        }
        else
        {
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("collided with player");
                GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().hp_Value -= 5f;
            }
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().Play("shake");
            Destroy(gameObject);
            
        }
    }
}
