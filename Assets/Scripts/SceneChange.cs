using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour {

    public void playWasPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void optionsWasPressed()
    {
        SceneManager.LoadScene(2);
    }

    public void backWasPressed()
    {
        SceneManager.LoadScene(0);
    }
}
