using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using RedBlueGames.MulliganRenamer;
//Användbara namespaces(I typ alla ljud scripts).
using STOP_MODE = FMOD.Studio.STOP_MODE; //Tar bort pretensen till Stop_mode

public class Ws2 : MonoBehaviour
{
    public float timer = 5f;
    
    public EventInstance eventInstance; //Gör en kopia av eventet. Kan användas både public och private,
                                        //kan inte ses i inspektorn.
    public EventReference eventReference; //länka det faktiska eventet i Fmod, kan ses i inspektorn.
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if (timer >= 5f) //Stop test.
        //{
            //eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); Används om inte namespace är inskrivet.
            //eventInstance.stop(STOP_MODE.IMMEDIATE); //Stoppar ljudet direkt, finns även fade o.s.v
        //}
        if (timer >= 10f && timer <= 19f)
        {
            //Ändrar parametern i fmod.
            eventInstance.setParameterByName("ProgressInt", 1, false); //sista false är för "seek speed"
        }

        if (timer >= 20f && timer <= 29f)
        {
            eventInstance.setParameterByName("ProgressInt", 2); //är sista inte med är "seek speed" true by default.
        }
        
        if (timer >= 30f)
        {
            eventInstance.setParameterByName("ProgressInt", 3);
        }
    }
}
