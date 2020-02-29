using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterDeath;

    [HideInInspector]
    public float score, coinCount, lifeCount;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GetOrCreateSingleton();
    }
    
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode mode){
        if(scene.name == "Gameplay Scene"){
            if(gameStartedFromMainMenu){
                score = 0;
                coinCount = 0;
                lifeCount = 2;

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinCount;
                PlayerScore.lifeCount = lifeCount;

                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinCount);
                GameplayController.instance.SetLifeScore(lifeCount);
            }else if(gameRestartedAfterDeath){
                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinCount;
                PlayerScore.lifeCount = lifeCount;

                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinCount);
                GameplayController.instance.SetLifeScore(lifeCount);
            }
        }
    }
    void GetOrCreateSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(float score, float coinCount, float lifeCount){
        if(lifeCount < 0){
            gameStartedFromMainMenu = false;
            gameRestartedAfterDeath = false;

            GameplayController.instance.GameOver(score, coinCount);
        }else{
            gameRestartedAfterDeath = true;
            gameStartedFromMainMenu = false;
            this.score = score;
            this.lifeCount = lifeCount;
            this.coinCount = coinCount;

            GameplayController.instance.RestartGame();
        }
    }
}
