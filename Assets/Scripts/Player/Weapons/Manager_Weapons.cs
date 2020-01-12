using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager_Weapons : MonoBehaviour
{
    public Abstract_Gun currentGun;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = "" + currentGun.currentLoadedAmmo + " / " + currentGun.currentReserveAmmo;
        
    }

}
