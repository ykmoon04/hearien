using UnityEngine.InputSystem;
using UnityEngine;

public class MouseScroll : MonoBehaviour
{
    private MainActions mainActions;
    private InputAction mouseScrollY;

    private void Awake() {
        mainActions = new MainActions();
        mouseScrollY = mainActions.Player.MouseScrollY;
    }

    #region enable/disable
    private void OnEnable() {
        mouseScrollY.Enable();
        mouseScrollY.performed += Performed;
    }

    private void OnDisable() {
        mouseScrollY.Disable();
        mouseScrollY.performed -= Performed;
    }
    #endregion

    void Performed(InputAction.CallbackContext context)
    {
        float change = mouseScrollY.ReadValue<float>() / 10;
        int layerObject = 8;
        Vector2 ray = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(ray, ray, layerObject);
        if (hit.collider != null) 
        {
            hit.collider.gameObject.GetComponent<IHearable>()?.SetVolume(change/100);
        }
    }
}
