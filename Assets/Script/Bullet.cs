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
    // Rigidbody�� �ִ� �ٸ� Collider�� �ε����� �� �� �� ȣ��Ǵ� �Լ��Դϴ�.
    private void OnCollisionEnter(Collision collision)
    {
        // �ε��� ����(collision)�� ���� ������Ʈ(gameObject)�� �±װ� "Fence"���� Ȯ���մϴ�.
        if (collision.gameObject.CompareTag("Fence"))
        {
            // ���� "Fence" �±׸� ���� ������Ʈ�� �ε����ٸ�,
            // �� ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ(��, �Ѿ� �ڽ�)�� �ı��մϴ�.
            Destroy(gameObject);
        }
    }

}

