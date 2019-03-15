using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPool : MonoBehaviour
{

    [SerializeField]
    public List<Clothes> enemy;

    [SerializeField]
    private SimplePlatformController player;

    [SerializeField]
    private GameController gameControl;

    public List<Clothes> clothesList;

    Clothes[] clArr;

    private float minBorder;
    // Use this for initialization
    void Start()
    {
        clothesList = new List<Clothes>();
        minBorder = player.transform.position.y - Camera.main.orthographicSize;
    }

    public Clothes GetFromPool()
    {
        for (int i = 0; i < clothesList.Count; i++)
        {
            if (!clothesList[i].gameObject.activeInHierarchy)
            {
                return clothesList[i];
            }
        }

        Clothes gen = enemy[Random.Range(0, enemy.Count)];
        Clothes newClothes = Instantiate(gen);
        clothesList.Add(newClothes);
        return newClothes;
    }

    // checks if the platform's y position is higher than the player's y position 
    public void checkPlatformHeight()
    {
        clArr = clothesList.ToArray();

        foreach(Clothes c in clothesList) {
            if(c.gameObject.transform.position.y >= player.gameObject.transform.position.y - 5)
            {
                c.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            } else
            {
                c.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
    }

    //checks if the two clothes overlap each other
    public void checkOverlap()
    {
        clArr = clothesList.ToArray();
        for (int i = 0; i < gameControl.spawnNumClothes; ++i)
        {
            for (int k = 0; k < gameControl.spawnNumClothes; ++k)
            {
                if (Mathf.Abs(clArr[i].gameObject.transform.position.x - clArr[k].gameObject.transform.position.x) < 60)
                {
                    if (clArr[i].gameObject.transform.position.x < clArr[k].gameObject.transform.position.x)
                    {
                        clArr[i].gameObject.transform.position = new Vector3(clArr[i].gameObject.transform.position.x -30, 0, 0);
                    }
                    else
                    {
                        clArr[i].gameObject.transform.position = new Vector3(clArr[i].gameObject.transform.position.x + 30, 0, 0);
                    }
                }
            }
        }
        
    }

    // check if clothes is outside the camera and destroy
    public void checkOutOfBounds()
    {
        Clothes[] clArrs = clothesList.ToArray();
        if (clothesList.Count > 0)
        {
            for (int i = 0; i < clothesList.Count; i++)
            {
                if (clArrs[i].transform.position.y  < minBorder)
                {
                    clArrs[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void giveRotations(Clothes cl)
    {
        float randomRotation = Random.Range(0, 360f);

        cl.transform.rotation = Quaternion.Euler(0, 0, randomRotation);
    }



    private void Update()
    {
        checkOutOfBounds();
        checkPlatformHeight();

    }

}
