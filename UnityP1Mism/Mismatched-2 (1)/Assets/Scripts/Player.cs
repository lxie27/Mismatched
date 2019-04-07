using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float gravity = 9.81f;
    public ForceMode2D forceMode;

    private Collider2D coll;

    //left is false, right is true
    private bool direction;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int workOnce;

    

    private bool hasKey;
    private string pName;
    public Player(string name)
    {
        this.pName = name;
        this.hasKey = false;
    }
    void Start()
    {

        workOnce = 0;
        direction = true;
        speed = 0.5f;
        velocity = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        
        hasKey = false;
        
    }

    void Update()
    {
        if (direction)
            velocity = Vector2.right;
        else
            velocity = Vector2.left;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * speed);
        rb.AddForce(Vector3.down * gravity, forceMode);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            direction = !direction;
            sr.flipX = !sr.flipX;
        }
    }

    public bool getDirection()
    {
        return direction;
    }

    public SpriteRenderer getSR()
    {
        return sr;
    }

    public void setDirection(bool isTrue)
    {
        direction = isTrue;
    }

    public void setHasKey(bool hasTKey)
    {
        hasKey = hasTKey;
    }

    public bool getHasKey()
    {
        return hasKey;
    }

 
}
    
