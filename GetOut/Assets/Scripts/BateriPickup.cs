using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriPickup : MonoBehaviour
{
    [SerializeField] float aciYenile = 90f;
    [SerializeField] float parlaklikEkle = 1f;

    private void OnTriggerEnter(Collider diger)
    {
        if(diger.gameObject.tag == "Player")
        {
            diger.GetComponentInChildren<FlashSistem>().IsikAciYenile(aciYenile);
            diger.GetComponentInChildren<FlashSistem>().IsikParlaklikEkle(parlaklikEkle);
            Destroy(gameObject);
        }
    }
}
