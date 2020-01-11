using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for (int i = 0; i < numberOfPellets; i++)
        {
            //  Debug.Log("player has shot: " + i + " pellets");

            spread = new Vector3(Random.Range(-shotSpread, shotSpread), Random.Range(-shotSpread, shotSpread), 0);


            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward + spread, out hitObject, 500))
            {
                GameObject bulletImpact = Instantiate(impactParticle, hitObject.point, hitObject.transform.rotation);
                Destroy(bulletImpact, 3);
                Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward + spread, Color.red, 2);

                Debug.Log(hitObject.collider.name + " was hit");

                if ((hitObject.collider.gameObject.transform.parent != null))
                {
                    if (hitObject.collider.gameObject.transform.parent.GetComponent<TestHealth>() != null)
                    {
                        hitObject.collider.gameObject.transform.parent.GetComponent<TestHealth>().DamageHealth(damagePerAmmo);
                    }
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
