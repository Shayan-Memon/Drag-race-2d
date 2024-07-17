using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscr : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
