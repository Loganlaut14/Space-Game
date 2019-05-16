using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuButtons : MonoBehaviour {
    public Dropdown drop;
    public void NewGame()
    {
        if (drop.value == 1)
        {
            SceneManager.LoadScene("Level1H");
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }
    public void NewHard()
    {
        SceneManager.LoadScene("Level1H");
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
