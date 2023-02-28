using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadNextLevel1 : MonoBehaviour
{
    public string nextLevel;
    public float delay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && CollectStar.starAmount == 2)
        {
            Invoke("NextScene", delay);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
