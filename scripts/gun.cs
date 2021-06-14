using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    Vector2 mousePos;
    public GameObject bullet , pos , muzle;

    void Update()
    {
        Vector3 vc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, GameObject.FindGameObjectWithTag("MainCamera").transform.position.z));
        mousePos.x = vc.x;
        mousePos.y = vc.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        // transform.LookAt(mousePos);

        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bullet, pos.transform.position, pos.transform.rotation);
            muzle.SetActive(true);
            StartCoroutine(muzzle());
        }
    }
    IEnumerator muzzle()
    {
        yield return new WaitForSeconds(0.4f);
        muzle.SetActive(false);
    }
}
