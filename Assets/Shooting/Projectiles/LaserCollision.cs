using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour {

    public GameObject explosionSound;

    void OnTriggerEnter(Collider collider)
    {
        // Destroy the laser beam if it collides with anything
        Destroy(gameObject);

        // If the laser beams hits an asteroid:
        if (collider.gameObject.tag == "Asteroid")
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
