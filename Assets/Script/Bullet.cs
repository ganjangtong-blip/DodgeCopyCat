using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        // [수정] linearVelocity보다 velocity 사용을 권장합니다.
        bulletRigidbody.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 6f);
    }

    // OnTriggerEnter 함수 하나로 모든 충돌을 처리합니다.
    private void OnTriggerEnter(Collider other)
    {
        // 1. 만약 부딪힌 상대방의 태그가 "Player"라면
        if (other.tag == "Player")
        {
            PlayerController playController = other.GetComponent<PlayerController>();

            if (playController != null)
            {
                playController.Die();
            }

            // 플레이어와 부딪혔을 때도 총알은 사라져야 하므로 Destroy 추가
            Destroy(gameObject);
        }

        // 2. 만약 부딪힌 상대방의 태그가 "Fence"라면
        if (other.CompareTag("Fence"))
        {
            // 총알 자신을 파괴합니다.
            Destroy(gameObject);
        }
    }

    // 이 OnCollisionEnter 함수는 이제 필요 없으므로 삭제해도 됩니다.
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            Destroy(gameObject);
        }
    }
    */
}