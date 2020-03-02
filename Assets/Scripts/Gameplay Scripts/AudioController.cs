using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;
    private AudioSource audioSource;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GetOrCreateSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMusicStatus(bool musicOn){
        if(!audioSource.isPlaying && musicOn){
            audioSource.Play();
        }else if(audioSource.isPlaying && !musicOn){
            audioSource.Stop();
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
}
