using jnielsen.Scripts.Data;
using UnityEngine;

namespace jnielsen.Scripts.Controllers
{
	public class Wall : MonoBehaviour
	{
		public Direction2 direction;
		public Collider2D _player;

		private BoxCollider2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<BoxCollider2D>();
			Physics2D.IgnoreCollision(_rigidbody, _player);
		}
	}
}
