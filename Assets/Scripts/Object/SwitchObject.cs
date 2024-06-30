using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class SwitchObject : MonoBehaviour
{
    [SerializeField] Sprite switchSprite;
    [SerializeField] AudioClip switchAudio;

    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SwitchStatus(){
        spriteRenderer.sprite = switchSprite;
        audioSource.clip = switchAudio;
        audioSource.loop=false;
        audioSource.volume = 1f;
        audioSource.Play();
    }
}
