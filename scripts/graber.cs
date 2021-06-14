using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graber : MonoBehaviour
{
    public bool hold , pressed;
    public KeyCode mouseButton;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(mouseButton) && !pressed)
        {
            
            
                hold = true;
            
        }
        else
        {
            hold = false;
            Destroy(GetComponent<FixedJoint2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (hold)
        {
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                FixedJoint2D fd = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                fd.connectedBody = rb;
            }
            else
            {
                FixedJoint2D fd = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }
    }
}
