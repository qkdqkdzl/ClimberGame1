using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 월드에 블록을 랜덤하게 깔아주는 코드
/// </summary>

public class BlockRandom : MonoBehaviour
{
    [Header("생성할 블록 설정")]
    public GameObject blockPrefab;      // Block(계단) 프리팹

    [Header("계단 개수")]
    public int spawnblock; //= 20;       // 처음에 화면 아래에서 위로 몇 개를 미리 쌓을지

    [Header("Offset 값 (왼쪽/오른쪽)")]
    // 계단 스폰 간격(X,Y)
    public Vector2 leftOffset = new Vector2(-1.21f, 0.65f);
    public Vector2 rightOffset = new Vector2(1.28f, 0.71f);

    [Header("플레이어 Transform")]
    public Transform playerTransform;   // 플레이어 높이를 체크하기 위한 참조
    [Header("플레이어 위 얼마나 생성할지")]
    public float aheadY = 10f;          // 플레이어 Y + aheadY 이하만큼 생성 유지

    private Vector2 lastPos;            // 마지막으로 생성된 계단 위치

    void Start()
    {
        // 시작 기준점: 플레이어 기본 위치 바로 아래나 (0, 0)으로 세팅
        // 예: 기본 좌표 (0.63, -5.63)을 사용하고 싶다면
        //    lastPos = new Vector2(0.63f, -5.63f);
        lastPos = new Vector2(0.58f, -5.96f);

        // initialCount 개수만큼 미리 계단 생성
        for (int i = 0; i < spawnblock; i++)
        {
            SpawnNextStair();
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // 플레이어가 올라갈 때마다 "aheadY"까지만 생성 유지
        while (lastPos.y < playerTransform.position.y + aheadY)
        {
            SpawnNextStair();
        }
    }

    private void SpawnNextStair()
    {
        // 1) 랜덤 방향 선택 (예: 60% 확률로 오른쪽, 40% 확률로 왼쪽)
        float rnd = Random.value;            // 0.0 ~ 1.0 사이의 값
        bool goRight = (rnd > 0.6f);         // rnd가 0.6보다 크면 오른쪽
        bool goLeft = (rnd < 0.4f);         // rnd가 0.4보다 작으면 왼쪽

        // 만약 rnd가 0.4~0.6 사이면, 왼/오 둘 중 하나를 기본으로 선택
        if (!goRight && !goLeft)
        {
            // 예를 들어 0.4~0.6 구간에서는 50:50으로 다시 결정
            goRight = (Random.value > 0.5f);
            goLeft = !goRight;
        }

        // 2) 선택된 방향에 맞게 Offset 결정
        Vector2 chosenOffset = goRight ? rightOffset : leftOffset;

        // 3) 다음 블록(계단) 위치 계산
        Vector2 spawnPos = lastPos + chosenOffset;

        // 4) 블록(계단) 인스턴스 생성
        Instantiate(blockPrefab, new Vector3(spawnPos.x, spawnPos.y, 0f), Quaternion.identity);

        // 5) 마지막 생성 위치 갱신
        lastPos = spawnPos;

    }
}
