using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public float timeScale;


    public void on_Enable()
    {
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(timeScale);
        gameObject.SetActive(false);
    }
   
}
