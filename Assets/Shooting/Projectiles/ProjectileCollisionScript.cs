using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to each of the projectiles to enable destruction on collision
public class ProjectileCollisionScript : MonoBehaviour {

    public GameObject explosion;
    public GameObject explosionSound;
    public string target;

    void OnTriggerEnter(Collider collider)
    {
        // Destroy the laser beam if it collides with anything
        Destroy(gameObject);

        // If the laser beams hits an asteroid:
        if (collider.gameObject.tag == target)
        {
            // Play the explosion sound
            GameObject makeExplosion = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;
            GameObject makeSound = Instantiate(explosionSound, this.transform.position, this.transform.rotation) as GameObject;

            // Destroy the asteroid
            Destroy(collider.gameObject);

            // Decrease aSpawned Counter
            GameObject asteroidSpawner = GameObject.FindWithTag("ASpawner");
            asteroidSpawner.GetComponent<AsteroidSpawner>().decreaseAspawned(1);
        }
    }
}