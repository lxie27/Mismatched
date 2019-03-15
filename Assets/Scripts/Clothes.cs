using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{


    public bool isActive;

    public Clothes()
    {
        isActive = false;
    }

    // speed of the clothes
    public float speed = 10f;


    private void Update()
    {
        if(this.isActive)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        } 
    }

    
}
