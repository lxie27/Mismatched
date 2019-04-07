using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{

    private int workOnce;
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        workOnce = 0;
        transform.eulerAngles = Vector3.zero;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (workOnce == 0)
        {
            Debug.Log("collision detected11111");
            if (collision.gameObject.CompareTag("Player"))
            {
                float angle = transform.eulerAngles.z % 180;


                Debug.Log(angle);
                Debug.Log(player.getDirection());
                if (player.getDirection() && Mathf.Abs(angle - 135f) < .05f)
                {
                    // when going to the right,
                    Debug.Log("Go up!");
                    player.gameObject.transform.position += Vector3.up * 30;
                   
                }
                else if (Mathf.Abs(angle - 45f) < .05f && !player.getDirection())
                {
                    // when going to the left
                    Debug.Log("Go up2");
                    player.gameObject.transform.position += Vector3.up * 30;
                }
                else
                {
                    Debug.Log("switching directions");
                    player.setDirection(!player.getDirection());
                    player.getSR().flipX = !player.getSR().flipX;
                }
            }
            workOnce = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        workOnce = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
