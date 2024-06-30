using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkableObject : MonoBehaviour, ITalkable, IHearable
{
    // 말풍선 O 소리 O
    private AudioSource sound;
    GameObject bubble;


    private void Awake() {
        sound = GetComponent<AudioSource>();
    }

    // 드래그 중에는 안 바뀌게 해야함  -> 콜라이더 비활성화
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
        if(sound.volume==1f){
            ShowBubble();
        }else{
            HideBubble();
        }

        if(sound.volume <= 0f){
            sound.Stop();
        }
    }
    #endregion

    #region show bubble
    public void ShowBubble(){
        if(bubble == null){
            string dialog = TemporaryDataClass.GetDialog(gameObject.name); 
            bubble = BubbleManager.i.GetBubble(gameObject.transform, dialog);
        }

        bubble.SetActive(true);
    }

    public void HideBubble(){
        bubble?.SetActive(false);
    }

    #endregion
}
