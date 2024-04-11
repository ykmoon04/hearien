using UnityEngine.InputSystem;
using UnityEngine;


public class ClickableObject : MonoBehaviour
{
    // [SerializeField] Texture2D speaker;
    [SerializeField] GameObject bubble;
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


    public void SetVolume(float change){
        if(!sound.isPlaying) {
            sound.Play();
            bubble.SetActive(true);
        }


        sound.volume += change;
        if(sound.volume <= 0f){
            bubble.SetActive(false);
            sound.Stop();
        }
    }

}
