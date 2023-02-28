using jnielsen.Scripts.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace jnielsen.Scripts.Controllers
{
	public class Camera : MonoBehaviour
	{
		public Transform followedObject;
		public TilemapCollider2D tilemapCollider;

		private UnityEngine.Camera _camera;
		private TilemapBounds _tilemapBounds;

		private void Awake()
		{
			_camera = GetComponent<UnityEngine.Camera>();
			CalculateHorizontalSize();
		}

		private void Update()
		{
			transform.position = new Vector3(Mathf.Clamp(followedObject.position.x, _tilemapBounds.Left,
				_tilemapBounds.Right), 0, -10);
		}

		private static float GetHorizontalSize(UnityEngine.Camera camera)
		{
			return camera.orthographicSize * camera.aspect;
		}

		private void CalculateHorizontalSize()
		{
			var horizontalSize = GetHorizontalSize(_camera);
			_tilemapBounds = new TilemapBounds(tilemapCollider.bounds, horizontalSize);
		}
	}
}