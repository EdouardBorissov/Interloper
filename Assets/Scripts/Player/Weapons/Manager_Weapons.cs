using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//eddie borissov

public class Manager_Weapons : MonoBehaviour
{
    public Abstract_Gun currentGun;
    public GameObject gunObject;
    public TextMeshProUGUI ammoText;

    public List<Abstract_Gun> gunList = new List<Abstract_Gun>();
    public static Manager_Weapons instance;
    
    private void Start()
    {
        instance = this;
        gunObject = currentGun.gameObject;
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = "" + currentGun.currentLoadedAmmo + " / " + currentGun.currentReserveAmmo;
        
    }

    public void SwitchWeapon(int weaponNum)
    {
        foreach(Abstract_Gun gun in gunList)
        {
            if(gun.weaponIndex == weaponNum && gun.playerHasThisGun)
            { // if player has the weapon in question
                gunObject.SetActive(false);
                currentGun = gun;
                gunObject = gun.gameObject;
                gunObject.SetActive(true);
                UpdateAmmoUI();
            }
        }        
    }

}
