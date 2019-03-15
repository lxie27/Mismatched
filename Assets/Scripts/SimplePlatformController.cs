using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{
    public GameObject player;
    
    public bool pullback = false;
    public Vector2 pullVector;
    public Vector2 throwVector;
    public Vector2 mouseInitPosition;
    public Vector2 mouseEndPosition;
    private float maxPullback = 300.0f;
    
    private Rigidbody2D rb2d;
    private float validX;
    private float validY;

    [HideInInspector]
    public bool facingRight = true;			// For determining which way the player is currently facing.

    public float jumpForce = 20f;
    public float moveForce = 2.0f;          // Amount of force added to move the player left and right.
    public float originalForce;
    public float maxSpeed = 5.0f;              // The fastest the player can travel in the x axis.
    public AudioClip[] taunts;              // Array of clips for when the player taunts.
    public float tauntProbability = 50f;    // Chance of a taunt happening.
    public float tauntDelay = 1f;           // Delay for when the taunt should happen.


    private int tauntIndex;                 // The index of the taunts array indicating the most recent taunt.
    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;          // Whether or not the player is grounded.
    private Animator anim;					// Reference to the player's animator component.

    // Use this for initialization
    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        validX = player.transform.localPosition.x;
        validY = player.transform.localPosition.y;
    }

    private void Start()
    {
        originalForce = moveForce;
    }

    // Update is called once per frame
    void Update() 
    {
        grounded = Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), LayerMask.GetMask("Ground"));
        if (Input.GetMouseButtonDown(0) && 
            grounded &&
            ((validX - 5.0f) <= Input.mousePosition.x && Input.mousePosition.x <= (validX + 5.0f)) &&
            ((validY - 5.0f) <= Input.mousePosition.y && Input.mousePosition.y <= (validY + 5.0f)))
        {
            OnMouseDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
        
        if (rb2d.velocity.y < 2.0f && rb2d.velocity.y > -2.0f)
        {
            grounded = true;
        } 
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (pullback && grounded)
        {
            rb2d.AddForce(-pullVector);
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
    }

    void OnMouseUp()
    {

        mouseEndPosition = Input.mousePosition;

        pullVector.x = (mouseEndPosition.x - mouseInitPosition.x) * 2.0f;

        pullVector.y = (mouseEndPosition.y - mouseInitPosition.y) * 5.0f;

        pullVector.x *= 2.0f;
        pullVector.y *= 2.0f;
        pullback = true;
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "GroundCheck")
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }


    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "GroundCheck")
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }
}