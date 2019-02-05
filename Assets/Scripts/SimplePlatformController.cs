using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool whip = false;

    public GameObject lash;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public Transform groundCheck;

    public bool pullback = false;
    public Vector2 pullVector;
    public Vector2 mouseInitPosition;
    public Vector2 mouseEndPosition;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    private float validPullRadius = 5.0f + transform.localPosition.x;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            OnMouseDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        //if (h * rb2d.velocity.x < maxSpeed)
        //    rb2d.AddForce(Vector2.right * h * moveForce);

        //if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        //    rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();


        if (pullback && grounded)
        {
            rb2d.AddForce(-pullVector * 2.0f);
            pullback = false;
        }
        else
        {
            pullVector = new Vector2(0.0f, 0.0f);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnMouseDown()
    {
        mouseInitPosition = Input.mousePosition;
        Debug.Log("mouse down at " + mouseInitPosition.x + ", " + mouseInitPosition.y);
    }

    void OnMouseUp()
    {
        Debug.Log("mouse up");
        mouseEndPosition = Input.mousePosition;
        Debug.Log("mouse down at " + mouseEndPosition.x + ", " + mouseEndPosition.y);
        pullVector.x = (mouseEndPosition.x - mouseInitPosition.x) * 2.0f;
        pullVector.y = (mouseEndPosition.y - mouseInitPosition.y) * 2.0f;
        pullback = true;
    }
}