using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour {
    public GameObject dialogManager;
    public AudioSource myFx;
    public AudioClip hoverFx;
    private AudioClip clickFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }
    public void ClickSoundRight()
    {
       clickFx= dialogManager.GetComponent<VoiceDialog>().rightSoundToPlay();
        myFx.PlayOneShot(clickFx);
    }
    public void ClickSoundLeft()
    {
        clickFx = dialogManager.GetComponent<VoiceDialog>().LeftSoundToPlay();
        myFx.PlayOneShot(clickFx);
    }   
}
