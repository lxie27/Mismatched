using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpout : MonoBehaviour
{
    public GameObject droplet;

    //speed of droplets
    private float baseSpeed = 1000.0f;
    public float speedMultiplier;
    private float dropletSpeed;

    //direction the spout is facing
    public Vector2 facingDirection;

    //how long each droplet should live
    public float dropletLifetime = 5.0f;

    //maximum amount of droplets allowed to exist
    public float maxDroplets = 1000f;

    //the smaller this is the faster it will generate
    public float genRate = .001f;
    
    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = speedMultiplier;
        dropletSpeed = speedMultiplier * baseSpeed;
        StartCoroutine(On());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator On()
    {
        while (true)
        {
            yield return new WaitForSeconds(genRate);
            GameObject drop = Instantiate(Resources.Load("Droplet") as GameObject, transform.position, transform.rotation);
            drop.GetComponent<Rigidbody2D>().AddForce(facingDirection * dropletSpeed);
            Destroy(drop, dropletLifetime);
        }

        
    }
}
