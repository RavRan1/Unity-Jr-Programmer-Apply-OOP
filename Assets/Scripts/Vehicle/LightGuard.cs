using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGuard : Vehicle
{
	private float zDiff = 10;
	
    // Start is called before the first frame update
    void Start() // POLYMORPHISM
    {
        horsePower = 800.0f;
		turnSpeed = 75.0f;
		health = 200;
		maxHealth = 200;
		fireDelay = 0.5f;
		vehicleRb = GetComponent<Rigidbody>();
		
		if (vehicleRb != null)
		{
			vehicleRb.AddForce(Vector3.forward * 1600.0f, ForceMode.Impulse);
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
