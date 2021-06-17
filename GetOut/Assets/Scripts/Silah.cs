using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Silah : MonoBehaviour
{
    [SerializeField] Camera FPKamera;
    [SerializeField] float kapsam = 100f;
    [SerializeField] float hasar = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject atisEfekt;
    [SerializeField] Ammo ammoTur;
    [SerializeField] AmmoTip ammoTip;
    [SerializeField] float vurusArasiSure = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    bool durumAtis = true;
    AudioSource[] m_MyAudioSource;
    private void OnEnable()
    {
        durumAtis = true; 
    }
    void Start()
    {
        m_MyAudioSource = GetComponents<AudioSource>();
        
    }
    void Update()
    {
        AmmoGoster();
        if (Input.GetMouseButtonDown(0) && durumAtis == true)//GetButtonDown("Fire1") could have been used as ctrl but for consistency gotta limit the player with only mouse option
        {
            StartCoroutine(Atis());
        }
    }
    private void AmmoGoster()
    {
        int kalanAmmo = ammoTur.getAnlikAmmo(ammoTip);
        ammoText.text = kalanAmmo.ToString();
    }
    IEnumerator Atis()
    {
        durumAtis = false;
        if (ammoTur.getAnlikAmmo(ammoTip) > 0)
        {
            MuzzleFlashCalistir();
            ProcessRaycast();
            ammoTur.AnlikAmmoAzalt(ammoTip);
        }
        else
        {
            m_MyAudioSource[1].Play();

        }
        yield return new WaitForSeconds(vurusArasiSure);
        durumAtis = true;

    }
    private void MuzzleFlashCalistir()
    {
        muzzleFlash.Play();
        m_MyAudioSource[0].Play();
    }
    private void ProcessRaycast()
    {
        RaycastHit atis;
        if (Physics.Raycast(FPKamera.transform.position, FPKamera.transform.forward, out atis, kapsam))
        {
            AtisEtki(atis);
            
            ZombiSaglik target = atis.transform.GetComponent<ZombiSaglik>();
            if (target == null)
                return;
            target.HasarAldi(hasar);
        }
        else
        {
            return;
        }
    }
    private void AtisEtki(RaycastHit hit)
    {
       GameObject impact =  Instantiate(atisEfekt, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
