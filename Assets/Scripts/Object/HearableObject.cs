using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearableObject : MonoBehaviour, IHearable
{
    // 말풍선 X, 소리 O 
    private AudioSource sound;
    
    private void Awake() {
        sound = GetComponent<AudioSource>();
    }


    #region change cursor
    protected virtual void OnMouseEnter()
    {
        CursorManager.i.SetSpeakerCursor();
    }
    
    protected virtual void OnMouseExit()
    {
        CursorManager.i.SetArrowCursor();
    }

    #endregion


    #region play sound
    public void SetVolume(float change){
        if(!sound.isPlaying) {
            sound.Play();
        }

        sound.volume += change;

        if(sound.volume <= 0f){
            sound.Stop();
        }
    }
    #endregion
}
