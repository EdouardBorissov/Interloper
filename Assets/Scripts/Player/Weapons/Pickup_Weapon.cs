using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Weapon : MonoBehaviour
{ 
    public int weaponIndex;
    public int ammoGained;

    private bool weaponOwned;


    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            foreach(Abstract_Gun gun in collision.gameObject.GetComponent<Manager_Weapons>().gunList)
            {
                if(gun.weaponIndex == weaponIndex)
                {
                    Debug.Log("Shotgun detected!");
                    gun.AddGunAmmoReserve(ammoGained);
                    if(!gun.playerHasThisGun)
                    {
                        Debug.Log("Shotgun Added!");
                        gun.playerHasThisGun = true;
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
