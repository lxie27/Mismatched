using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.

    public float originalZoom;
    public float currentZoom;

    public Camera cam;
    public GameObject playerObject; //Reference to the player's game object
	private Transform player;		// Reference to the player's transform.

    private Rigidbody2D rb;

	void Awake ()
	{
        // Setting up the reference.
        originalZoom = cam.orthographicSize;
        currentZoom = originalZoom;
		player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = playerObject.GetComponent<Rigidbody2D>();
	}


	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}


	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}

    void FixedUpdate()
    {
        //currentZoom = originalZoom + rb.velocity.magnitude;
        cam.orthographicSize = currentZoom;
    }
	
}
