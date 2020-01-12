using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Gun_Shotgun : Abstract_Gun
{

    public float numberOfPellets;
    public float shotSpread = .1f;

    private RaycastHit hitObject;
    private Vector3 spread;

    public GameObject impactParticle;

    public override void FireGun()
    {
        //if has enough ammo, fire, if not,  try to reload, if not enough reserves, play trigger click noise
        if (currentLoadedAmmo > maxLoadedAmmo)
        { // If any ammo loaded, fire!
            GunShakeCamera();
            --currentLoadedAmmo;
            weaponManager.UpdateAmmoUI();
            //Play Shootsound!
            //Play muzzle flash!

            for (int i = 0; i < numberOfPellets; i++)
            {
                //  Debug.Log("player has shot: " + i + " pellets");

                spread = new Vector3(Random.Range(-shotSpread, shotSpread), Random.Range(-shotSpread, shotSpread), 0);

                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward + spread, out hitObject, 500))
                { // if bullets hit anything

                    GameObject bulletImpact = Instantiate(impactParticle, hitObject.point, hitObject.transform.rotation); //make impact vfx
                    Destroy(bulletImpact, 3); //destroy those vfx afterwards (can probably be made cleaner)

                    //Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward + spread, Color.red, 2); //DRAW RAY just to see the spread

                    //Debug.Log(hitObject.collider.name + " was hit");

                    if ((hitObject.collider.gameObject.transform.parent != null))
                    { //if thing hit has a parent (might have to rework later

                        if (hitObject.collider.gameObject.transform.parent.GetComponent<TestHealth>() != null)
                        { //if thing hit has TestHealth

                            hitObject.collider.gameObject.transform.parent.GetComponent<TestHealth>().DamageHealth(damagePerAmmo);

                        } //end collider TestHealth if

                    } // end collider parent if

                } //end raycast if

            } //end for loop
        }
        else if (currentLoadedAmmo <= maxLoadedAmmo)
        { // no ammo loaded
            //play "no loaded ammo sound" probably a click or something
            if (currentReserveAmmo > 0)
            { // if we have ammo left over, reload
                Reload();
            }
            else if (currentReserveAmmo <= 0)
            {
                //play "no reserve ammo sound"
            }
        }

    }

    public override void Reload()
    {
        if (currentLoadedAmmo < maxLoadedAmmo)
        {//check if we even need to reload

            float ammoToLoad = maxLoadedAmmo - currentLoadedAmmo;

            //will have to play certain animations here, but after they're done VVV

            for (int i = 0; i < ammoToLoad; i++)
            {
                if (currentReserveAmmo > 0 && currentLoadedAmmo < maxLoadedAmmo)
                {//load ammo until we can't any more!
                    currentLoadedAmmo++;
                }
                else
                {//stops the loop if we run out of ammo or are full!
                    break;
                }
            }
            weaponManager.UpdateAmmoUI(); //update the weapon UI
        }

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

    public override void GunShakeCamera()
    {
        CameraShaker.Instance.ShakeOnce(3, 3, .1f, .3f, new Vector3(0f, -0.05f, 0.50f), new Vector3(0f, 0f, 0f));
    }
}
