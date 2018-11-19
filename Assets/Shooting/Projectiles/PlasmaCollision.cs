using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.tag == "Comet")
        {
            Destroy(collision.gameObject);
        }
    }
}
