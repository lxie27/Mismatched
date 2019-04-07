using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public float rotateSpeed;

    //private BoxCollider2D bg;

    private bool isOn;
    private bool isRotating;
    Object[] Walls;


    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 90f;
        isRotating = false;
        isOn = true;
        this.transform.parent.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        Walls = GameObject.FindGameObjectsWithTag("Wall");
    }



    private void OnMouseDown()
    {

        RotateObject();

    }

    void RotateObject()
    {
        
        transform.parent.transform.Rotate(0, 0, 45f, Space.World);
        
    }
   

    // Update is called once per frame
    void Update()
    {
        //if(isOn)
        //{


        //    isOn = false;
        //}
    }
}
