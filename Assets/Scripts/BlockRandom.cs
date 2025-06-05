using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 월드에 블록을 랜덤하게 깔아주는 코드
/// </summary>

public class BlockRandom : MonoBehaviour
{
    [Header("--------- 블록 설정 ---------")]
    public GameObject blockPrefab; // 계단 프리팹

    [Header("--------- 계단 개수 --------")]
    public int spawnblock = 10; // 처음 생성할 블록 개수

    [Header("---------- 좌, 우 값 -------")]
    public Vector2 leftOffset;   // x는 음수여야 함
    public Vector2 rightOffset;  // x는 양수여야 함

    [Header("--------- 플레이어 -------")]
    public Transform playerTransform;

    private Vector2 lastPos; // 마지막 생성 위치

    void Awake()
    {
        // 인스펙터에 설정된 값이 잘못됐을 때를 대비해 강제로 x부호를 고정
        leftOffset.x = -Mathf.Abs(leftOffset.x);
        rightOffset.x = Mathf.Abs(rightOffset.x);
    }

    void Start()
    {
        // 시작 위치 고정
        lastPos = new Vector2(0.58f, -5.96f);

        // 첫 계단 생성 (기본 위치에, z = -1f)
        Vector3 firstPosWithZ = new Vector3(lastPos.x, lastPos.y, -1f);
        Instantiate(blockPrefab, firstPosWithZ, Quaternion.identity);

        // 나머지 계단들 생성
        for (int i = 0; i < spawnblock - 1; i++)
        {
            SpawnNextStair();
        }
    }

    /// <summary>
    /// 계단 하나 생성
    /// </summary>
    private void SpawnNextStair()
    {
        // 50% 확률로 왼쪽/오른쪽 방향 선택
        bool goRight = Random.value > 0.5f;
        Vector2 chosenOffset = goRight ? rightOffset : leftOffset;

        // 디버그용 출력 (어느 방향을 선택했는지 확인)
        Debug.Log($"SpawnNextStair 호출: goRight = {goRight}, chosenOffset = {chosenOffset}");

        Vector2 spawnPos = lastPos + chosenOffset;
        Vector3 spawnPosWithZ = new Vector3(spawnPos.x, spawnPos.y, -1f);
        Instantiate(blockPrefab, spawnPosWithZ, Quaternion.identity);

        lastPos = spawnPos;
    }
}

            
