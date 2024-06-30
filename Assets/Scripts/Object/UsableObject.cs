using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UsableObject : ClickableObject, IUsable, IDragHandler, IEndDragHandler
{
     // 스테이지 내에서 사용가능한 오브젝트들 
    bool isSaved;
    string target;


    Vector2 endPosition;



    private void Awake() {
        target = TemporaryDataClass.GetTarget(name);
    }

    public override void OnClick(){
        // 클릭하면 인벤토리로 들어가 
        if(!isSaved){
            InventoryUI.i.AddItem(this.gameObject);
            isSaved = true;
        }
    }

    public void Use(){
        Vector2 ray = Camera.main.ScreenToWorldPoint(endPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, ray);
        Collider2D hitTarget = hit.collider;
        if (hitTarget != null && hitTarget.name == target) 
        {
            // 인벤토리에서 빼고 등등등 해야겟죠
            Debug.Log("게임 클리어!");
            InventoryUI.i.RemoveItem(gameObject);
            gameObject.SetActive(false);

            hitTarget.GetComponent<SwitchObject>().SwitchStatus();
        }
        else{
            // StartCoroutine(MoveBackObject()); // 부드럽게 원래 자리로 돌아가는 걸 하면 좋을듯 하여..
            // 인벤토리로 돌아가는 코드가 필요 
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragStatus.isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endPosition = Input.mousePosition;
        Use();
    }
}
