using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaserScript : MonoBehaviour {

    public GameObject laserPrefab;
    public Transform laserSpawn;

    public GameObject laserSound;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    // Update is called once per frame
    void Update () {
        myTime = myTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && myTime > nextFire)
        {
            // Make laser sound
            GameObject makeSound = Instantiate(laserSound, this.transform.position, this.transform.rotation) as GameObject;

            nextFire = myTime + fireDelta;

            // Create the laser beam
            GameObject laserBeam = Instantiate(
                    laserPrefab,
                    laserSpawn.position,
                    laserSpawn.rotation);

            // Add velocity to the bullet
            laserBeam.GetComponent<Rigidbody>().velocity = laserBeam.transform.forward * 6;

            // Destroy the bullet after 2 seconds
            Destroy(laserBeam, 3.0f);

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
	}
}
