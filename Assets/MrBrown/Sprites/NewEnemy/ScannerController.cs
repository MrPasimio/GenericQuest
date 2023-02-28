using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerController : MonoBehaviour
{
    public GameObject laser;
    public GameObject currentLaser;
    public GameObject laserSpawn;
    public GameObject scan;
    public GameObject currentScan;
    public GameObject scanSpawn;
    public bool detectedPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detectedPlayer == true)
        {
            Destroy(currentScan);
            Invoke("ShootLaser", 0.25f);
        }

        if(currentLaser != null)
        {
            currentLaser.transform.parent = laserSpawn.transform;
        }

        if(currentScan != null)
        {
            currentScan.transform.position = scanSpawn.transform.position;
        }
    }

    public void StartScan()
    {
        currentScan = Instantiate(scan, transform, false);
    }

    public void ShootLaser()
    {
        currentLaser = Instantiate(laser, transform, false);
        currentLaser.transform.rotation = transform.rotation;
    }

    public void KillLaser()
    {
        Destroy(currentLaser);
    }
}
