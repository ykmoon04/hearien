using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D speaker;
    [SerializeField] Texture2D handCursor;


    public static CursorManager i;
    
    private void Awake() {
        if(i==null){
            i = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void SetHandCursor()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }
    
    public void SetArrowCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void SetSpeakerCursor()
    {
        Cursor.SetCursor(speaker, Vector2.zero, CursorMode.Auto);
    }
}
