using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaglikBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxSaglikMiktar(float saglikMiktar)
    {
        slider.maxValue = saglikMiktar;
        slider.value = saglikMiktar;
    }
    public void SetSaglik(float saglikMiktar)
    {
        slider.value = saglikMiktar;
    }
}
