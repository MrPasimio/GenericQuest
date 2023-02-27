using UnityEngine;

namespace jnielsen.Scripts
{
	public abstract class Utils
	{
		public static GameManager GetGameManager()
		{
			return GameObject.Find("GameManager").GetComponent<GameManager>();
		}
	}
}