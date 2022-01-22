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
		health = 1000;
		maxHealth = 1000;
		guns = new Transform[0];
		vehicleRb = GetComponent<Rigidbody>();
		
		if (vehicleRb != null)
		{
			vehicleRb.AddForce(Vector3.forward * 2000.0f, ForceMode.Impulse);
		}
    }
}
