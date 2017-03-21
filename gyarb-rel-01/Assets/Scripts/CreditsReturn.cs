using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Threading;

public class CreditsReturn : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }    
    }
    public void MoveOn() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

}
