using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAtak : MonoBehaviour
{
    OyuncuSaglik hedef;
    [SerializeField] float hasar = 30f;
    void Start()
    {
        hedef = FindObjectOfType<OyuncuSaglik>();
    }
    public void AtakEtki()
    {
        if (hedef == null)
            return;

        hedef.HasarAldi(hasar);
        hedef.GetComponent<HasarGoster>().DarbeGoster();
    }
}
