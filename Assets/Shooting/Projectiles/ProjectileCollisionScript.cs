using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to each of the projectiles to enable destruction on collision
public class ProjectileCollisionScript : MonoBehaviour {

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
            GameObject makeSound = Instantiate(explosionSound, this.transform.position, this.transform.rotation) as GameObject;

            // Show a particle effect as an explosion
            var exp = gameObject.GetComponent<ParticleSystem>();
            exp.Play();

            // Destroy the asteroid
            Destroy(collider.gameObject);

            // Decrease aSpawned Counter
            GameObject asteroidSpawner = GameObject.FindWithTag("ASpawner");
            asteroidSpawner.GetComponent<AsteroidSpawner>().decreaseAspawned(1);
        }
    }
}