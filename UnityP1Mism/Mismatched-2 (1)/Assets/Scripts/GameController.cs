using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private List<GameObject> players;
    private GameObject[] players2;


    // Start is called before the first frame update
    void Start()
    {

        players = new List<GameObject>();

        players2 = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players2.Length; ++i)
        {
            players2[i].GetComponent<Player>();
            players.Add(players2[i]);
        }
    }

    public void checkWinner()
    {
        
        for (int i = 0; i < players.Capacity; ++i)
        {
            if (players[i].gameObject.GetComponent<Player>().getHasKey()) // TODO win condition add
            {
                Debug.Log("You win!");
                //load scene or exit
            }
        }
    }

    public List<GameObject> getPlayers()
    {
        return players;
    }
    // Update is called once per frame
    void Update()
    {
        checkWinner();
    }
}
