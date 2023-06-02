using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Installation : MonoBehaviour
{
    public GameObject objectPrefab; // ��ġ�� ������Ʈ ������
    public SpriteRenderer previewRenderer; // ��� �̸����⸦ ���� ��������Ʈ ������

    private bool placingObject = false; // ��� ��ġ ������ ����

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
        // ���콺 Ŭ�� ��ġ�� �������� ������Ʈ ��ġ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D �����̹Ƿ� z ��ġ�� 0���� ����

        Instantiate(objectPrefab, mousePosition, Quaternion.identity);

        StopPlacement();
    }

    private void StopPlacement()
    {
        placingObject = false;
        previewRenderer.enabled = false;
    }
}
