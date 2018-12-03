using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);

        if (collider.gameObject.tag == "Asteroid")
        {
            Destroy(collider.gameObject);
        }
    }
}
