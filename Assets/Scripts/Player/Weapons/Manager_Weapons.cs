using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Manager_Weapons : MonoBehaviour
{
    public Abstract_Gun currentGun;
   // public TextMeshProUGUI currentAmmoText;
  //  public TextMeshProUGUI reserveAmmoText;

    public void UpdateAmmoUI()
    {
        //currentAmmoText.text = "" + currentGun.currentLoadedAmmo;
       // reserveAmmoText.text = "" + currentGun.currentReserveAmmo;
    }

}
