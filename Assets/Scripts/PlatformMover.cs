using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public bool horizontal;
    public GameObject platform;
    private Vector3 origin;
    public float offset;

    void Start()
    {
        origin = platform.transform.localPosition;
    }

    void Update()
    {
        if (horizontal)
        {
            offset = Mathf.Sin(Time.time) * origin.x;
            platform.transform.localPosition = new Vector3(offset, 0, 0);
        }
        else
        {
            offset = Mathf.Cos(Time.time) * origin.y;
            platform.transform.localPosition = new Vector3(0, offset, 0);
        }
    }
    
}
