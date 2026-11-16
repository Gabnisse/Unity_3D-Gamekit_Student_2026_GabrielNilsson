using System;
using UnityEngine;
using Gamekit3D;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private string playerTag;
    
    Hunger hungerScript;

    private void Start()
    {
        hungerScript = GameObject.Find("HungerManager").GetComponent<Hunger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            other.GetComponent<Damageable>().ResetDamage();
            hungerScript.ResetHunger();
            Destroy(gameObject);
        }
    }
}
