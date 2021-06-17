using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkorTutucu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI skorText;
    public int olenZombi = 0;
    void Update()
    {
        SkorGoster();
    }
    public void SkorGoster()
    {
        skorText.text = olenZombi.ToString();
    }
    public void SkorYenile()
    {
        olenZombi++;
    }
}
