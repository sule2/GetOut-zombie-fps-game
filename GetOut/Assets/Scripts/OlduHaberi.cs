using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlduHaberi : MonoBehaviour
{
    [SerializeField] Canvas oyunBittiCanvas;

    private void Start()
    {
        oyunBittiCanvas.enabled = false;
    }
    public void HaberVer()
    {
        oyunBittiCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<SilahDegistir>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
