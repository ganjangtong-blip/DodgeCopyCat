using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // 생성할 아이템의 프리팹을 연결할 변수
    public GameObject itemPrefab;

    // 아이템이 생성될 영역의 중심점
    public Vector3 spawnAreaCenter;

    // [수정] Vector3 대신 X와 Z 범위를 float으로 따로 받습니다.
    public float spawnRangeX = 10f; // 좌우 범위
    public float spawnRangeZ = 10f; // 앞뒤 범위

    // 생성 주기 (초)
    public float spawnInterval = 2f;

    void Start()
    {
        // 게임이 시작되면 spawnInterval초 마다 SpawnItem 함수를 반복해서 실행
        InvokeRepeating("SpawnItem", 1f, spawnInterval);
    }

    void SpawnItem()
    {
        // [수정] spawnRangeX와 spawnRangeZ를 사용해 랜덤 위치를 계산합니다.
        // spawnRangeX의 절반 크기만큼 좌우로 랜덤 위치를 정합니다.
        float randomX = Random.Range(-spawnRangeX / 2, spawnRangeX / 2);
        // spawnRangeZ의 절반 크기만큼 앞뒤로 랜덤 위치를 정합니다.
        float randomZ = Random.Range(-spawnRangeZ / 2, spawnRangeZ / 2);

        // 중심점에 랜덤 위치를 더해 최종 생성 위치를 결정합니다.
        // Y축(높이)은 중심점의 높이를 그대로 사용합니다.
        Vector3 spawnPosition = spawnAreaCenter + new Vector3(randomX, 0, randomZ);

        // 계산된 위치에 itemPrefab을 생성
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        
    }

    // Scene 뷰에서 생성 영역을 시각적으로 보여주는 기능 (개발 편의용)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan; // 색상을 바꿔서 이전과 구분해 봅시다.
        // [수정] X, Z 범위를 사용해 상자의 크기를 결정합니다. (Y는 보기 좋게 1로 설정)
        Vector3 gizmoSize = new Vector3(spawnRangeX, 1f, spawnRangeZ);
        Gizmos.DrawWireCube(spawnAreaCenter, gizmoSize);
    }
}