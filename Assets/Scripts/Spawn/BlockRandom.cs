using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 월드에 블록을 랜덤하게 깔아주는 코드
/// </summary>

public class BlockRandom : MonoBehaviour
{
        
    [Header("--------- 블록 설정 ---------")]
    public GameObject block; // 계단 프리팹
  
    [Header("--------- 계단 개수 --------")]
    public int _firstbock; // 처음 생성할 블록 개수
    public int _againblock; // 한 번에 추가 생성할 계단 수

    [Header("---------- 좌, 우값 -------")]
    public Vector2 left;    
    public Vector2 right;        

    [Header("--------- 플레이어 -------")]
    public Transform playerTransform; // (현재 예시에서는 직접 사용되지 않음)

    [Header("--------- 버튼 설정 -------")]
    public Button _upButton; // UpBtn UI 버튼 연결
    public Button _turnButton; // Trun 버튼 UI 버튼 연결
    public int _SpawnBlock; // 계단 추가 생성을 트리거할 버튼 누름 횟수

    [Header("--------- 코인 ---------")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject applePrefab;
    



    private Vector2 lastPos; // 마지막 생성 위치
    private int _numberspawn = 0; // 현재까지 생성된 계단 수 (초기 생성 포함)
    private int _totalPresses = 0; // UpBtn 또는 Trun 버튼이 눌린 총 횟수

    void Awake()
    {
        // 인스펙터에 설정된 값이 잘못됐을 때를 대비해 강제로 x부호를 고정
        left.x = -Mathf.Abs(left.x);
        right.x = Mathf.Abs(right.x);
    }

    void Start()
    {
        // 시작 위치 고정
        lastPos = new Vector2(0.58f, -5.96f);

        // 첫 계단 생성 (기본 위치에, z = -1f)
        Vector3 firstPosWithZ = new Vector3(lastPos.x, lastPos.y, -1f);
        Instantiate(block, firstPosWithZ, Quaternion.identity);
        _numberspawn++; // 첫 계단 생성 시 카운트 증가

        // 나머지 초기 계단들 생성
        for (int i = 0; i < _firstbock - 1; i++)
        {
            SpawnNextStair();
        }

        // UI 버튼에 클릭 이벤트 리스너 추가
        if (_upButton != null)
        {
            _upButton.onClick.AddListener(OnButtonPressed);
        }
        if (_turnButton != null)
        {
            _turnButton.onClick.AddListener(OnButtonPressed);
        }
    }

    /// <summary>
    /// 계단 하나 생성
    /// </summary>
    private void SpawnNextStair()
    {
        // 40% 확률로 왼쪽/오른쪽 방향 선택 (원하는 확률로 조절)
        bool goRight = Random.value > 0.4f;
        Vector2 chosenOffset = goRight ? right : left;

        Vector2 spawnPos = lastPos + chosenOffset;
        Vector3 spawnPosWithZ = new Vector3(spawnPos.x, spawnPos.y, -1f);
        Instantiate(block, spawnPosWithZ, Quaternion.identity);

        lastPos = spawnPos;
        _numberspawn++; // 계단 생성 시 카운트 증가    

        // 일정 확률로
        float randomValue = Random.value;
        if(randomValue < 0.1f)
        {
            // 블록을 스폰한 위치보다 조금 더 위에
            // coin, apple 프리팹을 Instantiate로 복제 생성          

            Vector3 itemSpawnPos = spawnPos + new Vector2(0f, 0.6f);

                        
            float itemPick = Random.value;
            GameObject itemToSpawn = itemPick < 0.6f ? coinPrefab : applePrefab;

            GameObject item = Instantiate(      
                itemToSpawn,
                new Vector3(itemSpawnPos.x, itemSpawnPos.y, -1f),
                Quaternion.identity
            );
        }      
        

    }
                

    /// <summary>
    /// UpBtn 또는 Trun 버튼이 눌렸을 때 호출되는 함수
    /// </summary>
    public void OnButtonPressed()
    {
        _totalPresses++;
        Debug.Log($"버튼이 눌렸습니다! 총 누른 횟수: {_totalPresses}회");

        // 총 버튼 누름 횟수가 _SpawnBlock의 배수일 때마다 _againblock 만큼 추가 계단 생성
        if (_totalPresses % _SpawnBlock == 0 && _totalPresses != 0)
        {
            Debug.Log($"버튼 {_SpawnBlock}회 누름 돌파! 계단 {_againblock}개 추가 생성!");
            // 이 for 루프가 새로 추가된 핵심 부분
            for (int i = 0; i < _againblock; i++)
            {
                SpawnNextStair(); // _againblock 횟수만큼 SpawnNextStair()를 호출
            }
        }   
    }       
}
            
