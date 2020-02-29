using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    [SerializeField]
    private GameObject[] collectibles;
    private float distanceBtwClouds = 3f;

    private float minX, maxX;

    private float lastCloudPositionY;

    private float controlX;

    private bool hasTouchedCloudYet = false;

    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        controlX = 0;
        setMinAndMaxX();
        CreateClouds();
        DeactivateCollectables();
        player = GameObject.Find("Player");
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        PositionPlayer();
    }

    void DeactivateCollectables(){
        foreach(GameObject collectable in collectibles){
            collectable.SetActive(false);
        }
    }

    void setMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -(bounds.x - 0.5f);

    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    void CreateClouds()
    {

        float positionY = 0f;

        float controlX = 0f;

        Shuffle(clouds);
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            lastCloudPositionY = positionY;

            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            clouds[i].transform.position = temp;

            positionY -= distanceBtwClouds;
        }
    }

    void PositionPlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkClouds.Length; i++)
        {
            Vector3 darkCloudPos = darkClouds[i].transform.position;

            if (darkCloudPos.y == 0)
            {
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                                cloudsInGame[0].transform.position.y,
                                                                cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = darkCloudPos;
            }

        }
        Vector3 tempPos = cloudsInGame[0].transform.position;
        //Find pos with the lowest Y value
        for (int i = 1; i < cloudsInGame.Length; i++)
        {
            if (tempPos.y < cloudsInGame[i].transform.position.y)
            {
                tempPos = cloudsInGame[i].transform.position;
            }
        }

        Debug.Log(tempPos.y);
        tempPos.y += player.transform.localScale.y * 1.2f;
        player.transform.position = tempPos;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud" || other.tag == "Deadly")
        {
            if(!hasTouchedCloudYet){
                player.GetComponent<PlayerScore>().InitializeCounting();
                hasTouchedCloudYet = true;
            }
            if (other.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                // Shuffle(collectibles);

                Vector3 temp = other.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }
                        temp.y -= distanceBtwClouds;
                        lastCloudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].gameObject.SetActive(true);

                        if(clouds[i].tag != "Deadly"){
                            int collectableIndex = Random.Range(0, collectibles.Length);
                            GameObject currCollectible = collectibles[collectableIndex];
                            if(!currCollectible.activeInHierarchy){

                                if(currCollectible.tag == "Life"){
                                    // Not giving more than 2 lifes
                                    if(PlayerScore.lifeCount >= 2){
                                        return;
                                    }
                                }
                                Vector3 collectablePos = clouds[i].transform.position;
                                // Some space btw the cloud and the collectible
                                collectablePos.y += 0.7f;
                                currCollectible.transform.position = collectablePos;
                                currCollectible.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }
}
