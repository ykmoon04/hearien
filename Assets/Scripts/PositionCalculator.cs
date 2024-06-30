using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PositionCalculator : MonoBehaviour
{
    private Camera mainCamera;
    public static PositionCalculator i;
    RectTransform canvasRectTransform;
    Canvas canvas;

    private void Awake()
    {
        mainCamera = Camera.main;
        canvas = FindObjectOfType<Canvas>();
        canvasRectTransform = canvas.transform as RectTransform;

        if(i==null){
            i = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    // 월드 좌표를 스크린 좌표로 변환 
    public Vector3 WorldToScreenPoint(Vector3 worldPosition)
    {
        return mainCamera.WorldToScreenPoint(worldPosition);
    }

    // 스크린 좌표를 캔버스의 로컬 좌표로 변환
    public Vector2 ScreenToCanvasLocalPoint(Vector3 screenPosition)
    {
        // 캔버스의 렌더 모드 확인
        Camera camera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,
            screenPosition,
            camera,
            out Vector2 canvasLocalPosition
        );
        return canvasLocalPosition;
    }
}
