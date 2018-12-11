using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the player ship to enable shooting
public class ShootScript : MonoBehaviour {

    public GameObject laserPrefab;
    public GameObject plasmaPrefab;
    public Transform beamSpawn;

    public GameObject laserSound;
    public GameObject plasmaSound;
    
    [Range(0.1F, 10.0F)]
    public float fireRate;
    [Range(1, 100)]
    public float speed;
    [Range(1, 100)]
    public float lifetime;

    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    void Fire(GameObject beam, GameObject sound)
    {
        // Make laser sound
        GameObject makeSound = Instantiate(sound, this.transform.position, this.transform.rotation) as GameObject;

        nextFire = myTime + fireRate;

        // Create the laser beam
        GameObject newBeam = Instantiate(beam, beamSpawn.position, beamSpawn.rotation);

        // Add velocity to the bullet
        newBeam.GetComponent<Rigidbody>().velocity = newBeam.transform.forward * speed;

        // Destroy the bullet after x seconds
        Destroy(newBeam, lifetime);

        nextFire = nextFire - myTime;
        myTime = 0.0F;
    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && myTime > nextFire)
        {
            Fire(laserPrefab, laserSound);
        }

        if (Input.GetKey(KeyCode.Mouse1) && myTime > nextFire)
        {
            Fire(plasmaPrefab, plasmaSound);
        }
    }
}