using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class timer : MonoBehaviour
{

    public float time_to_stop = 0f;
   
    void Start()
    {
        StartCoroutine(interval());
    }

    public void stop()
    {
        Time.timeScale = 0f;
    }
    public void play()
    {
        Time.timeScale = 1f;
    }
   
    IEnumerator interval()
    {
        yield return new WaitForSeconds(time_to_stop);
        Time.timeScale = 0f;
    }
    public void restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void QUit()
    {
        Application.Quit();
    }
   
}
