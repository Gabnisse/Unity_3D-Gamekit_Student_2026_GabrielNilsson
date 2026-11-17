using System;
using Gamekit3D;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public enum ElementalPower //Nu är den tillgänglig för alla scripts.
{
    None, //namen ses som nummer, none = 0.
    Fire,
    Ice,
    Lightning,
    Earth,
}

[System.Serializable] //Gör infon tillgänglig i inspektorn
public struct CharacterInformation
{
    public string name;
    public ElementalPower power;
    public float speed;
    public int health;
    public bool canFly;
    public float damagePower;
}

public class Ws3Trigger : MonoBehaviour
{
    
    //Här hade Enumen också kunnat stå men då bara för scriptet.

    public ElementalPower elementKraft;
    public CharacterInformation characterInformation;

    public int[] highscores; //Array
    public CharacterInformation[] characterInfoRay;

    public EventInstance eventInstance;
    public EventReference eventReference;
    
    private void Start()
    {
        eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstance.start();
        
        eventInstance.getPlaybackState(out PLAYBACK_STATE state);
        Debug.Log(state.ToString());
        
        switch (elementKraft) //Är som många if satser
        {
            case ElementalPower.Fire: //Case börjar, break avslutar.
                Debug.Log("Fire");
                break;
            case ElementalPower.Ice:
                Debug.Log("Ice");
                break;
            case ElementalPower.Lightning:
                Debug.Log("Lightning");
                break; //osv.
        }

        foreach (CharacterInformation score in characterInfoRay)
        {
            switch (score.name)
            {
                case "Per":
                    Debug.Log("suu");
                    break;
                case "Manne":
                    Debug.Log("mann3");
                    break;
                default:
                    Debug.Log("inget hände"); //default om inget passar.
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Såhää kan man göa.
        if (other.tag == "Player")
        {
            Debug.Log(characterInformation.name + ("stats") + highscores[1]);

            Debug.Log(elementKraft);
        }
        //Har ingen anning vad detta gör

        if (characterInfoRay[0].name == "Per")
        {
            Debug.Log(elementKraft);
        }
    }
}
