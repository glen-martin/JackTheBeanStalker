using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, lifeText, coinText, finalScoreText, finalCoinCountText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel, readyButton, player;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // // Hiding the player
        // player.GetComponent<SpriteRenderer>.enabled = false;
        // Pausing to explicitly start playing by pressing ready
        Time.timeScale = 0f;
    }
    public void PauseGame(){
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void SetCoinScore(float score){
        coinText.text = "x "+ score; 
    }

    public void SetLifeScore(float score){
        lifeText.text = "x "+ score;
    }

    public void SetScore(float score){
        scoreText.text = "x "+ score;
    }

    public void GameOver(float finalScore, float finalCoinCount){
        gameOverPanel.SetActive(true);
        finalCoinCountText.text = "x " + finalCoinCount;
        finalScoreText.text = finalScore.ToString();
        StartCoroutine(TransitionToMainMenu());
    }

    public void RestartGame(){
        StartCoroutine(TransitionToGamePlay());
    }

    IEnumerator TransitionToGamePlay(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Gameplay Scene");
    }

    IEnumerator TransitionToMainMenu(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame(){
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
