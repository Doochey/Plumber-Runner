using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaserScript : MonoBehaviour {

    public GameObject laserPrefab;
    public Transform laserSpawn;
    public GameObject laserSound;

	public float spead = 10;
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

        if (Input.GetKey(KeyCode.Mouse0) && myTime > nextFire)
        {
            // Make laser sound
            GameObject makeSound = Instantiate(laserSound, this.transform.position, this.transform.rotation) as GameObject;

            nextFire = myTime + fireRate;

            // Create the laser beam
            GameObject laserBeam = Instantiate(
                    laserPrefab,
                    laserSpawn.position,
                    laserSpawn.rotation);

            // Add velocity to the bullet
            laserBeam.GetComponent<Rigidbody>().velocity = laserBeam.transform.forward * 10;

            // Destroy the bullet after x seconds
            Destroy(laserBeam, 10.0f);

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