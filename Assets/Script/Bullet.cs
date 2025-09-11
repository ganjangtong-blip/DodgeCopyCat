using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        // [����] linearVelocity���� velocity ����� �����մϴ�.
        bulletRigidbody.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 6f);
    }

    // OnTriggerEnter �Լ� �ϳ��� ��� �浹�� ó���մϴ�.
    private void OnTriggerEnter(Collider other)
    {
        // 1. ���� �ε��� ������ �±װ� "Player"���
        if (other.tag == "Player")
        {
            PlayerController playController = other.GetComponent<PlayerController>();

            if (playController != null)
            {
                playController.Die();
            }

            // �÷��̾�� �ε����� ���� �Ѿ��� ������� �ϹǷ� Destroy �߰�
            Destroy(gameObject);
        }

        // 2. ���� �ε��� ������ �±װ� "Fence"���
        if (other.CompareTag("Fence"))
        {
            // �Ѿ� �ڽ��� �ı��մϴ�.
            Destroy(gameObject);
        }
    }

    // �� OnCollisionEnter �Լ��� ���� �ʿ� �����Ƿ� �����ص� �˴ϴ�.
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