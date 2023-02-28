using UnityEngine;
using System.Collections;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private GameObject shieldObject; // Assign the shield object in the Inspector
    private bool shieldActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ShieldPowerup") && !shieldActive)
        {
            shieldActive = true;
            shieldObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(DeactivateShieldAfterDelay(5f));


        }
    }
    private IEnumerator DeactivateShieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        shieldActive = false;
        shieldObject.SetActive(false);
    }

}



