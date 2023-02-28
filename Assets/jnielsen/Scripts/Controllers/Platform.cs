using static jnielsen.Scripts.Data.Platform;
using UnityEngine;

namespace jnielsen.Scripts.Controllers
{
	public class Platform : MonoBehaviour
	{
		[Header("Platform Type")] public Type platformType;

		[Header("Move Forward Properties")] public float moveSpeed;

		[Header("Sine Platform Properties")] public MoveType platformMoveType;
		public bool useCosine;
		public float amplitude;
		public float period;

		private Vector2 _startPos;
		private float _verticalPos;
		private float _horizontalPos;

		private void MoveForward()
		{
			transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
		}

		private void SinePlatform()
		{
			Sine();

			transform.position = new Vector2(_horizontalPos, _verticalPos);
		}

		private void Sine()
		{
			float b;
			
			switch (platformMoveType)
			{
				case MoveType.Vertical:
					SetOtherPosition();
					b = Mathf.PI * 2 / period;

					_verticalPos = useCosine
						? _startPos.y + amplitude * Mathf.Cos(b * Time.time)
						: _startPos.y + amplitude * Mathf.Sin(b * Time.time);
					break;
				case MoveType.Horizontal:
					SetOtherPosition();
					b = Mathf.PI * 2 / period;
					
					_horizontalPos = useCosine
						? _startPos.x + amplitude * Mathf.Cos(b * Time.time)
						: _startPos.x + amplitude * Mathf.Sin(b * Time.time);
					break;
			}
		}

		private void SetOtherPosition()
		{
			switch (platformMoveType)
			{
				case MoveType.Vertical:
					_horizontalPos = _startPos.x;
					break;
				case MoveType.Horizontal:
					_verticalPos = _startPos.y;
					break;
			}
		}

		private void Awake()
		{
			_startPos = transform.position;
		}

		private void Update()
		{
			switch (platformType)
			{
				case Type.MoveForward:
					MoveForward();
					break;
				case Type.SinePlatform:
					SinePlatform();
					break;
			}
		}


		private void OnCollisionEnter2D(Collision2D col)
		{
			if (col.gameObject.CompareTag("Player"))
			{
				col.transform.parent = transform;
			}
		}

		private void OnCollisionExit2D(Collision2D col)
		{
			if (col.gameObject.CompareTag("Player"))
			{
				col.transform.parent = null;
			}
		}
	}
}