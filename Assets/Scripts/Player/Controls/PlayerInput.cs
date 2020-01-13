using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EZCameraShake;

//https://docs.unity3d.com/Packages/com.unity.inputsystem@0.2/api/UnityEngine.InputSystem.Interactions.html

public class PlayerInput : MonoBehaviour
{
    //test comment
    private PlayerNewInput playerControlInput = null;
    public Manager_Weapons weaponManager;

    private Vector2 previous;
    private Vector2 _down;

    private int jumpTimer;
    private bool jump;

    private void Awake()
    {
        playerControlInput = new PlayerNewInput();
    }

    private void OnEnable()
    {
        playerControlInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerControlInput.Player.Disable();
    }


    public Vector2 input
    {

        get
        {
            Vector2 i = Vector2.zero;
            //i.x = Input.GetAxis("Horizontal");
            // i.y = Input.GetAxis("Vertical");
            i.x = playerControlInput.Player.Movement.ReadValue<Vector2>().x;
            i.y = playerControlInput.Player.Movement.ReadValue<Vector2>().y;
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i.normalized;
        }
    }

    public Vector2 down
    {
        get { return _down; }
    }

    public Vector2 raw
    {
        get
        {
            Vector2 i = Vector2.zero;
            // i.x = Input.GetAxisRaw("Horizontal");
            //  i.y = Input.GetAxisRaw("Vertical");
            i.x = playerControlInput.Player.Movement.ReadValue<Vector2>().x;
            i.y = playerControlInput.Player.Movement.ReadValue<Vector2>().y;
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i.normalized;
        }
    }

    public bool run
    {
        get { return Keyboard.current.leftShiftKey.isPressed; }
    }

    public bool crouch // Was GetKeyDown
    {
        get { return Keyboard.current.leftCtrlKey.wasPressedThisFrame; }
    }

    public bool crouching // Was GetKey
    {
        get { return Keyboard.current.leftCtrlKey.isPressed; }
    }


    void Start()
    {
        jumpTimer = -1;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        { weaponManager.SwitchWeapon(1); }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        { weaponManager.SwitchWeapon(2); }




        if (Input.GetButtonDown("Fire1"))
        {
            weaponManager.currentGun.FireGun();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weaponManager.currentGun.Reload();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("ALL AMMO!");
            weaponManager.currentGun.SetGunAmmoReserve(weaponManager.currentGun.maxReserveAmmo);
            weaponManager.UpdateAmmoUI();
        }

        _down = Vector2.zero;
        if (raw.x != previous.x)
        {
            previous.x = raw.x;
            if (previous.x != 0)
                _down.x = previous.x;
        }
        if (raw.y != previous.y)
        {
            previous.y = raw.y;
            if (previous.y != 0)
                _down.y = previous.y;
        }
    }

    public void FixedUpdate()
    {

        //if (!Input.GetKey(KeyCode.Space))
        if (!Keyboard.current.spaceKey.isPressed)
        {
            jump = false;
            jumpTimer++;
        }
        else if (jumpTimer > 0)
        {
            jump = true;
        }

    }

    public bool Jump()
    {
        return jump;
    }

    public void ResetJump()
    {
        jumpTimer = -1;
    }
}
