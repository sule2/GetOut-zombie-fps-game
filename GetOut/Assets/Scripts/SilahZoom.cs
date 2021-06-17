using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SilahZoom : MonoBehaviour
{
    [SerializeField] Camera fpsKamera;
    [SerializeField] RigidbodyFirstPersonController fpsKontroller;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutHassaslik = 2f;
    [SerializeField] float zoomInHassaslik = 0.5f;
    bool zoomDurum = false;    
    private void OnDisable()
    {
        zoomOut();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomDurum == false)
            {
                zoomIn();
            }
            else
            {
                zoomOut();
            }
        }
    }
    private void zoomOut()
    {
        zoomDurum = false;
        fpsKamera.fieldOfView = zoomedOutFOV;
        fpsKontroller.mouseLook.XSensitivity = zoomOutHassaslik;
        fpsKontroller.mouseLook.YSensitivity = zoomOutHassaslik;
    }

    private void zoomIn()
    {
        zoomDurum = true;
        fpsKamera.fieldOfView = zoomedInFOV;
        fpsKontroller.mouseLook.XSensitivity = zoomInHassaslik;
        fpsKontroller.mouseLook.YSensitivity = zoomInHassaslik;
    }
}
