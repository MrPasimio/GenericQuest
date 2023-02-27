using UnityEngine;

namespace jnielsen.Scripts.Controllers
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed;
        public float jumpForce;
        public float lowerLimit;
        public AudioClip jumpSound;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        private GameManager _gameManager;
        private AudioSource _audioSource;
        private bool _isOnGround = true;
        private float _horizontalInput;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _gameManager = Utils.GetGameManager();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * (moveSpeed * _horizontalInput * Time.deltaTime));

            _spriteRenderer.flipX = _horizontalInput switch
            {
                < 0 => true,
                > 0 => false,
                _ => _spriteRenderer.flipX
            };

            if (Input.GetButtonDown("Jump") && _isOnGround)
            {
                _isOnGround = false;
                _audioSource.PlayOneShot(jumpSound);
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
            
            GroundCheck();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                _isOnGround = true;
            }
        }

        private void GroundCheck()
        {
            if (transform.position.y < lowerLimit)
            {
                _gameManager.Respawn();
            }
        }

        public void Hurt()
        {
            _gameManager.Respawn();
        }
    }
}
