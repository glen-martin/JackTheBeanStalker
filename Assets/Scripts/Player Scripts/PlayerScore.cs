using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private bool countScore = false;
    private CameraScript cameraScript;
    private Vector3 prevPos;

    public static float coinCount;
    public static float lifeCount;
    public static float scoreCount;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();

    }

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
        countScore = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < prevPos.y)
            {
                // TODO: Default score is 70 because the player moves a bit before hitting the first cloud.
                scoreCount += Mathf.RoundToInt(Mathf.Abs(prevPos.y - transform.position.y) * 10);
            }
            prevPos = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
    }

    public void InitializeCounting(){
        countScore = true;
        // Since score is calculated based on distance moved also,
        // re-setting the prevPos to the currentPos should ensure 0 score at the beginning
        prevPos = transform.position;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            other.gameObject.SetActive(false);

            GameplayController.instance.SetCoinScore(coinCount);
            GameplayController.instance.SetScore(scoreCount);

        }
        else if (other.tag == "Deadly")
        {
            lifeCount --;
            cameraScript.moveCamera = false;
            countScore = false;
            Vector3 newPos = new Vector3(500, 500 ,0);
            transform.position = newPos;

            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
        else if (other.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;
            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            other.gameObject.SetActive(false);

            GameplayController.instance.SetLifeScore(lifeCount);
            GameplayController.instance.SetScore(scoreCount);

        }
        else if (other.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            lifeCount--;
            Vector3 newPos = new Vector3(500, 500 ,0);
            transform.position = newPos;
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
    }
}
