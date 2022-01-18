using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Vehicle
{
	
    // Start is called before the first frame update
    void Start()
    {
        horsePower = 16.0f;
		turnSpeed = 50.0f;
		health = 1000;
		maxHealth = 1000;
		vehicleRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (manualControl && (vehicleRb != null))
		{
			ManualMove();
		}
    }
}
