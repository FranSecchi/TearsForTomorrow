using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EventReference AscensorSound;
    public static EventReference ButtonSound;
    public static EventReference BellSound;
    public static EventReference GrabSound;
    public static EventReference JardíMusic;
    static FMOD.Studio.EventInstance jardíInstance;
    public static EventReference PortaSound;

    public static EventReference Vocals_AmaLlaves;
    public static EventReference Vocals_Jardinero;
    public static EventReference Vocals_Morta;
    public static EventReference Vocals_Propiertari;
    public static EventReference Vocals_Recepcionista;

    void Start(){
        jardíInstance = RuntimeManager.CreateInstance(JardíMusic);
    }
    void OnDisable(){
        jardíInstance.release();
    }

    public static void playAscensor(){
        RuntimeManager.PlayOneShot(AscensorSound);
    }
    public static void playButton(){
        RuntimeManager.PlayOneShot(ButtonSound);
    }
    public static void playBell(){
        RuntimeManager.PlayOneShot(BellSound);
    }
    public static void playGrab(){
        RuntimeManager.PlayOneShot(GrabSound);
    }
    public static void playJardí(){
        jardíInstance.start();
    }
    public static void stopJardí(){
        jardíInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public static void playPorta(){
        RuntimeManager.PlayOneShot(PortaSound);
    }
    public static void playAmaLlaves(){
        RuntimeManager.PlayOneShot(Vocals_AmaLlaves);
    }
    public static void playJardinero(){
        RuntimeManager.PlayOneShot(Vocals_Jardinero);
    }
    public static void playMorta(){
        RuntimeManager.PlayOneShot(Vocals_Morta);
    }
    public static void playPropietari(){
        RuntimeManager.PlayOneShot(Vocals_Propiertari);
    }
    public static void playRecepcionista(){
        RuntimeManager.PlayOneShot(Vocals_Recepcionista);
    }

}
