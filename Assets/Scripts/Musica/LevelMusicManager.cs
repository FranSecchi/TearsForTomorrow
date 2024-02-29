using System.Collections;
using System.Collections.Generic;
using System.Data;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
public enum Times{
    Past,
    Present,
    Future
}
public enum States{
    True,
    False
}
public class LevelMusicManager : MonoBehaviour
{
    public EventReference LevelMusic;

    FMOD.Studio.EventInstance musicInstance;
    public Times time;
    public States talkingState;
    public States elevetorState;
    // Start is called before the first frame update
    void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(LevelMusic);
        musicInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void setTime(Times t){
        time = t;
        musicInstance.setParameterByNameWithLabel("Time", time.ToString());
    }
    public void setElevator(States s){
        elevetorState = s;
        musicInstance.setParameterByNameWithLabel("Ascensor", elevetorState.ToString());
    }
    public void setTalking(States s){
        talkingState = s;
        musicInstance.setParameterByNameWithLabel("Talking", talkingState.ToString());
    }
    void OnDisable(){
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();    
    }
}
