using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MenuMusicManager : MonoBehaviour
{
    public EventReference MenuMusic;

    FMOD.Studio.EventInstance musicInstance;
    public States credits;
    // Start is called before the first frame update
    void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(MenuMusic);
        musicInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            setCredits(credits);
        }
    }
    public void setCredits(States s){
        credits = s;
        musicInstance.setParameterByNameWithLabel("Credits", credits.ToString());
    }
    void OnDisable(){
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();    
    }
}