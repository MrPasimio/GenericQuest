using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    //Components
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    //Movement Variables
    public float moveSpeed;
    public float horizontalInput;

    //Jumping
    public bool isOnGround = true;
    public float jumpForce;
    private bool canDoubleJump = false;

    //Game Manager
    public GameManager gm;

    public GameObject starPrefab;
    public Transform starSpawnPoint1;
    public Transform starSpawnPoint2;
    public GameObject star1;
    public GameObject star2;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);

        //Flip if facing left
        if(horizontalInput < 0)
        {
            sr.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
        }

        if (Input.GetButtonDown("Jump") && !isOnGround && canDoubleJump && BepisPowerup.hasCollected)
        {
            canDoubleJump = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            canDoubleJump = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
    }

    public void Hurt()
    {
        gm.Respawn();
    }

    public void respawnStar()
    {
        CollectStar.starAmount = 0;
        Destroy(star1);
        Destroy(star2);
        Instantiate(starPrefab, starSpawnPoint1.position, transform.rotation);
        Instantiate(starPrefab, starSpawnPoint2.position, transform.rotation);
        
    }
}
