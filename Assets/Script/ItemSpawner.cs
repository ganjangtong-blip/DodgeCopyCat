using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // ������ �������� �������� ������ ����
    public GameObject itemPrefab;

    // �������� ������ ������ �߽���
    public Vector3 spawnAreaCenter;

    // [����] Vector3 ��� X�� Z ������ float���� ���� �޽��ϴ�.
    public float spawnRangeX = 10f; // �¿� ����
    public float spawnRangeZ = 10f; // �յ� ����

    // ���� �ֱ� (��)
    public float spawnInterval = 2f;

    void Start()
    {
        // ������ ���۵Ǹ� spawnInterval�� ���� SpawnItem �Լ��� �ݺ��ؼ� ����
        InvokeRepeating("SpawnItem", 1f, spawnInterval);
    }

    void SpawnItem()
    {
        // [����] spawnRangeX�� spawnRangeZ�� ����� ���� ��ġ�� ����մϴ�.
        // spawnRangeX�� ���� ũ�⸸ŭ �¿�� ���� ��ġ�� ���մϴ�.
        float randomX = Random.Range(-spawnRangeX / 2, spawnRangeX / 2);
        // spawnRangeZ�� ���� ũ�⸸ŭ �յڷ� ���� ��ġ�� ���մϴ�.
        float randomZ = Random.Range(-spawnRangeZ / 2, spawnRangeZ / 2);

        // �߽����� ���� ��ġ�� ���� ���� ���� ��ġ�� �����մϴ�.
        // Y��(����)�� �߽����� ���̸� �״�� ����մϴ�.
        Vector3 spawnPosition = spawnAreaCenter + new Vector3(randomX, 0, randomZ);

        // ���� ��ġ�� itemPrefab�� ����
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        
    }

    // Scene �信�� ���� ������ �ð������� �����ִ� ��� (���� ���ǿ�)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan; // ������ �ٲ㼭 ������ ������ ���ô�.
        // [����] X, Z ������ ����� ������ ũ�⸦ �����մϴ�. (Y�� ���� ���� 1�� ����)
        Vector3 gizmoSize = new Vector3(spawnRangeX, 1f, spawnRangeZ);
        Gizmos.DrawWireCube(spawnAreaCenter, gizmoSize);
    }
}