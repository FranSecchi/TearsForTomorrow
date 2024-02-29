using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EventReference AscensorSound;
    public EventReference ButtonSound;
    public EventReference BellSound;
    public EventReference GrabSound;
    public EventReference JardíMusic;
    FMOD.Studio.EventInstance jardíInstance;
    public EventReference PortaSound;

    public EventReference Vocals_AmaLlaves;
    public EventReference Vocals_Jardinero;
    public EventReference Vocals_Morta;
    public EventReference Vocals_Propiertari;
    public EventReference Vocals_Recepcionista;

    void Start(){
        jardíInstance = RuntimeManager.CreateInstance(JardíMusic);
    }
    void OnDisable(){
        jardíInstance.release();
    }

    public void playAscensor(){
        RuntimeManager.PlayOneShot(AscensorSound);
    }
    public void playButton(){
        RuntimeManager.PlayOneShot(ButtonSound);
    }
    public void playBell(){
        RuntimeManager.PlayOneShot(BellSound);
    }
    public void playGrab(){
        RuntimeManager.PlayOneShot(GrabSound);
    }
    public void playJardí(){
        jardíInstance.start();
    }
    public void stopJardí(){
        jardíInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void playPorta(){
        RuntimeManager.PlayOneShot(PortaSound);
    }
    public void playAmaLlaves(){
        RuntimeManager.PlayOneShot(Vocals_AmaLlaves);
    }
    public void playJardinero(){
        RuntimeManager.PlayOneShot(Vocals_Jardinero);
    }
    public void playMorta(){
        RuntimeManager.PlayOneShot(Vocals_Morta);
    }
    public void playPropietari(){
        RuntimeManager.PlayOneShot(Vocals_Propiertari);
    }
    public void playRecepcionista(){
        RuntimeManager.PlayOneShot(Vocals_Recepcionista);
    }

}
