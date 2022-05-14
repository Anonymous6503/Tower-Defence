using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagements : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void LoadGameScene()

    {
        SceneManager.LoadScene("GameScene");
    }

    public void Restart()
    {
        GameManager.instance._isGameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
    
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
