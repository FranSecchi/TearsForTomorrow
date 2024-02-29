using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EventReference AscensorSound;
    public EventReference AscensorSound_Ref;
    public static EventReference ButtonSound;
    public EventReference ButtonSound_Ref;
    public static EventReference BellSound;
    public EventReference BellSound_Ref;
    public static EventReference GrabSound;
    public EventReference GrabSound_Ref;
    public static EventReference JardíMusic;
    public EventReference JardíMusic_Ref;
    static FMOD.Studio.EventInstance jardíInstance;
    public static EventReference PortaSound;
    public EventReference PortaSound_Ref;

    public static EventReference Vocals_AmaLlaves;
    public EventReference Vocals_AmaLlaves_Ref;
    public static EventReference Vocals_Jardinero;
    public EventReference Vocals_Jardinero_Ref;
    public static EventReference Vocals_Morta;
    public EventReference Vocals_Morta_Ref;
    public static EventReference Vocals_Propiertari;
    public EventReference Vocals_Propietari_Ref;
    public static EventReference Vocals_Recepcionista;
    public EventReference Vocals_Recepcionista_Ref;

    void Start(){
        AscensorSound = AscensorSound_Ref;
        ButtonSound = ButtonSound_Ref;
        BellSound = BellSound_Ref;
        GrabSound = GrabSound_Ref;
        JardíMusic = JardíMusic_Ref;
        PortaSound = PortaSound_Ref;
        Vocals_AmaLlaves = Vocals_AmaLlaves_Ref;
        Vocals_Jardinero = Vocals_Jardinero_Ref;
        Vocals_Morta = Vocals_Morta_Ref;
        Vocals_Propiertari = Vocals_Propietari_Ref;
        Vocals_Recepcionista = Vocals_Recepcionista_Ref;
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
