using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreMenuController : MonoBehaviour
{

    [SerializeField]
    private Text HighScoreText, CoinScore;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetScoreByDifficulty();
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void SetScore(int score, int coinScore)
    {
        HighScoreText.text = score.ToString();
        CoinScore.text = coinScore.ToString();
    }

    void SetScoreByDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyScore(), GamePreferences.GetEasyDifficultyCoinScore());
        }
        else if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyScore(), GamePreferences.GetMediumDifficultyCoinScore());
        }
        else if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyScore(), GamePreferences.GetHardDifficultyCoinScore());
        }
    }
}
