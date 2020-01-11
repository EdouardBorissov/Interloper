using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Weapons : MonoBehaviour
{
    public static Manager_Weapons instance;

    public Abstract_Gun currentGun;

    public void OnEnable()
    {
        instance = this;
    }



}
