using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarGoster : MonoBehaviour
{
    [SerializeField] Canvas darbeCanvas;
    [SerializeField] float darbeZaman = 0.3f;

    void Start()
    {
        darbeCanvas.enabled = false;
    }
    public void DarbeGoster()
    {
        StartCoroutine(KanGoster());
    }
    IEnumerator KanGoster()
    {
        darbeCanvas.enabled = true;
        yield return new WaitForSeconds(darbeZaman);
        darbeCanvas.enabled = false;
    }
    void Update()
    {
        
    }
}
