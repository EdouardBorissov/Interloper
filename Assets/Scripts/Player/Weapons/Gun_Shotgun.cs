using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Shotgun : Abstract_Gun
{

    public float numberOfPellets;
    public float shotSpread = .5f;

    private RaycastHit hitObject;
    private Vector3 spread;
    public override void FireGun()
    {
        //if has enough ammo, fire, if not,  try to reload, if not enough reserves, play trigger click noise

        for (int i = 0; i < numberOfPellets; i++)
        {

            spread = new Vector3(Random.Range(-shotSpread, shotSpread), Random.Range(-shotSpread, shotSpread), 0);


            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward + spread, out hitObject))
            {

                if(hitObject.collider.gameObject.GetComponent<TestHealth>() != null)
                {
                    hitObject.collider.gameObject.GetComponent<TestHealth>().DamageHealth(damagePerAmmo);
                }

            }

        }
    }

    public override void Reload()
    {

    }

    public override float GetGunAmmoReserve()
    {
        return currentReserveAmmo;
    }

    public override void SetGunAmmoReserve(float newAmount)
    {
        currentReserveAmmo = newAmount;
    }

    public override float GetGunDamage()
    {
        return damagePerAmmo;
    }

    public override void SetGunDamage(float newAmount)
    {
        damagePerAmmo = newAmount;
    }

}
