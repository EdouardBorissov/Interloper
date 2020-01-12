using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Combat Variables")]

    [Tooltip("How often the gun can be used.")]
    /// <summary>
    /// How often (in float seconds) the gun can be used.
    /// </summary>
    public float rateOfFire;
    public bool canFire = true;
    public bool canReload = true;
    public float damagePerAmmo;
    public List<Transform> muzzle;
    public ParticleSystem muzzleFlash;


    

    [Header("Ammo Variables")]

    [Tooltip("How much ammo is currently in the gun.")]
    /// <summary>
    /// The ammo currently loaded in the gun.
    /// </summary>
    public float currentLoadedAmmo;

    protected Camera mainCamera;
    protected Manager_Weapons weaponManager;

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

    /// <summary>
    /// The animator on each gun, used to trigger various animations.
    /// </summary>
    public Animator gunAnimator;


    public void Start()
    {
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

    public abstract float GetGunDamage();

    public abstract void SetGunDamage(float newAmount);

    public abstract float GetGunAmmoReserve();

    public abstract void SetGunAmmoReserve(float newAmount);


}
