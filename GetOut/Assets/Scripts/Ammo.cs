using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoTip ammoTip;
        public int ammoMiktar;
    }

    public int getAnlikAmmo(AmmoTip ammoTip)
    {
        return GetAmmoSlot(ammoTip).ammoMiktar;
    }
    public void AnlikAmmoAzalt(AmmoTip ammoTip)
    {
        GetAmmoSlot(ammoTip).ammoMiktar--;
    }
    public void AnlikAmmoArtir(AmmoTip ammoTip, int ammoMiktar)
    {
        GetAmmoSlot(ammoTip).ammoMiktar += ammoMiktar;
    }

    private AmmoSlot GetAmmoSlot(AmmoTip ammoTip)
    {
        foreach (AmmoSlot slot in ammoSlots) 
        {
            if(slot.ammoTip == ammoTip)
            {
                return slot;
            }
        }
        return null;
    }
}
