using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaCollision : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);

        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }
    }
}
