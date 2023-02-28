using UnityEngine;

namespace jnielsen.Scripts.Controllers.Enemy
{
	public class HeadDetection : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				var blocker = transform.parent.GetComponent<Blocker>();

				blocker.isHitOnHead = true;
				blocker.Die(collision.gameObject.GetComponent<Rigidbody2D>());
			}
		}
	}
}