using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        CheckToPlayMusic();
    }
    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        FaderController.instance.LoadLevel("Gameplay Scene");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }
    public void HighScoreMenu()
    {
        SceneManager.LoadScene("High Score Menu");
    }
    public void MusicButton()
    {
        if (GamePreferences.GetMusicOn() == 0)
        {
            AudioController.instance.SetMusicStatus(true);
            GamePreferences.SetMusicOn(1);
            musicButton.image.sprite = musicIcons[1];
        }
        else
        {
            AudioController.instance.SetMusicStatus(false);
            GamePreferences.SetMusicOn(0);
            musicButton.image.sprite = musicIcons[0];
        }
    }
    public void Quit()
    {

    }

    void CheckToPlayMusic(){
        if(GamePreferences.GetMusicOn() == 1){
            AudioController.instance.SetMusicStatus(true);
            // Setting it as off button
            musicButton.image.sprite = musicIcons[1];
        }else {
            AudioController.instance.SetMusicStatus(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }

}
