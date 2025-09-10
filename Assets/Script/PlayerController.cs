using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed =5f;

    private GameManager gameManager;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.linearVelocity = newVelocity;

        if (newVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(newVelocity);
            playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    // ������ �浹 �� GameManager�� ���� �߰� ��û
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            gameManager.AddScore(1); // ���� 1 �߰�
            Destroy(other.gameObject);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        gameManager.EndGame();
    }
}
