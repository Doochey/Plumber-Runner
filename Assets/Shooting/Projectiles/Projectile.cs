using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // Destroy the projectile GameObject whel it hits any other collider
	void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
