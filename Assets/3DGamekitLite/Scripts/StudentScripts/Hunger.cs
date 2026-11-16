using System;
using UnityEngine;
using Gamekit3D;

public class Hunger : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float damageInterval = 10f;

    private Damageable damageTarget;

    private void Start()
    {
        damageTarget = GameObject.Find("Ellen").GetComponent<Damageable>();
    }

    private void Update()
    {
       timer += Time.deltaTime;

       if (timer >= damageInterval)
       {
           DamageHunger();
           ResetHunger();
       }
    }

    private void DamageHunger()
    {
        Damageable.DamageMessage hungerDamage = new Damageable.DamageMessage
        {
            amount = damageAmount,
            damager = this,
            direction = Vector3.zero,
            damageSource = Vector3.zero,
            throwing = false,
            stopCamera = false,
        };
        damageTarget.ApplyDamage(hungerDamage);
    }

    public void ResetHunger()
    {
        timer = 0f;
    }
}
