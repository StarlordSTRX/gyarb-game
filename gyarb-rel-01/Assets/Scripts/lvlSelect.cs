using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class lvlSelect : MonoBehaviour {

    public void LevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LevelFour()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
