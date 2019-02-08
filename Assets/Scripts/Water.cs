using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject water;

    // Update is called once per frame
    void Update()
    {
        water.transform.localScale = new Vector3(water.transform.localScale.x, 
            Time.time * .05f + water.transform.localScale.y, 0);
    }
}
