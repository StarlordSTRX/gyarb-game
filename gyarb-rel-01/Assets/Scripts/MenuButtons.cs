using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    public void PlayButton(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("We Quit!");
    }
}
