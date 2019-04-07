using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTurn : MonoBehaviour
{
    private float rot;
    private float speed;
    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        rot = 0.0f;
        speed = Random.Range(1.0f, 4.0f);

        int coinflip = Random.Range(1, 10);
        if (coinflip >= 5.0f)
        {
            dir = -1.0f;
        }
        else
            dir = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rot += Time.deltaTime * speed * dir;
        this.transform.localRotation = Quaternion.Euler(0, 0, rot);
    }
}
