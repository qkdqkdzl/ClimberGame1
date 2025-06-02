using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���忡 ����� �����ϰ� ����ִ� �ڵ�
/// </summary>

public class BlockRandom : MonoBehaviour
{
    [Header("������ ��� ����")]
    public GameObject blockPrefab;      // Block(���) ������

    [Header("��� ����")]
    public int spawnblock; //= 20;       // ó���� ȭ�� �Ʒ����� ���� �� ���� �̸� ������

    [Header("Offset �� (����/������)")]
    // ��� ���� ����(X,Y)
    public Vector2 leftOffset = new Vector2(-1.21f, 0.65f);
    public Vector2 rightOffset = new Vector2(1.28f, 0.71f);

    [Header("�÷��̾� Transform")]
    public Transform playerTransform;   // �÷��̾� ���̸� üũ�ϱ� ���� ����
    [Header("�÷��̾� �� �󸶳� ��������")]
    public float aheadY = 10f;          // �÷��̾� Y + aheadY ���ϸ�ŭ ���� ����

    private Vector2 lastPos;            // ���������� ������ ��� ��ġ

    void Start()
    {
        // ���� ������: �÷��̾� �⺻ ��ġ �ٷ� �Ʒ��� (0, 0)���� ����
        // ��: �⺻ ��ǥ (0.63, -5.63)�� ����ϰ� �ʹٸ�
        //    lastPos = new Vector2(0.63f, -5.63f);
        lastPos = new Vector2(0.58f, -5.96f);

        // initialCount ������ŭ �̸� ��� ����
        for (int i = 0; i < spawnblock; i++)
        {
            SpawnNextStair();
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // �÷��̾ �ö� ������ "aheadY"������ ���� ����
        while (lastPos.y < playerTransform.position.y + aheadY)
        {
            SpawnNextStair();
        }
    }

    private void SpawnNextStair()
    {
        // 1) ���� ���� ���� (��: 60% Ȯ���� ������, 40% Ȯ���� ����)
        float rnd = Random.value;            // 0.0 ~ 1.0 ������ ��
        bool goRight = (rnd > 0.6f);         // rnd�� 0.6���� ũ�� ������
        bool goLeft = (rnd < 0.4f);         // rnd�� 0.4���� ������ ����

        // ���� rnd�� 0.4~0.6 ���̸�, ��/�� �� �� �ϳ��� �⺻���� ����
        if (!goRight && !goLeft)
        {
            // ���� ��� 0.4~0.6 ���������� 50:50���� �ٽ� ����
            goRight = (Random.value > 0.5f);
            goLeft = !goRight;
        }

        // 2) ���õ� ���⿡ �°� Offset ����
        Vector2 chosenOffset = goRight ? rightOffset : leftOffset;

        // 3) ���� ���(���) ��ġ ���
        Vector2 spawnPos = lastPos + chosenOffset;

        // 4) ���(���) �ν��Ͻ� ����
        Instantiate(blockPrefab, new Vector3(spawnPos.x, spawnPos.y, 0f), Quaternion.identity);

        // 5) ������ ���� ��ġ ����
        lastPos = spawnPos;

    }
}
