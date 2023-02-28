using UnityEngine;

public class JetPack : MonoBehaviour
{
    public Animator animator;
    public PlayerFlight playerFlight;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerFlight = GetComponent<PlayerFlight>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("You're flying with JetPack!");
            animator.SetBool("IsFlying", true);
            playerFlight.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("You stopped flying with JetPack.");
            animator.SetBool("IsFlying", false);
            playerFlight.enabled = false;

            // Set the player's velocity to zero to make them drop instantly
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }
    }
}






