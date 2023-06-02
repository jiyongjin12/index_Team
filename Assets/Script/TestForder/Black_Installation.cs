using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Installation : MonoBehaviour
{
    public GameObject objectPrefab; // 설치할 오브젝트 프리팹
    public SpriteRenderer previewRenderer; // 블록 미리보기를 위한 스프라이트 렌더러

    private bool placingObject = false; // 블록 설치 중인지 여부

    private void Update()
    {
        if (placingObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InstallObject();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartPlacement();
            }
        }
    }

    private void StartPlacement()
    {
        placingObject = true;
        previewRenderer.enabled = true;
    }

    private void InstallObject()
    {
        // 마우스 클릭 위치를 기준으로 오브젝트 설치
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D 게임이므로 z 위치는 0으로 고정

        Instantiate(objectPrefab, mousePosition, Quaternion.identity);

        StopPlacement();
    }

    private void StopPlacement()
    {
        placingObject = false;
        previewRenderer.enabled = false;
    }
}
