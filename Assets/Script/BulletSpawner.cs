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

            // 스포너의 x, z 좌표 + 플레이어의 y 좌표
            Vector3 spawnPos = new Vector3(transform.position.x, target.position.y, transform.position.z);

            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            // 총알이 플레이어를 향하도록 회전
            bullet.transform.LookAt(target.position);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }


}

