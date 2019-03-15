using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public bool horizontal;
    private Vector3 origin;
    public float offset;

    void Start()
    {
        origin = gameObject.transform.localPosition;
    }

    void Update()
    {
        if (horizontal)
        {
            offset = (Mathf.Sin(Time.time) + origin.x) * 5.0f;
            gameObject.transform.localPosition = new Vector3(offset, 0, 0);
        }
        else
        {
            offset = (Mathf.Sin(Time.time) + origin.y) * 5.0f;
            gameObject.transform.localPosition = new Vector3(0, offset, 0);
        }
    }
    
}
