using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilahDegistir : MonoBehaviour
{
    [SerializeField] int silahSecim = 0;
    void Start()
    {
        SilahAktif();
    }
    void Update()
    {
        int previousWeapon = silahSecim;
        KullaniciGirisTus();
        KullaniciGirisFare();

        if(previousWeapon != silahSecim)
        {
            SilahAktif();
        }
    }
    private void KullaniciGirisFare()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) 
        {
            if (silahSecim >= transform.childCount - 1) 
            {
                silahSecim = 0;
            }
            else
            {
                silahSecim++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (silahSecim <= 0) 
            {
                silahSecim = transform.childCount - 1;
            }
            else
            {
                silahSecim--;
            }
        }
    }
    private void SilahAktif()
    {
        int silahIndex = 0;

        foreach (Transform silah in transform)
        {
            if(silahIndex == silahSecim)
            {
                silah.gameObject.SetActive(true);
            }
            else
            {
                silah.gameObject.SetActive(false);
            }
            silahIndex++;
        }
    }
    private void KullaniciGirisTus()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            silahSecim = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            silahSecim = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            silahSecim = 2;
        }
    }
}
