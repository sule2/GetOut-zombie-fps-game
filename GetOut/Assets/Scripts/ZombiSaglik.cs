using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSaglik : MonoBehaviour
{
    [SerializeField] float saglikMiktar = 100f;
    public SkorTutucu skor;
    bool bittiMi = false;
    public bool yasamDurum()
    {
        return bittiMi;
    } 
    public void HasarAldi(float hasar)
    {
        BroadcastMessage("HasarAlinca");
        saglikMiktar -= hasar;
        if(saglikMiktar <= 0)
        {
            Olum();
        }
    }
    private void Olum()
    {
        if (bittiMi) return;
        bittiMi = true;
        GameObject.Find("Oyuncu").GetComponent<SkorTutucu>().SkorYenile();
        GetComponent<Animator>().SetTrigger("die");       
    }
}
