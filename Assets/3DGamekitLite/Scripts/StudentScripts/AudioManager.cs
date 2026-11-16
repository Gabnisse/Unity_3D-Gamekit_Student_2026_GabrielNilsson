using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class AudioManager : MonoBehaviour
{
    [SerializeField] EventReference eventRef;
    
    EventInstance  eventInstance;
    
    private bool isPlaying = false;

    void Start()
    {
        eventInstance = RuntimeManager.CreateInstance(eventRef);
    }
    
    //Spelar musiken.
    public void playMusic()
    {
        if (isPlaying != true)
        {
            eventInstance.start();
            isPlaying = true;
        }
    }
    
    //Stoppar musiken.
    public void stopMusic()
    {
        if (isPlaying != false)
        {
            eventInstance.stop(STOP_MODE.IMMEDIATE);
            isPlaying = false;
        }
    }

    public void MusicParamaterChange(float value)
    {
        if (isPlaying != false)
        {
            eventInstance.setParameterByName("ExampleParam", value);
        }
    }
}
