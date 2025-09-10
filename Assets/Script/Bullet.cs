using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 60f;
    public Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 50f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playController = other.GetComponent<PlayerController>();
            
            if (playController != null ) {
                playController.Die();
            }
        }
    }
    // Rigidbody가 있는 다른 Collider와 부딪혔을 때 한 번 호출되는 함수입니다.
    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 상대방(collision)의 게임 오브젝트(gameObject)의 태그가 "Fence"인지 확인합니다.
        if (collision.gameObject.CompareTag("Fence"))
        {
            // 만약 "Fence" 태그를 가진 오브젝트와 부딪혔다면,
            // 이 스크립트가 붙어있는 게임 오브젝트(즉, 총알 자신)를 파괴합니다.
            Destroy(gameObject);
        }
    }

}

