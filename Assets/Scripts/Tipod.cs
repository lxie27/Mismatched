using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipod : MonoBehaviour
{
    [SerializeField]
    private PlayerControl player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Collided");
            player.moveForce -= 330f;
            // TODO Animation tipod?
        

            StartCoroutine(threeSecs());
        }
    }

    IEnumerator threeSecs()
    {

        yield return new WaitForSeconds(3f);
        player.moveForce = player.originalForce;
        this.gameObject.SetActive(false);
    }

}
