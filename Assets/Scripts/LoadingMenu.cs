using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingMenu : MonoBehaviour
{
    public Image loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGameAsync());
    }
    
    IEnumerator LoadGameAsync()
    {
        AsyncOperation level = SceneManager.LoadSceneAsync(2);
        while (level.progress < 1)
        {
            loadingBar.fillAmount = level.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
