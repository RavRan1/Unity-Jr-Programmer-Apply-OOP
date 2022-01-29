using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGuard : Vehicle
{
	private float zDiff = 8;
	
    // Start is called before the first frame update
    void Start() // POLYMORPHISM
    {
        horsePower = 1600.0f;
		turnSpeed = 45.0f;
		health = 300;
		maxHealth = 300;
		fireDelay = 0.2f;
		vehicleRb = GetComponent<Rigidbody>();
		
		if (vehicleRb != null)
		{
			vehicleRb.AddForce(Vector3.forward * 3600.0f, ForceMode.Impulse);
		}
    }
	
	protected override void AutoControl() // POLYMORPHISM
	{
		GameObject truck = GameObject.Find("Truck");
		
		if (truck != null && vehicleRb != null)
		{
			TurnForwards();
			
			if (transform.position.z < (truck.transform.position.z - zDiff))
			{
				vehicleRb.AddForce(Vector3.forward * horsePower);
			} else
			{
				vehicleRb.AddForce(Vector3.back * horsePower);
			}
		}
		
		Fire();
	}
}
