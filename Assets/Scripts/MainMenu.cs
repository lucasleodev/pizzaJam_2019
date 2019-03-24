using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayGame();
        CloseGame();
    }

    void PlayGame()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }

    void CloseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            Application.Quit(); 
        }
    }
}
