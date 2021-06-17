using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoMiktar = 5;
    [SerializeField] AmmoTip ammoTip;
    private void OnTriggerEnter(Collider diger)
    {
        if(diger.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().AnlikAmmoArtir(ammoTip, ammoMiktar);
            Destroy(gameObject);
        }
    }
}
