using UnityEngine;

namespace jnielsen.Scripts.Controllers.Enemy
{
	public class EnemyDeath : MonoBehaviour
	{
		public bool isHitOnHead;
		public GameObject player;
		public float bounceForce;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				player = collision.gameObject;
				if (isHitOnHead)
				{
					Die();
				}
				else
				{
					player.GetComponent<Player>().Hurt();
				}
			}
		}

		public void Die()
		{
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
			Destroy(gameObject);
		}
	}
}