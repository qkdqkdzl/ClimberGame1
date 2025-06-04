using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���忡 ����� �����ϰ� ����ִ� �ڵ�
/// </summary>

public class BlockRandom : MonoBehaviour
{
    [Header("--------- ��� ���� ---------")]
    public GameObject blockPrefab; // ��� ������

    [Header("--------- ��� ���� --------")]
    public int spawnblock = 10; // ó�� ������ ��� ����

    [Header("---------- ��, �� �� -------")]
    public Vector2 leftOffset; 
    public Vector2 rightOffset; 

    [Header("---------�÷��̾�-------")]
    public Transform playerTransform;

    private Vector2 lastPos; // ������ ���� ��ġ

    void Start()
    {
        // ���� ��ġ ����
        lastPos = new Vector2(0.58f, -5.96f);

        // ù ��� ���� (�⺻ ��ġ��)
        Instantiate(blockPrefab, new Vector2(lastPos.x, lastPos.y), Quaternion.identity);

        // ������ ��ܵ� ����
        for (int i = 0; i < spawnblock - 1; i++)
        {
            SpawnNextStair();
        }
    }

 
    /// <summary>
    /// ��� �ϳ� ����
    /// </summary>
    private void SpawnNextStair()
    {
        float rnd = Random.value; // 0.0 ~ 1.0

        bool goRight = rnd > 0.6f;
        bool goLeft = rnd < 0.4f;

        // 0.4 ~ 0.6 ������ �������� ���� ����
        if (!goRight && !goLeft)
        {
            goRight = Random.value > 0.5f;
            goLeft = !goRight;
        }

        Vector2 chosenOffset = goRight ? rightOffset : leftOffset;
        Vector2 spawnPos = lastPos + chosenOffset;

        Instantiate(blockPrefab, new Vector2(spawnPos.x, spawnPos.y), Quaternion.identity);
        lastPos = spawnPos;
    }   
}
