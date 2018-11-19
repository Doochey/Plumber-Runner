﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlasmaScript : MonoBehaviour {
    public GameObject plasmaPrefab;
    public Transform plasmaSpawn;

    public GameObject plasmaSound;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse1) && myTime > nextFire)
        {
            // Make plasma sound
            GameObject makeSound = Instantiate(plasmaSound, this.transform.position, this.transform.rotation) as GameObject;

            nextFire = myTime + fireDelta;

            // Create the laser beam
            GameObject plasmaBall = Instantiate(
                    plasmaPrefab,
                    plasmaSpawn.position,
                    plasmaSpawn.rotation);

            // Add velocity to the bullet
            plasmaBall.GetComponent<Rigidbody>().velocity = plasmaBall.transform.forward * 6;

            // Destroy the bullet after 2 seconds
            Destroy(plasmaBall, 3.0f);

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }
}
