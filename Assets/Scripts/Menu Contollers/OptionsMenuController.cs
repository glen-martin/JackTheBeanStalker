using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;
    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetTheDifficulty();
    }
    void SetInitalDifficultyState(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "medium":
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                break;
        }
    }

    void SetTheDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetInitalDifficultyState("easy");
        }
        else if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetInitalDifficultyState("medium");
        }
        else if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetInitalDifficultyState("hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreferences.SetEasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDiffulty()
    {
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetHardDifficulty(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty()
    {
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }
}
