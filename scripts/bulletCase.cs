using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCase : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector2 mousePos;
    public GameObject explode;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 vc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z));
        mousePos.x = vc.x;
        mousePos.y = vc.y;
        rb.AddForce(mousePos * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "mesile")
        {
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(col.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().score += 5.0f;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().Play("shake");
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "nade")
        {
            Instantiate(explode, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().Play("shake");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "mesile") 
        {

            Instantiate(explode, transform.position, transform.rotation);
            Destroy(col.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().score += 2.5f;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().Play("shake");
            Destroy(gameObject);

            
        }
        if (col.gameObject.tag == "nade")
        {
            Instantiate(explode, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().Play("shake");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }



}
