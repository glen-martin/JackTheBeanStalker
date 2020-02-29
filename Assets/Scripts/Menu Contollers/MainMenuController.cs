using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void StartGame(){
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Gameplay Scene");
    }
    public void OptionsMenu(){
        SceneManager.LoadScene("Options Menu");
    }
    public void HighScoreMenu(){
        SceneManager.LoadScene("High Score Menu");
    }
    public void MusicButton(){
        
    }
    public void Quit(){
        
    }

}
