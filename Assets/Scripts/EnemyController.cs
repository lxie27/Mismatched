using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    private bool rotate = false;
    private float rotateSpeed = 200.0f;
    private float x;
    void Start()
    {
        rotate = true;
        x = 0.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        float xPos = this.transform.localPosition.x;
        float pPos = player.transform.localPosition.x;

        if (pPos - xPos > 0)
        {
            this.transform.localPosition = new Vector2(this.transform.localPosition.x + .1f, this.transform.localPosition.y);
        }
        else
            this.transform.localPosition = new Vector2(this.transform.localPosition.x - .1f, this.transform.localPosition.y);

        if (rotate)
        {
            x += Time.deltaTime * rotateSpeed;
        }

        transform.localRotation = Quaternion.Euler(0, 0, x);
    }
}
