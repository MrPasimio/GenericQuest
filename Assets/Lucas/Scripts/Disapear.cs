using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    private Collider2D Box;

    // Start is called before the first frame update
    void Start()
    {
        Box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(5);
    }

}
