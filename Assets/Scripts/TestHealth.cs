using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    public float testHealth = 100;
    
    public void DamageHealth(float damage)
    {
        Debug.Log(gameObject.name + " health before " + damage + " damage.");
        testHealth -= damage;
        Debug.Log(gameObject.name + " health after " + damage + " damage.");
    }
}
