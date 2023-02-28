using UnityEngine;

public class PlayerFlight : MonoBehaviour
{
    public float flightSpeed = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
            rb.velocity = movement * flightSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}


