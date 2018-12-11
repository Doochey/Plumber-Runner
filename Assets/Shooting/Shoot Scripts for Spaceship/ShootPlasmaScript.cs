using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlasmaScript : MonoBehaviour {

    public GameObject plasmaPrefab;
    public Transform plasmaSpawn;
    public GameObject plasmaSound;

	public float speed = 10;
    public float baseFireRate;

	private float fireRate;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
	private bool fireRateBuffed;
	private IEnumerator buffInst;

	void Start()
	{
		fireRateBuffed = false;
		fireRate = baseFireRate;
	}

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse1) && myTime > nextFire)
        {
            // Make plasma sound
            GameObject makeSound = Instantiate(plasmaSound, this.transform.position, this.transform.rotation) as GameObject;

            nextFire = myTime + fireRate;

            // Create the laser beam
            GameObject plasmaBall = Instantiate(
                    plasmaPrefab,
                    plasmaSpawn.position,
                    plasmaSpawn.rotation);

            // Add velocity to the bullet
            plasmaBall.GetComponent<Rigidbody>().velocity = plasmaBall.transform.forward * speed;

            // Destroy the bullet after x seconds
            Destroy(plasmaBall, 10.0f);

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

	//increase fire rate for time and by multiplier, refreshing if already active
	public void fireRateUp(int rateMultiplier, int buffTime)
	{
		if (fireRateBuffed)
		{
			StopCoroutine (buffInst);
		}
		buffInst = FireRateUp (rateMultiplier, buffTime);
		StartCoroutine (buffInst);
	}

	//coroutine to increase fire rate for a time
	IEnumerator FireRateUp(int rateMultiplier, int buffTime)
	{
		fireRateBuffed = true;
		fireRate /= rateMultiplier;
		yield return new WaitForSeconds (buffTime);
		fireRate = baseFireRate;
		fireRateBuffed = false;
	}
}