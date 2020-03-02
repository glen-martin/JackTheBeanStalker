using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderController : MonoBehaviour
{

    [SerializeField]
    private GameObject fader;

    [SerializeField]
    private Animator animator;

    public static FaderController instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GetOrCreateSingleton();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInAnimation(level));
    }

    IEnumerator FadeInAnimation(string levelName)
    {
        fader.SetActive(true);
        animator.Play("FadeInAnimation");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));
        SceneManager.LoadScene(levelName); ;
        FadeOut();
    }

    IEnumerator FadeOutAnimation()
    {
        animator.Play("FadeOutAnimation");
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        fader.SetActive(false);
    }

    public void FadeIn(string levelName)
    {
        StartCoroutine(FadeInAnimation(levelName));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }
}
