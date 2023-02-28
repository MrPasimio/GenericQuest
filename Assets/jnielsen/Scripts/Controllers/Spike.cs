using System;
using UnityEngine;

namespace jnielsen.Scripts.Controllers
{
    public class Spike : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = Utils.GetGameManager();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _gameManager.Respawn();
            }
        }
    }
}
