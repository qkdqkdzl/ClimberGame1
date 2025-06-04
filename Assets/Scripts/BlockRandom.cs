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
    public Vector2 leftOffset; 
    public Vector2 rightOffset; 

    [Header("---------플레이어-------")]
    public Transform playerTransform;

    private Vector2 lastPos; // 마지막 생성 위치

    void Start()
    {
        // 시작 위치 고정
        lastPos = new Vector2(0.58f, -5.96f);

        // 첫 계단 생성 (기본 위치에)
        Instantiate(blockPrefab, new Vector2(lastPos.x, lastPos.y), Quaternion.identity);

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
        float rnd = Random.value; // 0.0 ~ 1.0

        bool goRight = rnd > 0.6f;
        bool goLeft = rnd < 0.4f;

        // 0.4 ~ 0.6 범위면 랜덤으로 방향 결정
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
