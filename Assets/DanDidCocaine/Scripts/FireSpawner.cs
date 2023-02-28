using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject fire;
    public GameObject spawn2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFire", 0, 1);
        InvokeRepeating("SpawnFire2", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFire()
    {
        Instantiate(fire, gameObject.transform.position, gameObject.transform.rotation);
    }

    void SpawnFire2()
    {
        Instantiate(fire, spawn2.gameObject.transform.position, gameObject.transform.rotation);
    }
}
