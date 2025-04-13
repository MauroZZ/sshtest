using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawn;

    public float shotForce = 10000;
    public float shotRate = 0.5F;

    private float shotRateTime = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawn.position, spawn.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawn.forward * shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 2);
            }
        }
    }
}
