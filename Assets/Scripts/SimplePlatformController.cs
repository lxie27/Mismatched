using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool whip = false;

    public GameObject lash;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    public bool pullback = false;
    public Vector2 pullVector;
    public Vector2 mouseInitPosition;
    public Vector2 mouseEndPosition;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


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

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
            rb2d.AddForce(-pullVector * maxSpeed);
            Debug.Log("Moving player in direction of x: " + -pullVector.x + ", y:" + -pullVector.y);
            pullVector = new Vector2(0.0f, 0.0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
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

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
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
        pullback = true;
    }

    void OnMouseUp()
    {
        Debug.Log("mouse up"); 
        mouseEndPosition = Input.mousePosition;
        Debug.Log("mouse down at " + mouseEndPosition.x + ", " + mouseEndPosition.y);
        pullback = false;
        pullVector.x = (mouseEndPosition.x - mouseInitPosition.x) * 2;
        pullVector.y = (mouseEndPosition.y - mouseInitPosition.y) / 2;
    }
}