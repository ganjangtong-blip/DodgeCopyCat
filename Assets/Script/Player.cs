using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 15f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.linearVelocity = newVelocity;
        
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
