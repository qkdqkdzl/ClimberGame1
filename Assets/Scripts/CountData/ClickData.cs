using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Ŭ�� �� ����� ��ũ��Ʈ 
/// </summary>
public class ClickData : MonoBehaviour
{
    public static ClickData  Instance;

    public int lastClickCount = 0; // ���� ������ �� ����� Ŭ�� ��

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� �̵��ص� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveClickCount(int count)
    {
        lastClickCount = count;
    }
}

  

    /// <summary>
    /// �κ� UI�� ǥ���ϴ� ��ũ��Ʈ        
    /// </summary>
    
