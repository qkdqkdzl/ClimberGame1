using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// �÷��̾ ����� ���� �� �ֵ��� ���ִ� �ڵ�
/// </summary>

public class Btn : MonoBehaviour
{
    public Vector2 currentPos;

    void Start()
    {
        currentPos = transform.position;
    }

    public void Jump()
    {
        currentPos += new Vector2(1f, 1.3f);
        transform.position = currentPos;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // G �� ���� �ٶ󺸴� ������ ����
            Debug.Log("G Ű: ������ ����");
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            // J �� ������ ������(Flip) �� ����
            Debug.Log("J Ű: ���� ��ȯ �� ����");
            
            
        }
    }
}

