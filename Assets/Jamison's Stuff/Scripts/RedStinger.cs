using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStinger : MonoBehaviour
{
    //Bools
    public bool CanShoot;
    public bool IsDead;

    //Floats
    public float CoolDownBetweenFire;
    public float FireBuffer;
    public float DeathCoolDown;
    public float speed = 20f;

    //GameObjects;
    public GameObject RedStingerBody;
    public GameObject RedStingerHitPoint;
    public GameObject RayCastOrigin;

    public GameObject RedStingerBullet;
    public GameObject BulletSource;

    

    //Components
    private BoxCollider2D Box;
    private BoxCollider2D WeakPoint;

    //RayCasts
    private RaycastHit2D PlayerDetector;

    // Start is called before the first frame update
    void Start()
    {
        Box = RedStingerBody.GetComponent<BoxCollider2D>();
        WeakPoint = RedStingerHitPoint.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //RayCasts
         PlayerDetector = Physics2D.Raycast(RayCastOrigin.transform.position, Vector2.right, speed );

    }


    void Death()
    {
        Debug.Log("Stinger destroyed");

        Destroy(gameObject);
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(DeathCoolDown);

        Death();
    }

    IEnumerator ShootingSequence()
    {
        CanShoot = false;
        Instantiate(RedStingerBullet, BulletSource.transform.position, BulletSource.transform.rotation);

        yield return new WaitForSeconds(FireBuffer);

        Instantiate(RedStingerBullet, BulletSource.transform.position, BulletSource.transform.rotation);

        yield return new WaitForSeconds(CoolDownBetweenFire);

        CanShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (CanShoot == true && PlayerDetector.collider.CompareTag("Player"))
        {
            StartCoroutine(ShootingSequence());
        }
    }
}
