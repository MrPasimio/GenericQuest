using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextLevel1 : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(LoadSceneWithDelay("Level 2", 1f));
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level 2");
    }
}
