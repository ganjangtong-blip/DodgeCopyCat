using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.1f;
    public float spawnRateMax = 2f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {

        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frames
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            // �������� x, z ��ǥ + �÷��̾��� y ��ǥ
            Vector3 spawnPos = new Vector3(transform.position.x, target.position.y, transform.position.z);

            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            // �Ѿ��� �÷��̾ ���ϵ��� ȸ��
            bullet.transform.LookAt(target.position);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }


}

