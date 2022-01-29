using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Vehicle
{
    // Start is called before the first frame update
    void Start() // POLYMORPHISM
    {
        horsePower = 1000.0f;
		turnSpeed = 50.0f;
		health = 150;
		maxHealth = 150;
		guns = new Transform[0];
		vehicleRb = GetComponent<Rigidbody>();
		
		if (vehicleRb != null)
		{
			vehicleRb.AddForce(Vector3.forward * 2000.0f, ForceMode.Impulse);
		}
    }
	
	protected override void DestroyEffect() // POLYMORPHISM
	{
		// Animation can be added here.
		
		GameObject manager = GameObject.Find("Game Manager");
		
		if (manager != null)
		{
			manager.GetComponent<GameManager>().GameOver();
		}
	}
}
