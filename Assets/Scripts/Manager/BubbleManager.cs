using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleManager : MonoBehaviour
{

    public static BubbleManager i;
    [SerializeField] GameObject bubblePrefab;
    Canvas canvas;

    
    private void Awake() {
        if(i==null){
            i = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        canvas = FindObjectOfType<Canvas>();
    }

    public GameObject GetBubble(Transform childObject, string dialog){
        GameObject bubble = Instantiate(bubblePrefab, canvas.transform);

        // 위치 설정
        SetBubblePosition(bubble, childObject);

        // 텍스트 설정
        SetBubbleText(bubble, dialog);

        return bubble;
    }

    void SetBubblePosition(GameObject bubble, Transform childObject){
        // 자식 오브젝트의 Collider2D 얻기
        Collider2D collider = childObject.GetComponent<Collider2D>();

        if (collider != null)
        {
            // 중앙 상단 위치 계산
            Vector3 topCenterPosition = new Vector3(collider.bounds.center.x, collider.bounds.max.y, collider.bounds.center.z);

            // 월드 좌표를 스크린 좌표로 변환
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(topCenterPosition);

            // 스크린 좌표를 캔버스 좌표로 변환
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                screenPosition,
                null,
                out Vector2 localPoint
            );

            // UI 요소의 위치를 업데이트
            bubble.transform.localPosition = localPoint;
        }
    }

    void SetBubbleText(GameObject bubble, string dialog){
        bubble.GetComponentInChildren<TextMeshProUGUI>().text = dialog;
    }



}