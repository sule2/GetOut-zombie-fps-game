using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunBasla : MonoBehaviour
{
    [SerializeField] Canvas baslatCanvas;
    [SerializeField] Canvas kapatIkonCanvas;
    void Start()
    {
        kapatIkonCanvas.enabled = true;
        baslatCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<SilahDegistir>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    public void OyunuBaslat()
    {
        
        Time.timeScale = 1;
        baslatCanvas.enabled = false;
        FindObjectOfType<SilahDegistir>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
