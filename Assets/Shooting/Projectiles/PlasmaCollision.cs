using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaCollision : MonoBehaviour {

    public GameObject explosionSound;

    void OnTriggerEnter(Collider collider)
    {
        // Destroy the plasma beam of it collides with anything
        Destroy(gameObject);
        
        // If the plasma beam hits an enemy spaceship:
        if (collider.gameObject.tag == "Enemy")
        {
            // Make explosion sound
            GameObject makeSound = Instantiate(explosionSound, this.transform.position, this.transform.rotation) as GameObject;

            // Show a particle effect as an explosion
            var exp = gameObject.GetComponent<ParticleSystem>();
            exp.Play();

            // Destroy the enemy spaceship
            Destroy(collider.gameObject);
        }
    }
}
