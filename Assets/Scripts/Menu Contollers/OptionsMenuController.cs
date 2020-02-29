using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    public void GoBack(){
       SceneManager.LoadScene("Main Menu");
   }
}
