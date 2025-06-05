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
    public Vector2 leftOffset;   // x�� �������� ��
    public Vector2 rightOffset;  // x�� ������� ��

    [Header("--------- �÷��̾� -------")]
    public Transform playerTransform;

    private Vector2 lastPos; // ������ ���� ��ġ

    void Awake()
    {
        // �ν����Ϳ� ������ ���� �߸����� ���� ����� ������ x��ȣ�� ����
        leftOffset.x = -Mathf.Abs(leftOffset.x);
        rightOffset.x = Mathf.Abs(rightOffset.x);
    }

    void Start()
    {
        // ���� ��ġ ����
        lastPos = new Vector2(0.58f, -5.96f);

        // ù ��� ���� (�⺻ ��ġ��, z = -1f)
        Vector3 firstPosWithZ = new Vector3(lastPos.x, lastPos.y, -1f);
        Instantiate(blockPrefab, firstPosWithZ, Quaternion.identity);

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
        // 50% Ȯ���� ����/������ ���� ����
        bool goRight = Random.value > 0.5f;
        Vector2 chosenOffset = goRight ? rightOffset : leftOffset;

        // ����׿� ��� (��� ������ �����ߴ��� Ȯ��)
        Debug.Log($"SpawnNextStair ȣ��: goRight = {goRight}, chosenOffset = {chosenOffset}");

        Vector2 spawnPos = lastPos + chosenOffset;
        Vector3 spawnPosWithZ = new Vector3(spawnPos.x, spawnPos.y, -1f);
        Instantiate(blockPrefab, spawnPosWithZ, Quaternion.identity);

        lastPos = spawnPos;
    }
}

            
