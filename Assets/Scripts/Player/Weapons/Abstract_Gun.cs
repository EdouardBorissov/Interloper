using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Combat Variables")]
    [Space(30)]
    [Tooltip("How often the gun can be used.")]
    /// <summary>
    /// How often (in float seconds) the gun can be used.
    /// </summary>
    public bool playerHasThisGun = false;
    public int weaponIndex;
    public float rateOfFire;
    public bool canFire = true;
    public bool canReload = true;
    public float damagePerAmmo;
    public List<Transform> muzzle;
    public ParticleSystem muzzleFlash;


    

    [Header("Ammo Variables")]
    [Space(30)]
    [Tooltip("How much ammo is currently in the gun.")]
    /// <summary>
    /// The ammo currently loaded in the gun.
    /// </summary>
    public float currentLoadedAmmo;

    protected Camera mainCamera;
    public Manager_Weapons weaponManager;

    [Tooltip("How ammo can be loaded into the gun.")]
    /// <summary>
    /// How much ammo can currently be loaded into the gun.
    /// </summary>
    public float maxLoadedAmmo; // could be int, but I don't want to run into conversion nonsense down the line.

    [Tooltip("How much reserve ammo the player currently has.")]
    /// <summary>
    /// How much reserve ammo the player currently has.
    /// </summary>
    public float currentReserveAmmo;

    [Tooltip("How much reserve ammo the player can hold.")]
    /// <summary>
    /// How much reserve ammo the player can hold.
    /// </summary>
    public float maxReserveAmmo;

    [Header("Visual Variables")]
    [Space(30)]

    [Tooltip("The weapon's starting position")]
    public Vector3 gunStartPosition;

    [Tooltip("How much the screen shakes per shot.")]
    /// <summary>
    /// How much the screen shakes per shot.
    /// </summary>
    public float screenShakeMagnitude;

    [Tooltip("How long the screen shakes.")]
    /// <summary>
    /// How long the screen shakes per shot.
    /// </summary>
    public float screenShakeDuration;

    [Tooltip("The animator on each gun, used to trigger various animations.")]
    /// <summary>
    /// The animator on each gun, used to trigger various animations.
    /// </summary>
    public Animator gunAnimator;


    public void Start()
    {
        gunStartPosition = gameObject.transform.position;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weaponManager = GameObject.FindGameObjectWithTag("Player").GetComponent<Manager_Weapons>();
        gunAnimator = gameObject.GetComponent<Animator>();
    }


    public abstract void FireGun();

    public void SetCanFireTrue()
    {
        canFire = true;
    }

    public void SetCanFireFalse()
    {
        canFire = false;
    }

    public abstract void GunShakeCamera();

    public abstract void Reload();

    public void SetCanReloadTrue()
    {
        canReload = true;
    }

    public void SetCanReloadFalse()
    {
        canReload = false;
    }

    public float GetGunDamage()
    {
        return damagePerAmmo;
    }

    public void SetGunDamage(float newAmount)
    {
        damagePerAmmo = newAmount;
    }

    public float GetGunAmmoReserve()
    {
        return currentReserveAmmo;
    }

    public void SetGunAmmoReserve(float newAmount)
    {
        currentReserveAmmo = newAmount;
    }

    public void AddGunAmmoReserve(float amountToAdd)
    {
        currentReserveAmmo += amountToAdd;
        if (currentReserveAmmo > maxReserveAmmo)
        {
            currentReserveAmmo = maxReserveAmmo;
        }
        weaponManager.UpdateAmmoUI();
    }


}
