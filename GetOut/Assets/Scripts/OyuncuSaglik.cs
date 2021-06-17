using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuSaglik : MonoBehaviour
{
    [SerializeField] float saglikMiktar = 100f;
    [SerializeField] float anlikSaglik;
    [SerializeField] Canvas saglikbarCanvas;
    AudioSource [] m_MyAudioSource;

    public SaglikBar saglikBar;
    int i = 0;

    void Start()
    {
        anlikSaglik = saglikMiktar;
        saglikBar.SetMaxSaglikMiktar(saglikMiktar);
        saglikbarCanvas.enabled = true;
        m_MyAudioSource = GetComponents<AudioSource>();
    }

    public void HasarAldi(float hasar)
    {
        anlikSaglik -= hasar;
        saglikBar.SetSaglik(anlikSaglik);
        if (anlikSaglik <= 0)
        {
            GetComponent<OlduHaberi>().HaberVer();
        }
        m_MyAudioSource[i].Play();
        i++;
        if (3 < i)
            i = 0;
    }
}
