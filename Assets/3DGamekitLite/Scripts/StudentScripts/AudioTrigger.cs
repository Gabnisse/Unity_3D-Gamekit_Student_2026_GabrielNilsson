using System;
using UnityEngine;
using Gamekit3D;
using UnityEngine.Events;

//Enkel trigger som använder AudioManager.

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private bool destroyAfterTrig = true;
    
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other) //När spelaren nuddar objektet aktiverar den audioManagerns funk...
    {
        onTrigger.Invoke();

        if (destroyAfterTrig == true)
        {
            Destroy(gameObject);
        }
    }
}
