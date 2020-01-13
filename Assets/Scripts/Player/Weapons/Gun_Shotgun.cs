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
        if (currentLoadedAmmo > 0 && canFire)
        { // If any ammo loaded, fire!

            gunAnimator.SetTrigger("isShooting");
            
            GunShakeCamera();
            --currentLoadedAmmo;
            weaponManager.UpdateAmmoUI();
            //Play Shootsound!
            //Play muzzle flash!

            for (int i = 0; i < numberOfPellets; i++)
            {
                //  Debug.Log("player has shot: " + i + " pellets");

                spread = new Vector3(Random.Range(-shotSpread, shotSpread), Random.Range(-shotSpread, shotSpread), Random.Range(-shotSpread, shotSpread));

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
        else if (currentLoadedAmmo <= 0)
        { // no ammo loaded
            canFire = false;
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

        //Used by animator and set back to true. Prevents spamming reload during anim.
        if (currentLoadedAmmo < maxLoadedAmmo)
        {//check if we even need to reload

            if (currentReserveAmmo >= 0 && canReload)
            {
                canReload = false; //used by animator, set true at end of reloading anim
                float ammoToLoad = maxLoadedAmmo - currentLoadedAmmo;

                if(ammoToLoad == 1)
                {
                    gunAnimator.SetTrigger("isReloadingOne");
                }
                else if(ammoToLoad == 2)
                {
                    gunAnimator.SetTrigger("isReloadingTwo");
                }

                for (int i = 0; i < ammoToLoad; i++)
                {
                    if (currentReserveAmmo > 0 && currentLoadedAmmo < maxLoadedAmmo)
                    {//load ammo until we can't any more!
                        currentLoadedAmmo++;
                        currentReserveAmmo--;
                    }
                    else
                    {//stops the loop if we run out of ammo or are full!
                        break;
                    }
                } // end for

                weaponManager.UpdateAmmoUI(); //update the weapon UI
            }
            
        }
    }

    public override void GunShakeCamera()
    {
        CameraShaker.Instance.ShakeOnce(3, 3, .1f, .3f, new Vector3(0f, -0.05f, 1f), new Vector3(0f, 0f, 0f));
    }

}
