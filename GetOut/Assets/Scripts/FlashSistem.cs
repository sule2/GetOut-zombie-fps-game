using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSistem : MonoBehaviour
{
    [SerializeField] float isikBozunum = .1f;
    [SerializeField] float aciBozunum = 1f;
    [SerializeField] float minAci = 40f;

    Light isik;

    private void Start()
    {
        isik = GetComponent<Light>();
    }

    private void Update()
    {
        IsikAciAzal();
        IsikParlaklikAzal();
    }

    public void IsikAciYenile(float aciYenile)
    {
        isik.spotAngle = aciYenile;
    }
    public void IsikParlaklikEkle(float parlaklikMiktar)
    {
        isik.intensity += parlaklikMiktar;
    }

    private void IsikAciAzal()
    {
        if(isik.spotAngle <= minAci)
        {
            return;
        }
        else
        {
            isik.spotAngle -= aciBozunum * Time.deltaTime;
        }
    }

    private void IsikParlaklikAzal()
    {
        isik.intensity -= isikBozunum * Time.deltaTime;
    }
}
