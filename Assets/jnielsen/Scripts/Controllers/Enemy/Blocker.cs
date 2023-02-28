using UnityEngine;

namespace jnielsen.Scripts.Controllers.Enemy
{
	public class Blocker : MonoBehaviour
	{
		public bool isHitOnHead;
		public float bounceForce;
		public float moveSpeed;
		public bool isAlive = true;
		public Transform groundDetector;

		private void Update()
		{
			Movement();
			PatrolCheck();
		}

		private void Movement()
		{
			if (!isAlive) return;

			transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
		}

		private void PatrolCheck()
		{
			var ground = Physics2D.Raycast(groundDetector.position, Vector2.down, .5f);
			if (ground.collider) return;
			transform.Rotate(0, 180, 0);
		}
		
		private void OnCollisionEnter2D(Collision2D col)
		{
			DeathCheck(col);
		}

		private void DeathCheck(Collision2D col)
		{
			if (!col.gameObject.CompareTag("Player")) return;
			var player = col.gameObject.GetComponent<Player>();
			if (isHitOnHead)
			{
				Die(player.GetComponent<Rigidbody2D>());
			}
			else
			{
				player.Hurt();
			}
		}

		public void Die(Rigidbody2D player)
		{
			player.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
			Destroy(gameObject);
		}
	}
}