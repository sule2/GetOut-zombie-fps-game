using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYukle : MonoBehaviour
{
    public void OyunYukle()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void OyunCikis()
    {
        Application.Quit();
    }
}
