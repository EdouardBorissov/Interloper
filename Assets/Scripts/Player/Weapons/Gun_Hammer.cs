using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Hammer : Abstract_Gun
{
    private RaycastHit hitObject;

    /// <summary>
    /// A random number to determing which swing anim to play!
    /// </summary>
    private float randSwing;

    public override void FireGun()
    {
        if (canFire)
        { //swing hammer!

            // randSwing = Random.Range(0.0f, 3.0f); // (inclusive, inclusive)
            randSwing = 1;

            if (randSwing <= 1)
            { // 0 - .99
                gunAnimator.SetTrigger("isSwingOne");
            }
            else if(randSwing <= 2)
            { // 1 - 1.99
                gunAnimator.SetTrigger("isSwingTwo");
            }
            else if(randSwing <= 3)
            { // 2 - 2.99
                gunAnimator.SetTrigger("isSwingThree");
            }
            else
            {// in case I did my math wrong or something
                gunAnimator.SetTrigger("isSwingOne");
            }        
        }
    }



    public void HammerSwingCheck()
    {//Called at the end of each swing anim
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitObject, 2f))
        { // if hammer hit anything
            Debug.Log("Hammer hit: " + hitObject.collider.gameObject.name);
            if (randSwing <= 1)
            { // 0 - .99
                gunAnimator.SetTrigger("isSwingImpactOne");
            }
            else if (randSwing <= 2)
            { // 1 - 1.99
                gunAnimator.SetTrigger("isSwingImpactTwo");
            }
            else if (randSwing <= 3)
            { // 2 - 2.99
                gunAnimator.SetTrigger("isSwingImpactThree");
            }
            else
            {// in case I did my math wrong or something
                gunAnimator.SetTrigger("isSwingImpactOne");
            }

            if ((hitObject.collider.gameObject.transform.parent != null))
            { //if thing hit has a parent (might have to rework later)

                if (hitObject.collider.gameObject.transform.parent.GetComponent<TestHealth>() != null)
                { //if thing hit has TestHealth

                    hitObject.collider.gameObject.transform.parent.GetComponent<TestHealth>().DamageHealth(damagePerAmmo);

                } //end collider TestHealth if

            } // end collider parent if

        } //end raycast if
        else
        { // hit nothing but air

            if (randSwing <= 1) //randSwing value should still be set from when we first swung!
            { // 0 - .99
                gunAnimator.SetTrigger("isSwingMissOne");
            }
            else if (randSwing <= 2)
            { // 1 - 1.99
                gunAnimator.SetTrigger("isSwingMissTwo");
            }
            else if (randSwing <= 3)
            { // 2 - 2.99
                gunAnimator.SetTrigger("isSwingMissThree");
            }
            else
            {// in case I did my math wrong or something
                gunAnimator.SetTrigger("isSwingMissOne");
            }
        }
    }

   
    public override void GunShakeCamera()
    {
        throw new System.NotImplementedException();
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

}
