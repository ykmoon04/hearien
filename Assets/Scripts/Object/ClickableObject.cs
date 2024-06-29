using UnityEngine.InputSystem;
using UnityEngine;


public abstract class ClickableObject : MonoBehaviour, IClickable
{
    protected virtual void OnMouseEnter()
    {
        CursorManager.i.SetHandCursor();
    }

    protected virtual void OnMouseExit()
    {
        CursorManager.i.SetArrowCursor();
    }

    protected virtual void OnMouseDown()
    {
        OnClick();
    }

    public abstract void OnClick();
}
