using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class thrower : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    public float speed;
    Camera cam;
    public GameObject explosion;
    public GameObject grabText;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            if (GameObject.FindGameObjectWithTag("grab").GetComponent<graber>().hold || GameObject.FindGameObjectWithTag("grab2").GetComponent<graber>().hold)
            {
                GameObject.FindGameObjectWithTag("grab").GetComponent<graber>().hold = false;
                GameObject.FindGameObjectWithTag("grab2").GetComponent<graber>().hold = false;
                GameObject.FindGameObjectWithTag("grab").GetComponent<graber>().pressed = true;
                GameObject.FindGameObjectWithTag("grab2").GetComponent<graber>().pressed = true;
                isforce();
            }
        }
    }
    void isforce()
    {
        /*  mousePos = Input.mousePosition;
          Debug.Log(mousePos);
         // transform.LookAt(mousePos);
         */
        /*  var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          mousePos=mousePos - transform.position;
          mousePos.Normalize();
          var mouseDir = mousePos;
          mousePos.z = 0.0f;
          Debug.Log(mousePos);
        */

        Vector3 vc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, cam.transform.position.z));
        mousePos.x = vc.x;
        mousePos.y = vc.y;

        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, cam.transform.position.z)));
        

        rb.gravityScale = 1;
        rb.AddForce(mousePos * speed);

        StartCoroutine(fix());
        
    }
    IEnumerator fix()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject.FindGameObjectWithTag("grab").GetComponent<graber>().pressed = false;
        GameObject.FindGameObjectWithTag("grab2").GetComponent<graber>().pressed = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "mesile")
        {
            Debug.Log("collision");
            GameObject.Instantiate(explosion, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().score += 5.0f;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().Play("shake");
            Destroy(col.gameObject);
            Destroy(gameObject);
            
        }
        if(col.gameObject.tag=="Player")
        {
            grabText.SetActive(true);
        }
        else
        {
            grabText.SetActive(false);
        }
    }
}
