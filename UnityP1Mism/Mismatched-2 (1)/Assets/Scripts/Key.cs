using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<Player>().setHasKey(true);
            gameObject.SetActive(false);
            
            // log of who got the key
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
