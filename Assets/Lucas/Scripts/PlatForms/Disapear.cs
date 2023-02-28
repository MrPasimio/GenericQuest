using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    private Collider2D Box;
    private SpriteRenderer SR;

    public float aVal = 0f;
    public bool Fade = false;

    // Start is called before the first frame update
    void Start()
    {
        Box = GetComponent<BoxCollider2D>();
        SR = GetComponent<SpriteRenderer>();
        aVal = SR.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(.5f);
        Debug.Log("Before " + SR.color.a);
        aVal = aVal / 2;
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, aVal);
        Debug.Log("After " + SR.color.a);
        if (Fade) { StartCoroutine(FadeOut()); }
        
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(5);
        Box.enabled = false;
        Fade = false;
        StartCoroutine(TimeBeforeAppear());
    }

    IEnumerator FadeIN()
    {
        yield return new WaitForSeconds(.5f);
        aVal = 150;
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 150);
        
    }

    IEnumerator ReApear()
    {
        yield return new WaitForSeconds(5);
        Box.enabled = true;
        StartCoroutine(FadeIN());
    }

    IEnumerator TimeBeforeAppear()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(ReApear());
        

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(delete());
            StartCoroutine(FadeOut());
            Fade = true;
        }
    }

}
