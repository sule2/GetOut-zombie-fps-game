using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunSonu : MonoBehaviour
{
    [SerializeField] Canvas tebriklerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        tebriklerCanvas.enabled = false;
    }
    public void Bitir()
    {
        tebriklerCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<SilahDegistir>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void OnTriggerEnter(Collider diger)
    {
        if (diger.gameObject.CompareTag("CheckPoint"))
        {
            Bitir();
        }
    }
}
