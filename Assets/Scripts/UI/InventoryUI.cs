using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    List<GameObject> items;
    public static InventoryUI i;

    private void Awake() {
        if(i==null){
            i = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        items = new List<GameObject>();
    }

    public void AddItem(GameObject item){
        item.transform.SetParent(inventory.transform);

        // 스프라이트의 이미지 컴포넌트를 복사하여 UI 오브젝트에 추가
        Image image = item.AddComponent<Image>();
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
        if(spriteRenderer != null){
            image.sprite = spriteRenderer.sprite;
            image.preserveAspect = true;

            item.GetComponent<RectTransform>().sizeDelta = new Vector2(150,150);

            item.transform.localScale = Vector3.one;

            Destroy(spriteRenderer);
            items.Add(item);
        }
    }

    public void RemoveItem(GameObject item){
        items.Remove(item);
    }
}
