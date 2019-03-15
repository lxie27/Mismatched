using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private ClothesPool cp;

    [SerializeField]
    private SimplePlatformController player;

    public Vector3 clothesPos;

    public float timer;

    private bool isRunning = false;

    private System.Random rand;

    private float clothesXSpawnPos;

    public int spawnNumClothes = 0;


    private void Start()
    {
        rand = new System.Random();
    }

    private void spawnClothes()
    {
        Clothes temp = cp.GetFromPool();
        // set the position this far from the player always. 
        
        clothesXSpawnPos = player.transform.position.x + Random.Range(-80f, 20f);
        temp.transform.position = new Vector3(clothesXSpawnPos,1.2f * Camera.main.orthographicSize+ player.transform.position.y, 0);
        clothesPos = temp.transform.position;
        temp.isActive = true;
        temp.gameObject.SetActive(true);

    }

    private IEnumerator spawnEnemies()
    {
        isRunning = true;
        spawnNumClothes = rand.Next(1, 5);
        if(cp.clothesList.Count >= 0)
        {
            timer = Random.Range(4f, 4f);
            yield return new WaitForSeconds(timer);
            
            // spawn the clothes
            for(int k = 0; k < spawnNumClothes; ++k)
            {
                Debug.Log(spawnNumClothes);
                spawnClothes();
                //cp.checkOverlap();
            }
            
        }

        isRunning = false;

    }

    

    

    private void Update()
    {
        if(!isRunning) { StartCoroutine(spawnEnemies());  }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
    }

}
