using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextLevel2 : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(LoadSceneWithDelay("Level 3", 1f));
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level 3");
    }
}
