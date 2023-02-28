using jnielsen.Scripts.Data;
using UnityEngine;

namespace jnielsen.Scripts.Controllers.Enemy
{
	public class Ball : MonoBehaviour
	{
		public float wallForce;
		public float knockBackForce;
		
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			_rigidbody.AddForce(Vector2.right * wallForce, ForceMode2D.Impulse);
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
			if (col.gameObject.CompareTag("Wall"))
			{
				PushBall(col);
			}
			else if (col.gameObject.CompareTag("Player"))
			{
				PushPlayer(col);
			}
		}

		private void PushBall(Collision2D col)
		{
			switch (col.gameObject.GetComponent<Wall>().direction)
			{
				case Direction2.Left:
					_rigidbody.AddForce(Vector2.right * wallForce, ForceMode2D.Impulse);
					break;
				case Direction2.Right:
					_rigidbody.AddForce(Vector2.left * wallForce, ForceMode2D.Impulse);
					break;
			}
		}

		private void PushPlayer(Collision2D col)
		{
			var playerRb = col.gameObject.GetComponent<Rigidbody2D>();

			switch (GetDirection(transform.position, col.transform.position))
			{
				case Direction2.Left:
					playerRb.AddForce(Vector2.left * knockBackForce, ForceMode2D.Impulse);
					break;
				case Direction2.Right:
					playerRb.AddForce(Vector2.right * knockBackForce, ForceMode2D.Impulse);
					break;
			}
		}

		private static Direction2 GetDirection(Vector3 source, Vector3 target)
		{
			return target.x < source.x ? Direction2.Left : Direction2.Right;
		}
	}
}