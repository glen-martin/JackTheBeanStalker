using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyScore = "EasyDifficultyScore";
    public static string MediumDifficultyScore = "MediumDifficultyScore";
    public static string HardDifficultyScore = "HardDifficultyScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";


    // Integers will be used to represent Boolean values
    // 0 is false and 1 is true

    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, difficulty);
    }

    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, difficulty);
    }

    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, difficulty);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }
    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }

    public static void SetMusicOn(int musicOn)
    {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, musicOn);
    }

    public static int GetMusicOn()
    {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }

    public static void SetEasyDifficultyScore(int diffcultyScore)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyScore, diffcultyScore);
    }

    public static void SetMediumDifficultyScore(int diffcultyScore)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyScore, diffcultyScore);
    }

    public static void SetHardDifficultyScore(int diffcultyScore)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyScore, diffcultyScore);
    }

    public static int GetEasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyScore);
    }
    public static int GetMediumDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyScore);
    }
    public static int GetHardDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyScore);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }
    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }
    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }

    public static void SetEasyDifficultyCoinScore(int score){
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, score);
    }
    public static void SetMediumDifficultyCoinScore(int score){
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, score);
}
    public static void SetHardDifficultyCoinScore(int score){
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, score);
    }

}
