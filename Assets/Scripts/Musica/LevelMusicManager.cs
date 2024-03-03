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
    public static EventReference LevelMusic;
    public EventReference LevelMusic_ref;

    static FMOD.Studio.EventInstance musicInstance;
    public static Times time;
    public static States talkingState;
    public static States elevetorState;
    // Start is called before the first frame update
    void Start()
    {
        LevelMusic = LevelMusic_ref;
        time = Times.Present;
        elevetorState = States.True;
        musicInstance = RuntimeManager.CreateInstance(LevelMusic);
        setTime(time);
        setElevator(elevetorState);
        musicInstance.start();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void setTime(Times t){
        time = t;
        musicInstance.setParameterByNameWithLabel("Time", time.ToString());
    }
    public static void setElevator(States s){
        elevetorState = s;
        musicInstance.setParameterByNameWithLabel("Ascensor", elevetorState.ToString());
    }
    public static void setTalking(States s){
        talkingState = s;
        musicInstance.setParameterByNameWithLabel("Talking", talkingState.ToString());
    }
    void OnDisable(){
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();    
    }
    private void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.CompareTag("Player")){
            setElevator(States.True);
        }
    }
    private void OnTriggerExit(Collider collider) {
        if(collider.gameObject.CompareTag("Player")){
            setElevator(States.False);
        }
    }
}
