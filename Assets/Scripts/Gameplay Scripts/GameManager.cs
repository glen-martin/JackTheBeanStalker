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
        InitializeGame();
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

    void InitializeGame(){
        if(PlayerPrefs.HasKey("GameInitialized")){
            GamePreferences.SetEasyDifficulty(0);
            GamePreferences.SetEasyDifficultyScore(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);

            // Defaulting to Medium Difficulty
            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetMediumDifficultyScore(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyScore(0);
            GamePreferences.SetHardDifficultyCoinScore(0);

            GamePreferences.SetMusicOn(0);

            PlayerPrefs.SetInt("GameInitialized",1);
            
        }
    }

    public void CheckGameStatus(float score, float coinCount, float lifeCount){
        if(lifeCount < 0){
            gameStartedFromMainMenu = false;
            gameRestartedAfterDeath = false;

            CheckAndUpdateScores(score, coinCount);
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

    private void CheckAndUpdateScores(float score, float coinCount){
        if(GamePreferences.GetEasyDifficulty() ==  1){
            int existingHighScore = GamePreferences.GetEasyDifficultyScore();
            int existingCoinScore = GamePreferences.GetEasyDifficultyCoinScore();

            if(score > existingHighScore){
                GamePreferences.SetEasyDifficultyScore((int) score);
            }
            if(coinCount > existingCoinScore){
                GamePreferences.SetEasyDifficultyCoinScore((int) coinCount);
            }
        }
        if(GamePreferences.GetMediumDifficulty() ==  1){
            int existingHighScore = GamePreferences.GetMediumDifficultyScore();
            int existingCoinScore = GamePreferences.GetMediumDifficultyCoinScore();

            if(score > existingHighScore){
                GamePreferences.SetMediumDifficultyScore((int) score);
            }
            if(coinCount > existingCoinScore){
                GamePreferences.SetMediumDifficultyCoinScore((int) coinCount);
            }
        }
        if(GamePreferences.GetHardDifficulty() ==  1){
            int existingHighScore = GamePreferences.GetHardDifficultyScore();
            int existingCoinScore = GamePreferences.GetHardDifficultyCoinScore();

            if(score > existingHighScore){
                GamePreferences.SetHardDifficultyScore((int) score);
            }
            if(coinCount > existingCoinScore){
                GamePreferences.SetHardDifficultyCoinScore((int) coinCount);
            }
        }
    }
}
