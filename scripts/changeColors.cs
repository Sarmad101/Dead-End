using UnityEngine;
using System.Collections;
public class changeColors : MonoBehaviour
{

    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(color());
    }

    
    IEnumerator color()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 4f));
        if (Random.Range(0, 5) == 1)
        {
            m_SpriteRenderer.color = Color.blue;
        }else if (Random.Range(0, 5) == 2)
        {
            m_SpriteRenderer.color = Color.green;
        }else if (Random.Range(0, 5) == 3)
        {
            m_SpriteRenderer.color = Color.red;
        }else if (Random.Range(0, 5) == 4)
        {
            m_SpriteRenderer.color = Color.black;
        }else if (Random.Range(0, 5) == 5)
        {
            m_SpriteRenderer.color = Color.yellow;
        }
        StartCoroutine(color());
    }
}
