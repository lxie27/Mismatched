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
        origin = this.transform.localPosition;
        offset = offset;
    }

    void Update()
    {
        if (horizontal)
        {
            offset = (Mathf.Sin(Time.time) * 5.0f + origin.x);
            gameObject.transform.localPosition = new Vector3(offset, origin.y, origin.z);
        }
        else
        {
            offset = (Mathf.Sin(Time.time) * 5.0f + origin.y);
            gameObject.transform.localPosition = new Vector3(origin.x, offset, origin.z);
        }
    }
    
}
